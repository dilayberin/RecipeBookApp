using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IMealService> _mealService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _mealService = new Lazy<IMealService>(() => 
            new MealManager(repositoryManager,logger,mapper));

            _authenticationService=new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger,mapper,userManager,configuration));

        }

        public IMealService MealService => _mealService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }

}