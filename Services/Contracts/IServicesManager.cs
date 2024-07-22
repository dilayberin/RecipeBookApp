using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Services.Contracts;

namespace Services.Contracts
{
    //SOYUTLAMALARDA uygulamanın detaylarıyla ilgilenilmez.amaç kural tanımlamaktır.
    public interface IServiceManager
    {
        IMealService MealService { get;}
        IAuthenticationService AuthenticationService { get;}
    }

}
