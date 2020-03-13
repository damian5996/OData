using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using OData.ArticleManager;
using OData.DataAccess.Configuration;
using OData.DataAccess.Data;
using OData.DataAccess.Repository;
using OData.DataAccess.Repository.Interfaces;
using OData.Models.Entities;
using System.Linq;

namespace OData
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
            services.AddControllers(options => options.EnableEndpointRouting = false).AddNewtonsoftJson();
            services.AddOData();

            services.AddDbContext<ApplicationDbContext>();

            services.Configure<ConnectionStringSettings>(Configuration.GetSection("ConnectionStrings"));

            services.AddScoped(typeof(IArticleRepository), typeof(ArticleRepository));
            services.AddScoped(typeof(IArticleCategoryRepository), typeof(ArticleCategoryRepository));

            services.AddScoped(typeof(IArticleService), typeof(ArticleService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().Filter().Expand();
                //routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        //private static IEdmModel GetEdmModel()
        //{
        //    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
        //    builder.EntitySet<Article>("Articles");
        //    builder.EntitySet<ArticleCategory>("ArticleCategories");
        //    return builder.GetEdmModel();
        //}
    }
}
