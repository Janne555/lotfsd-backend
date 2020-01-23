using System.Security.Claims;
using System.Collections.Generic;

namespace Lotfsd.Types.Models
{
  public class GraphQLUserContext : Dictionary<string, object>
  {
    public ClaimsPrincipal User { get; set; }
  }
}