using ApiConciertos.Interfaces;
using ApiConciertos.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // ENDPOINT PARA REGISTRO
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO model)
    {
        var result = await _authService.Register(model.Email, model.Password, model.Role);

        if (result.Succeeded)
        {
            return Ok(new { Message = $"Usuario {model.Email} creado con éxito." });
        }

        return BadRequest(result.Errors);
    }

    // ENDPOINT PARA LOGIN
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO model)
    {
        var token = await _authService.Login(model.Email, model.Password);

        if (token != null)
        {
            return Ok(new { Token = token });
        }

        return Unauthorized(new { Message = "Credenciales incorrectas." });
    }
}