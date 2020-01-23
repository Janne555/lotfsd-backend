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
    public IConfiguration Configuration { get; }
    public readonly IWebHostEnvironment _env;

    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      Configuration = configuration;
      _env = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      GraphqlFix(services);

      services.AddSingleton(sp =>
      {
        var conf = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
        conf.Secret = Configuration["secret"];
        return conf;
      });

      services.AddDbContext<LotfsdContext>(
          options =>
          {
            if (_env.IsDevelopment())
            {
              options
                .UseNpgsql(Configuration["LotfsdConnection"])
                .EnableSensitiveDataLogging();
            }
            else
            {
              options.UseNpgsql(ConnStr.Parse(Configuration["LotfsdConnection"]));
            }
          }
      );
      services.AddScoped<DataStore>();

      services.AddHttpContextAccessor();

      services.AddControllers()
        .AddNewtonsoftJson(Options => Options.UseMemberCasing());

      services.AddIdentityCore<User>(options => { });
      services.AddScoped<IUserStore<User>, UserStore>();

      ConfigureJWT(services);
      ConfigureGrapqhl(services);

      services.AddControllers();
    }

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

    private void HandleBranch(IApplicationBuilder app)
    {
      app.Run(context =>
      {
        return Task.FromResult(context.Response.StatusCode = 401);
      });
    }

    private void ConfigureGrapqhl(IServiceCollection services)
    {
      services.AddSingleton<ItemInputType>();
      services.AddSingleton<ItemType>();
      services.AddSingleton<ItemEffectType>();
      services.AddSingleton<ItemEffectInputType>();
      services.AddSingleton<CharacterSheetUpdateType>();
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
    }

    private void ConfigureJWT(IServiceCollection services)
    {

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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["secret"])),
            ValidateIssuer = false,
            ValidateAudience = false
          };
        });

    }

    private void GraphqlFix(IServiceCollection services)
    {
      services.Configure<KestrelServerOptions>(options =>
      {
        options.AllowSynchronousIO = true;
      });

      services.Configure<IISServerOptions>(options =>
      {
        options.AllowSynchronousIO = true;
      });

    }
  }
}
