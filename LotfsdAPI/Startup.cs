using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Lotfsd.API.Models;
using Lotfsd.Data;
using Lotfsd.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GraphQL.Types;
using GraphQL.Server;
using Lotfsd.Types;
using Lotfsd.Types.Models;

namespace Lotfsd.API
{
  public class Startup

  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.Configure<KestrelServerOptions>(options =>
      {
        options.AllowSynchronousIO = true;
      });

      string key = Configuration["secret"];

      services.Configure<DatabaseSettings>(
          Configuration.GetSection(nameof(DatabaseSettings)));

      services.AddSingleton<IDatabaseSettings>(sp =>
      {
        var conf = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
        conf.ConnectionString = Configuration["dbconnection"];
        conf.Secret = key;
        return conf;
      });

      services.AddHttpContextAccessor();

      services.AddSingleton<MongoService>();
      services.AddSingleton<UserService>();
      services.AddSingleton<CharacterSheetService>();

      services.AddControllers()
        .AddNewtonsoftJson(Options => Options.UseMemberCasing());

      services.AddIdentityCore<User>(options => { });
      services.AddScoped<IUserStore<User>, UserStore>();

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
        .AddJwtBearer(options =>
        {
          options.RequireHttpsMetadata = false;
          options.SaveToken = true;
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
          };
        });

      services.AddSingleton<LotfsdQuery>();
      services.AddSingleton<LotfsdMutation>();
      services.AddSingleton<CharacterSheetType>();
      services.AddSingleton<CharacterSheetInputType>();
      services.AddSingleton<ISchema, LotfsdSchema>();

      services.AddGraphQL(_ =>
      {
        _.EnableMetrics = true;
        _.ExposeExceptions = true;
      })
        .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });

      services.AddControllers();

      ConfigureGraphQLTypes(services);
    }

    public void ConfigureGraphQLTypes(IServiceCollection services)
    {
      services.AddSingleton<CharacterSheetType>()
        .AddSingleton<CharacterSheetInputType>()
        .AddSingleton<AttributesType>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.Map("/graphql", branch => //https://github.com/graphql-dotnet/server/pull/158#issuecomment-431381490
      {
        branch.UseAuthentication();
        branch.UseAuthorization();
        branch.UseGraphQL<ISchema>("");
      });

      app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
