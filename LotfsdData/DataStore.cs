using System.Threading.Tasks;
using Lotfsd.Data.Models;

namespace Lotfsd.Data
{
  public class DataStore
  {
    private readonly LotfsdContext _lotfsdContext;

    public DataStore(LotfsdContext lotfsdContext)
    {
      this._lotfsdContext = lotfsdContext;
    }

    public async Task<CharacterSheet> AddCharacterSheet(CharacterSheet characterSheet)
    {
      _lotfsdContext.CharacterSheets.Add(characterSheet);
      await _lotfsdContext.SaveChangesAsync();
      return characterSheet;
    }
  }
}
