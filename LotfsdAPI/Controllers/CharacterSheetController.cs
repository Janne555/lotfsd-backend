using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LotfsdAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CharacterSheetController : ControllerBase
  {
    private readonly ILogger<CharacterSheetController> _logger;

    public CharacterSheetController(ILogger<CharacterSheetController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public string Get()
    {
      return "hello";
    }
  }
}
