using Entities;
using Entities.RequestFeatures;

using static Entities.RequestFeatures.PageList;

namespace Repositories.Contracts
{
    
    public interface IMealRepository : IRepositoryBase<Meal>
    {
        Task<PagedList<Meal>> GetAllMealsAsync(MealParameters mealParameters, bool trackChanges);
        Task<Meal> GetOneMealByIdAsync(int id, bool trackChanges);
        void CreateOneMeal(Meal meal);
        void UpdateOneMeal(Meal meal);
        void DeleteOneMeal(Meal meal);
        
    }
}
