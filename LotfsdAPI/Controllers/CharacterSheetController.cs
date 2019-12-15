using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LotfsdAPI.Models;
using LotfsdAPI.Services;
using Microsoft.AspNetCore.Authorization;


namespace LotfsdAPI.Controllers
{
  [ApiController]
  [AllowAnonymous]
  [Route("[controller]")]
  public class CharacterSheetController : ControllerBase
  {
    private readonly ILogger<CharacterSheetController> _logger;
    private readonly CharacterSheetService _charactersheetService;

    public CharacterSheetController(ILogger<CharacterSheetController> logger, CharacterSheetService characterSheetService)
    {
      _logger = logger;
      _charactersheetService = characterSheetService;
    }

    [HttpGet]
    public ActionResult<List<CharacterSheet>> Get()
    {
      return _charactersheetService.Get();
    }


    [HttpGet("{id:length(24)}", Name = "GetCharacterSheet")]
    public ActionResult<CharacterSheet> Get(String id)
    {
      var characterSheet = _charactersheetService.Get(id);
      if (characterSheet == null) {
        return NotFound();
      }

      return characterSheet;
    }

    [HttpPost]
    public ActionResult<CharacterSheet> Create(CharacterSheet characterSheet)
    {
      _charactersheetService.Create(characterSheet);
      return CreatedAtRoute("GetCharacterSheet", new { id = characterSheet.Id.ToString() }, characterSheet);
    }
  }
}
