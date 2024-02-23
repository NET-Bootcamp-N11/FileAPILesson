using FileAPILesson.Application.Services.UserProfileServices;
using Microsoft.Extensions.DependencyInjection;

namespace FileAPILesson.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileService, UserProfileService>();
            return services;
        }
    }
}
