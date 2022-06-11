using HelmetShop.Api.Core;
using HelmetShop.Application.UseCases.Commands;
using HelmetShop.Application.UseCases.Queries;
using HelmetShop.DataAccess;
using HelmetShop.Implementation.UseCases.Commands;
using HelmetShop.Implementation.UseCases.Queries;
using HelmetShop.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace HelmetShop.Api.Extensions
{
    public static class ContainerExtensions
    {
        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<HsContext>();
                var settings = x.GetService<AppSettings>();

                return new JwtManager(context, settings.JwtSettings);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();
            services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            services.AddTransient<CreateCategoryValidator>();

            services.AddTransient<IGetBrandsQuery, GetBrandsQuery>();
            services.AddTransient<ICreateBrandCommand, CreateBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, DeleteBrandCommand>();
            services.AddTransient<CreateBrandValidator>();
            

            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();
            services.AddTransient<RegisterValidator>();
        }

        public static void AddHsContext(this IServiceCollection services)
        {
            services.AddTransient(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var connectionString = x.GetService<AppSettings>().ConnectionString;

                optionsBuilder.UseSqlServer(connectionString);

                var options = optionsBuilder.Options;

                return new HsContext(options);
            });
        }
    }
}
