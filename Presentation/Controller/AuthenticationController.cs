using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController:ControllerBase
    {
        private readonly IServiceManager _service;
        public  AuthenticationController(IServiceManager service)
        {
            _service = service;
        }


        [HttpPost]//Yeni bir kullanıcıyı kaydeder.
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var result=await _service
                .AuthenticationService
                .RegisterUser(userForRegistrationDto);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);

            }
            return StatusCode(201);

        }



        [HttpPost("login")]//Kullanıcıyı doğrular ve bir JWT token döner.
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized(); // 401


            return Ok(new
            {
                Token = await _service.AuthenticationService.CreateToken()
            }); ;

        }
    }
}
