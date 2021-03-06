using System;
using System.Text;
using Application.Common.Interfaces;
using Application.Settings;
using Domain.Settings;
using Hangfire;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
    public static class ServiceExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(x => 
                x.UseSqlServer(config.GetConnectionString("db")));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config.GetConnectionString("RedisUrl");
            });

            services.AddTransient<ICacheService, CacheService>();
            
            services.AddHangfire(x => x.UseSqlServerStorage(config.GetConnectionString("db")));
            services.AddHangfireServer();

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IShopRepository, ShopRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IDateService, DateServiceService>();

            services.Configure<JWTSettings>(config.GetSection("JWTSettings"));
            services.Configure<MailSettings>(config.GetSection("MailSettings"));

            services.AddSingleton(x => x.GetRequiredService<IOptions<JWTSettings>>().Value);
            services.AddSingleton(x => x.GetRequiredService<IOptions<MailSettings>>().Value);
            
            services.AddAuthentication(x => 
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    // x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = config["JWTSettings:Issuer"],
                        ValidAudience = config["JWTSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTSettings:Key"]))
                    };
                });
        }
    }
}