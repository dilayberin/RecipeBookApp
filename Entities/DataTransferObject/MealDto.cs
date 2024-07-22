using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public class MealDto // Hangi standarta göre eşleştircezs?
    {
        public int Id { get; init; }
        public string FoodName { get; init; }

        public String Description { get; init; }

        public String Ingredients { get; init; }

        public int CookingTime { get; init; }
        public int ServingsNumber { get; init; } //kaç kişilik
        public String Category { get; init; }
    }
}
