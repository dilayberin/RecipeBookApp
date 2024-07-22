using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    //SOYUTLAMALARDA uygulamanın detaylarıyla ilgilenilmez.amaç kural tanımlamaktır.
    public interface IRepositoryBase<T>//TÜM REPOSİTORY İÇİN ORTAK OLANLARI BURADA TOPLARIZ.
    {
        // IQueryable<T> sorgulama yapmak için
        IQueryable<T> FindAll(bool trackChanges);//trackChanges İŞLEMLERİ TAKİP ETMEK İÇİN KULLANILIR
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
