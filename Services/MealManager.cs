using AutoMapper;
using Entities;
using Entities.DataTransferObject;
using Entities.Exceptions;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Repositories.EFCore;
using Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services//UYGULAMANIN AKLI SERVİS KATMANIDIR.
{
    public class MealManager : IMealService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;


        public MealManager(IRepositoryManager manager, 
            ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }



        public async Task<MealDto> CreateOneMealAsync(Meal meal)
        {
            
            _manager.Meal.CreateOneMeal(meal);
            await _manager.SaveAsync();

            MealDto mealDto = _mapper.Map<MealDto>(meal);

            return mealDto;
        }


        public async Task DeleteOneMealAsync(int id, bool trackChanges)
        {
            // check entity 
            var entity = await _manager.Meal.GetOneMealByIdAsync(id, trackChanges);
            if (entity is null)
                throw new MealNotFoundException(id);
                
            _manager.Meal.DeleteOneMeal(entity);
            await _manager.SaveAsync();
        }

       

        public async Task<(IEnumerable<MealDto> meals, MetaData metaData)> 
            GetAllMealsAsync(MealParameters mealParameters,bool trackChanges)
        {
            if(!mealParameters.ValidCookingTimeRange)
                throw new CookingTimeOutOfRangeBadRequestException();


            var mealsWithMetaData=await _manager
                .Meal
                .GetAllMealsAsync(mealParameters,trackChanges);
            
            var mealsDto=_mapper.Map<IEnumerable<MealDto>>(mealsWithMetaData);
            return (mealsDto,mealsWithMetaData.MetaData);
        }

    

        public async Task<MealDto> GetOneMealByIdAsync(int id, bool trackChanges)
        {
            var meal= await _manager.Meal.GetOneMealByIdAsync(id, trackChanges);
            if (meal is null)
                throw new MealNotFoundException(id);

            return _mapper.Map<MealDto>(meal);
            
        }



        public async Task UpdateOneMealAsync(int id, MealDtoForUpdate mealDto,
            bool trackChanges)
        {
            var entity = await _manager.Meal.GetOneMealByIdAsync(id, trackChanges);
            if(entity is null)
                throw new MealNotFoundException(id);

            entity = _mapper.Map<Meal>(mealDto);
            _manager.Meal.Update(entity);
            await _manager.SaveAsync();
        }



        public async Task<(MealDtoForUpdate mealDtoForUpdate, Meal meal)>
            GetOneMealForPatchAsync(int id, bool trackChanges)
        {
            var meal = await _manager.Meal.GetOneMealByIdAsync(id, trackChanges);

            if (meal is null)
                throw new MealNotFoundException(id);

            var mealDtoForUptade=_mapper.Map<MealDtoForUpdate>(meal);
            return (mealDtoForUptade, meal);
        }



        public async Task SaveChangesForPatchAsync(MealDtoForUpdate mealDtoForUpdate, 
            Meal meal)
        {
            _mapper.Map(mealDtoForUpdate, meal);
            await _manager.SaveAsync();
        }

        
    }
}