using System;
using System.Collections.Generic;

namespace Lotfsd.Data.Models
{
  public class UserDetails
  {
    public string Token { get; set; }
    public Dictionary<string, string> Characters { get; set; }
  }
}
