using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using LotfsdAPI.Models;
using LotfsdAPI.Services;

namespace LotfsdAPI
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
      services.Configure<DatabaseSettings>(
          Configuration.GetSection(nameof(DatabaseSettings)));

      services.AddSingleton<IDatabaseSettings>(sp =>
      {
        var conf = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
        conf.ConnectionString = Configuration["dbconnection"];
        return conf;
      });

      services.AddSingleton<MongoService>();

      services.AddSingleton<CharacterSheetService>();

      services.AddControllers()
        .AddNewtonsoftJson(Options => Options.UseMemberCasing());

      // services.AddIdentityCore<string>(options => { });

      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
