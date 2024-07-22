using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    //SOYUTLAMALARDA uygulamanın detaylarıyla ilgilenilmez.amaç kural tanımlamaktır.
    public interface IRepositoryManager//İHTİYAÇ DAHİLİNDE REPOSİTORY OLUŞTURMAMIZI SAĞLAR.
    {
        IMealRepository Meal { get; }
        Task SaveAsync();
    }
}
