using Proiect_DezvoltareaAplicatiilorWeb.Helpers.JwtUtils;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.AddressRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.MovieRentalRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.MovieRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.RentalRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.UnitOfWork;
using Proiect_DezvoltareaAplicatiilorWeb.Repositories.UserRepository;
using Proiect_DezvoltareaAplicatiilorWeb.Services.AddressService;
using Proiect_DezvoltareaAplicatiilorWeb.Services.MovieRentalService;
using Proiect_DezvoltareaAplicatiilorWeb.Services.MovieService;
using Proiect_DezvoltareaAplicatiilorWeb.Services.RentalService;
using Proiect_DezvoltareaAplicatiilorWeb.Services.UserService;

namespace Proiect_DezvoltareaAplicatiilorWeb.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRentalRepository, RentalRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IMovieRentalRepository, MovieRentalRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRentalService, RentalService>();
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IMovieRentalService, MovieRentalService>();
            services.AddTransient<IAddressService, AddressService>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services) 
        {
            services.AddScoped <IJwtUtils, JwtUtils.JwtUtils>();
            return services;
        }
    }
}
