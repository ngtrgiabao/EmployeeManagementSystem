using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contacts;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{
    private readonly IUserAccount _accountInterface;
    
    public AuthenticationController(IUserAccount accountInterface)
    {
        _accountInterface = accountInterface;
    }
  
    [HttpPost("register")]
    public async Task<IActionResult> CreateAsync([FromBody] Register user)
    {
        if (user == null) return BadRequest("Model is empty");
        var result = await _accountInterface.CreateAsync(user);
        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> SignInAsync(Login user)
    {
        if (user == null) return BadRequest("Model is empty");
        var result = await _accountInterface.LoginAsync(user);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshTokenAsync(RefreshToken token)
    {
        if (token == null) return BadRequest("Model is empty");
        var result = await _accountInterface.RefreshTokenAsync(token);
        return Ok(result);
    }
}
