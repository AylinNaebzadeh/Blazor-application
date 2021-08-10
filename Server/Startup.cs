using BlazorDB.Server.DB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;

namespace BlazorDB.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddControllersWithViews();
            services.AddRazorPages();
            var sqlConnectionString = "Host=ec2-54-235-108-217.compute-1.amazonaws.com;Port=5432;Database=dcql2fuaut5mnf;Username=ljvmqztwksmgay;Password=8814f2b0bc782c24dd3e9732b0462edf6e501c89338ab924a792f50f2862c7e1;sslmode=Prefer;Trust Server Certificate=true;";
            services.AddDbContext<ProductDBContext>(options => options.UseNpgsql(sqlConnectionString));
            services.AddScoped<ProductProvider>();

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("a1",new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "API Title Is",
                    Version = "a1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            app.UseSwagger();
            app.UseSwaggerUI( c => {
                c.SwaggerEndpoint("/swagger/a1/swagger.json","a1 api test");
            });
        }
    }
}
