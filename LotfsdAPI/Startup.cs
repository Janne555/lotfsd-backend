using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Lotfsd.API.Models;
using Lotfsd.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GraphQL.Types;
using GraphQL.Server;
using Lotfsd.Types.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lotfsd.Types;
using Lotfsd.Data;

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

      services.AddSingleton(sp =>
      {
        var conf = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
        conf.ConnectionString = Configuration["dbconnection"];
        conf.Secret = key;
        return conf;
      });

      services.AddDbContext<LotfsdContext>(
          options => options
            .UseNpgsql(Configuration.GetConnectionString("LotfsdConnection"))
            .EnableSensitiveDataLogging()
      );
      services.AddScoped<DataStore>();

      services.AddHttpContextAccessor();

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

      services.AddSingleton<ItemInstanceType>();
      services.AddSingleton<ItemInstanceInputType>();
      services.AddSingleton<PropertyType>();
      services.AddSingleton<PropertyInputType>();
      services.AddSingleton<RetainerType>();
      services.AddSingleton<RetainerInputType>();
      services.AddSingleton<EffectInputType>();
      services.AddSingleton<CharacterSheetInputType>();
      services.AddSingleton<EffectType>();
      services.AddScoped<CharacterSheetType>();
      services.AddScoped<LotfsdQuery>();
      services.AddScoped<LotfsdMutation>();
      services.AddScoped<ISchema, LotfsdSchema>();

      services.AddGraphQL(_ =>
      {
        _.EnableMetrics = true;
        _.ExposeExceptions = true;
      })
        .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });

      services.AddControllers();
    }


    private void HandleBranch(IApplicationBuilder app)
    {
      app.Run(context =>
      {
        return Task.FromResult(context.Response.StatusCode = 401);
      });
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
        branch.UseCors(x => x
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

        branch.MapWhen(context => context.User.FindFirst(ClaimTypes.Name) == null, HandleBranch);

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
