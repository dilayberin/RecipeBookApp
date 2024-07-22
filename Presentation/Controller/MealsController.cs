using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Entities;
using Entities.DataTransferObject;
using Entities.Exceptions;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;


namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/meals")]
    public class MealsController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public MealsController(IServiceManager manager)
        {
            _manager = manager;
        }

        [Authorize]
        [HttpGet(Name = "GetAllMealsAsync")]
        public async Task<IActionResult> GetAllMealsAsync([FromQuery] MealParameters mealParameters)
        {
            var pagedResult = await _manager
                .MealService
                .GetAllMealsAsync(mealParameters, false);

            Response.Headers.
                Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.meals);
        }



        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneMealAsync([FromRoute(Name = "id")] int id)//ASYNC KODLAR DAHA EFEKTİF KODLAR YAZMAYI SAĞLAR
        {
            var meal = await _manager
            .MealService
            .GetOneMealByIdAsync(id, false);

            return Ok(meal);

        }



        [Authorize(Roles = "User,Editor,Admin")]
        [HttpPost(Name = "CreateOneMealAsync")]
        public async Task<IActionResult> CreateOneMealAsync([FromBody] Meal meal)
        {
            if (meal is null)
                return BadRequest(); // 400 

            await _manager.MealService.CreateOneMealAsync(meal);

            return StatusCode(201, meal);

        }



        [Authorize(Roles = "Editor,Admin")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneMealAsync([FromRoute(Name = "id")] int id,
            [FromBody] MealDtoForUpdate mealDto)
        {

            if (mealDto is null)
                return BadRequest(); // 400 

            await _manager.MealService.UpdateOneMealAsync(id, mealDto, true);
            return NoContent(); // 204

        }



        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneMealAsync([FromRoute(Name = "id")] int id)
        {

            await _manager.MealService.DeleteOneMealAsync(id, false);
            return NoContent();

        }




        [Authorize(Roles = "Editor,Admin")]
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> PartiallyUpdateOneMealAsync([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Meal> mealPatch)
        {
            if (mealPatch is null)
                return BadRequest();

            var entity = await _manager
                .MealService
                .GetOneMealByIdAsync(id, false);



            var updated = new MealDtoForUpdate
                (entity.Id, entity.FoodName, entity.Description,entity.Ingredients,entity.CookingTime,entity.ServingsNumber,entity.Category);


            await _manager.MealService.UpdateOneMealAsync(id, updated, true);

            return NoContent(); // 204

        }
    }
}