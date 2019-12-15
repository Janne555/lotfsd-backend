using System.Security.Claims;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LotfsdAPI.Models;
using LotfsdAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LotfsdAPI.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly UserService _userService;
    private readonly UserManager<User> _userManager;
    private readonly string _secret;

    public UserController(UserService userService, UserManager<User> userManager, IDatabaseSettings dbsettings)
    {
      _userService = userService;
      _userManager = userManager;
      _secret = dbsettings.Secret;
    }



    [Route("/api/[controller]/register")]
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(RegisterModel model)
    {
      if (ModelState.IsValid)
      {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user == null)
        {
          user = new User
          {
            UserName = model.Username
          };

          var result = await _userManager.CreateAsync(user, model.Password);
        }
        return Ok();
      }
      return BadRequest();
    }

    [Route("/api/[controller]/login")]
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody]LoginModel model)
    {
      var user = await _userManager.FindByNameAsync(model.Username);
      if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
      {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
          Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
            }),
          Expires = DateTime.UtcNow.AddDays(7),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(tokenHandler.WriteToken(token));
      }
      return Ok();
    }
  }
}
