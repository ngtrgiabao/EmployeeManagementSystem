using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contacts;

namespace Server.Controllers;

[ApiController]
[Route("api/[controller]")]
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
}
