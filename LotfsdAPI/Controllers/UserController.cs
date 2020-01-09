using System.Security.Claims;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lotfsd.API.Models;
using Lotfsd.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Lotfsd.Data.Models;
using System.Linq;


namespace Lotfsd.API.Controllers
{
  [ApiController]
  [Authorize]
  [Route("api/[controller]")]
  public class UserController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly string _secret;
    private readonly CharacterSheetService<Info> _infoService;

    public UserController(
      UserManager<User> userManager,
      IDatabaseSettings dbsettings,
      CharacterSheetService<Info> infoService
      )
    {
      _userManager = userManager;
      _secret = dbsettings.Secret;
      _infoService = infoService;
    }



    [HttpPost("register")]
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

          await _userManager.CreateAsync(user, model.Password);
        }
        return Ok();
      }
      return BadRequest();
    }

    [Route("login")]
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
                    new Claim(ClaimTypes.Name, user.Id)
            }),
          Expires = DateTime.UtcNow.AddDays(7),
          SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        var infos = await _infoService.Get(user.Id);

        var asDict = infos.ToDictionary(x => x.CharacterId, x => x.Name);

        return Ok(new UserDetails
        {
          Token = tokenHandler.WriteToken(token),
          Characters = asDict
        });
      }
      return StatusCode(401);
    }
  }
}
