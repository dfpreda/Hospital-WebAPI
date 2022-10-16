using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Hospital.Extensions
{
    public static class AuthenticationExtension
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:Token").Value)),
                            ValidIssuer = configuration.GetSection("JwtSettings:Issuer").Value,
                            ValidAudience = configuration.GetSection("JwtSettings:Audience").Value,
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            RequireExpirationTime = true,
                            ClockSkew = System.TimeSpan.Zero
                        };
    });
        }
    }
}
