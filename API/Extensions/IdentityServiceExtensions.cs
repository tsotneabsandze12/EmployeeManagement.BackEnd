using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<AppUser>();

            builder = new IdentityBuilder(builder.UserType, builder.Services);
            //to work with the Identity db
            builder.AddEntityFrameworkStores<IdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();

            
            services.AddAuthentication();

            return services;
        }
    }
}