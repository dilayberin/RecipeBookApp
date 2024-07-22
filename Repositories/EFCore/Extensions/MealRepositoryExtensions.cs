using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repositories.EFCore.Extensions
{
    public static class MealRepositoryExtensions
    {
        public static IQueryable<Meal> FilterMeals(this IQueryable<Meal> meals,
            uint minCookingTime, uint maxCookingTime) =>
            meals.Where(meal =>
            meal.CookingTime >= minCookingTime &&
            meal.CookingTime <= maxCookingTime);

        public static IQueryable<Meal> Search(this IQueryable<Meal>meals
            ,string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return meals;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return meals
                .Where(b => b.FoodName
                .ToLower()
                .Contains(searchTerm));
        }
    }

}
