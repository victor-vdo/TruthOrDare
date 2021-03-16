using Microsoft.Extensions.DependencyInjection;
using TruthOrDare.Domain.Contracts.Repositories;
using TruthOrDare.Domain.Contracts.Services;
using TruthOrDare.Domain.Services;
using TruthOrDare.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using TruthOrDare.Infra.Context;

namespace TruthOrDare.Api.Utils
{
    public static class ServiceCollection
    {
       
        public static IServiceCollection ServiceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("connectionString")));

            #region Services
            #endregion

            //var mapper = AutoMaperConfig.RegisterMappings().CreateMapper();
            //container.RegisterInstance<IMapper>(mapper);

            #region Services
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            return services;
        }
    }
}
