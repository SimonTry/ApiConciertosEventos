using ApiConciertos.Interfaces;
using ApiConciertos.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiConciertos.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var result = _authService.Register(model.Email, model.Password, model.Role);

            return Ok(result);
        }

        //public async Task<string?> Login()
        //{

        //}
    }
}
