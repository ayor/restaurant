using System;
using System.Text;
using Application.Interfaces;
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
using StackExchange.Redis;

namespace Infrastructure
{
    public static class ServiceExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(x => 
                x.UseSqlServer(config.GetConnectionString("db")));

            var redis = ConnectionMultiplexer.ConnectAsync(config.GetConnectionString("RedisUrl")).Result;
            services.AddTransient(x => redis.GetDatabase(15));

            // services.AddTransient<ICacheService, CacheService>();
            
            

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IShopRepository, ShopRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEmailService, EmailService>();

            services.Configure<JWTSettings>(config.GetSection("JWTSettings"));
            services.Configure<MailSettings>(config.GetSection("MailSettings"));
            services.Configure<CacheSettings>(config.GetSection("CacheSettings"));
            
            services.AddSingleton(x => x.GetRequiredService<IOptions<JWTSettings>>().Value);
            services.AddSingleton(x => x.GetRequiredService<IOptions<MailSettings>>().Value);
            services.AddSingleton(x => x.GetRequiredService<IOptions<CacheSettings>>().Value);
            

            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "JWTSettings:Issuer",
                        ValidAudience = "JWTSettings:Audience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTSettings:Key"))
                    };
                });
        }
    }
}