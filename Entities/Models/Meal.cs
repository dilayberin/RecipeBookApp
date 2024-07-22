using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities//KATMANLI MİMARİ YAZILIMIN KALİTESİNİ ARTTIRIR.
{
    public class Meal
    {
        public int Id { get; set; }
        public string FoodName { get; set; }

        public string Description { get; set; }

        public string Ingredients {get; set;}

        public int CookingTime { get; set; }
        public int ServingsNumber { get; set; } //kaç kişilik
        public string Category { get; set; }
       
    }
}
