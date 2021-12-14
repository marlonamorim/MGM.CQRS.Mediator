using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using MGM.CQRS.Mediator.Domain.Commands.Requests;
using MGM.CQRS.Mediator.Domain.Handlers;
using MGM.CQRS.Mediator.Domain.Queries.Requests;
using MGM.CQRS.Mediator.Domain.Repositories;
using MGM.CQRS.Mediator.Domain.Services;
using MGM.CQRS.Mediator.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MGM.CQRS.Mediator.Api
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
            services.AddControllers();

            // services.AddTransient<ICreateCustomerHandler, CreateCustomerHandler>();
            // services.AddTransient<IFindCustomerByIdHandler, FindCustomerByIdHandler>();

            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddMediatR(typeof(FindCustomerByIdRequest).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateCustomerRequest).GetTypeInfo().Assembly);
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
