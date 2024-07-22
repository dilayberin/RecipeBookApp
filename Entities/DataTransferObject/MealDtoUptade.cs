using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    // Olası bir güncelleme durumunda güncellemyi yapar
    public record MealDtoForUpdate(int Id, string FoodName, string Description,
        string Ingredients, int CookingTime, int ServingsNumber, string Category);
    
}
