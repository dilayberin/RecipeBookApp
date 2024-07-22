using Entities;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.RequestFeatures.PageList;

namespace Repositories.EFCore
{
    public sealed class MealRepository : RepositoryBase<Meal>, IMealRepository
    {
        public MealRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneMeal(Meal meal) => Create(meal);
        public void DeleteOneMeal(Meal meal) => Delete(meal);


        public async Task<PagedList<Meal>> 
            GetAllMealsAsync(MealParameters mealParameters,  bool trackChanges)
        {
           var meals= await FindAll(trackChanges)
                .FilterMeals(mealParameters.MinCookingTime,mealParameters.MaxCookingTime)//FİLTRELEME
                .Search(mealParameters.SearchTerm)//ARAMA
                .OrderBy(b => b.Id)//ID LERE GÖRE GETİR
                .ToListAsync();

            return PagedList<Meal>
                .ToPagedList(meals,//SAYFALAMA
                mealParameters.PageNumber,
                mealParameters.PageSize);
        }
          

        public async Task<Meal> GetOneMealByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();


        public void UpdateOneMeal(Meal meal) => Update(meal);
    }
}
