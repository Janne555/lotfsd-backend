using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LotfsdAPI.Models;
using LotfsdAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace LotfsdAPI.Controllers
{
  [ApiController]
  [Authorize]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private readonly UserService _userService;
    private readonly UserManager<User> _userManager;

    public UserController(UserService userService, UserManager<User> userManager)
    {
      _userService = userService;
      _userManager = userManager;
    }



    [Route("/[controller]/register")]
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
  }
}
