using HelmetShop.Implementation.UseCases.Queries;
using HelmetShop.Api.Payment;
using HelmetShop.Application.UseCases.Queries;
using HelmetShop.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Implementation.UseCases.Commands;
using HelmetShop.Application.Logging;
using HelmetShop.Implementation.Logging;
using HelmetShop.Implementation;
using HelmetShop.Implementation.Validators;
using HelmetShop.Implementation.Emails;
using HelmetShop.Application.Emails;
using System.Reflection;
using System.IO;
using HelmetShop.Api.Core;
using HelmetShop.Api.Extensions;
using HelmetShop.Application.UseCases;
using HelmetShop.Implementation.UseCases.UseCaseLoggers;

namespace HelmetShop.Api
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
            var settings = new AppSettings();
            Configuration.Bind(settings);
            services.AddSingleton(settings);
            services.AddJwt(settings);
            services.AddHsContext();
            services.AddUseCases();
            services.AddApplicationUser();
            services.AddSingleton<IPaymentMethod, WireTransfer>();
            services.AddTransient<OrderProcessor>();

            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<IEmailSender, FakeEmailSender>();
            services.AddTransient<IUseCaseLogger, ConsoleUseCaseLogger>();

            services.AddControllers();
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HelmetShop.Api", Version = "v1" });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HelmetShop.Api v1"));
            }

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
