using Entities;
using Entities.DataTransferObject;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    //SOYUTLAMALARDA uygulamanın detaylarıyla ilgilenilmez.amaç kural tanımlamaktır.
    public interface IMealService
    {
        Task<(IEnumerable<MealDto> meals, MetaData metaData)> GetAllMealsAsync(MealParameters mealParameters, bool trackChanges);
        Task<MealDto> GetOneMealByIdAsync(int id, bool trackChanges);
        Task<MealDto> CreateOneMealAsync(Meal meal);
        Task UpdateOneMealAsync(int id, MealDtoForUpdate mealDto, bool trackChanges);
        Task DeleteOneMealAsync(int id, bool trackChanges);

       Task<(MealDtoForUpdate mealDtoForUpdate, Meal meal)> GetOneMealForPatchAsync(int id,bool trackChanges);

        Task SaveChangesForPatchAsync(MealDtoForUpdate mealDtoForUpdate, Meal meal);

    }
}
