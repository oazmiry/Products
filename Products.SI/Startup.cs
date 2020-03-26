using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Products.BL;
using Products.DAL;
using Products.SI.GraphQL;
using Products.SI.GraphQL.Models.GraphTypes;
using Products.SI.GraphQL.Resolvers.Mutation;
using Products.SI.GraphQL.Resolvers.Query;

namespace Products.SI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        /// <summary>
        /// Adds services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(Configuration);
            services.AddTransient<IProductsBusinessLogic, ProductsBusinessLogic>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IStoreContextFactory, StoreContextFactory>();
            services.AddTransient<IQueryResolver, QueryResolver>();
            services.AddTransient<IMutationResolver, MutationResolver>();
            services.AddTransient<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDependencyResolver>(s => new 
                FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<ISchema, GraphqlApiSchema>();
            services.AddTransient<SellerGraphType>();
            services.AddTransient<ItemGraphType>();
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseGraphiQl("/___graphql", "/graphql");
            }
            else
            {
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            app.UseMvc();
        }
    }
}
