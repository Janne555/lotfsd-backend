using System.Collections.Generic;

namespace Lotfsd.Data.Models
{
  public class User
  {
    public string Id { get; set; }
    public string UserName { get; set; }
    public string NormalizedUserName { get; set; }
    public string PasswordHash { get; set; }
    public List<CharacterSheet> Characters { get; set; }
  }
}