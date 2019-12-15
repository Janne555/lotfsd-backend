using System.Text;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LotfsdAPI.Models;
using LotfsdAPI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace LotfsdAPI.Controllers
{
  [ApiController]
  [Authorize]
  [Route("/api/[controller]")]
  public class CharacterSheetController : ControllerBase
  {
    private readonly ILogger<CharacterSheetController> _logger;
    private readonly UserManager<User> _userManager;
    private readonly CharacterSheetService _charactersheetService;

    public CharacterSheetController(ILogger<CharacterSheetController> logger, CharacterSheetService characterSheetService, UserManager<User> userManager)
    {
      _logger = logger;
      _charactersheetService = characterSheetService;
      _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<List<CharacterSheet>>> Get()
    {
      var userId = User.FindFirst(ClaimTypes.Name).Value;
      return await _charactersheetService.Get(userId);
    }


    [HttpGet("{id:length(24)}", Name = "GetCharacterSheet")]
    public async Task<ActionResult<CharacterSheet>> Get(String id)
    {
      var userId = User.FindFirst(ClaimTypes.Name).Value;
      var characterSheet = await _charactersheetService.Get(userId, id);
      if (characterSheet == null)
      {
        return NotFound();
      }

      return characterSheet;
    }

    [HttpPost]
    public async Task<ActionResult<CharacterSheet>> Create(CharacterSheet characterSheet)
    {
      var userId = User.FindFirst(ClaimTypes.Name).Value;
      var user = await _userManager.FindByIdAsync(userId);
      characterSheet.Owner = user;
      await _charactersheetService.Create(characterSheet);
      return CreatedAtRoute("GetCharacterSheet", new { id = characterSheet.Id.ToString() }, characterSheet);
    }
  }
}
