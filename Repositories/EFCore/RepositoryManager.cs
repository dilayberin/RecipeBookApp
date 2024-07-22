using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore//BÜTÜN REPOLARIN YÖNETİMİNİ REP.MANAGER YAPAR
{

    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly Lazy<IMealRepository> _mealRepository;

        public RepositoryManager(RepositoryContext context)
        {
            _context = context;
            _mealRepository = new Lazy<IMealRepository>(() => new MealRepository(_context));
        }

        public IMealRepository Meal => _mealRepository.Value;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}