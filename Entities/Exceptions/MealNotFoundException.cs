namespace Entities.Exceptions
{
  
        public sealed class MealNotFoundException : NotFoundException
    {
            public MealNotFoundException(int id)
                : base($"The meal with id : {id} could not found.")
            {
            }
        }
    

}
