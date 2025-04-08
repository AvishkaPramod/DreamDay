using DreamDay.lb.business.Common;
using DreamDay.lb.business.Manager;
using DreamDay.lb.business.Mapper;
using DreamDay.lb.business.Wrapper;
using DreamDay.lb.contracts.Manager;
using DreamDay.lb.contracts.Repositories;
using DreamDay.lb.data.Mappers;
using DreamDay.lb.data.Repositories;
using DreamDay.lb.dbcontext.tables.Models;
using DreamDay.lb.entities.Configuration;
using DreamDay.lb.entities.User;
using DreamDay.lb.shared.Contracts;
using DreamDay.lb.shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamDay.Models
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        /// 
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DreamDayContext>(options => options.UseMySql(configuration.GetConnectionString("ClientConnection"),
            new MySqlServerVersion(new Version("8.0.40"))));

            #region Configuration
            //services.Configure<LoginConfiguration>(configuration.GetSection("IdentityServer"));
            services.Configure<ConnectionStringConfiguration>(configuration.GetSection("ConnectionStrings"));
            #endregion

            #region Managers
            // User
            services.AddScoped<IUserManager, UserManager>();
            #endregion

            #region Repositories
            // User
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region Mapper
            services.AddSingleton<IEntityMapper, EntityMapper>();
            services.AddSingleton<IMapper<ResponseMessage, ResponseBase>, ServiceErrorMapper>();
            services.AddScoped<IMapper<Object, ResponseBase>, ServiceResponseMapper>();

            //User
            services.AddScoped<IMapper<UserRequestWrapper, UserSaveRequest>, UserSaveRequestMapper>();
            #endregion


            return services;
        }
    }
}
