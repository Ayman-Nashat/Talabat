using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Service.Contract;
using Talabat.Repository.Identity;
using Talabat.Service;
namespace Talabat.APIs.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAuthService), typeof(AuthService));

            services.AddIdentity<AppUser, IdentityRole>
            //(options =>
            //{
            //    options.Password.RequireDigit = true;
            //    options.Password.RequireNonAlphanumeric = true;
            //    options.Password.RequireUppercase = true;
            //    options.Password.RequireLowercase = true;
            //    options.Password.RequiredLength = 6;
            //})
            ().AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddAuthentication(/*JwtBearerDefaults.AuthenticationScheme*/ options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(Options =>
                {
                    //Configure Authentication Handler
                    Options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true,
                        ValidAudience = configuration["JWT:ValidAudience"],
                        ValidateIssuer = true,
                        ValidIssuer = configuration["JWT:ValidIssuer"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"])),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromDays(double.Parse(configuration["JWT:DurationInDays"]))
                    };
                }).AddJwtBearer("Bearer02", options =>
                {

                }).AddCookie("xxx", options =>
                {

                });

            return services;
        }
    }
}