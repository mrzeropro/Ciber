using Ciber.CustomStorage;
using Ciber.Logging;
using Ciber.Models;
using Ciber.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using NLog;
using System.IO;

namespace Ciber
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
      LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<CiberdbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CiberContext")), ServiceLifetime.Transient);

      services.AddIdentity<User, Role>()
        .AddRoleStore<RoleStore>()
        .AddUserStore<UsersStore>()
        .AddDefaultTokenProviders();

      services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
      services.AddSingleton<ILoggerManager, LoggerManager>();
      services.AddScoped<IOrderRepository, OrderRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<ICustomerRepository, CustomerRepository>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();

      services.AddControllersWithViews().AddNewtonsoftJson(options =>
      options.SerializerSettings.ContractResolver = new DefaultContractResolver());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
    {
      app.UseHttpsRedirection();

      app.UseExceptionHandler("/error");

      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller=Order}/{action=Index}/{id?}");
      });

    }
  }
}
