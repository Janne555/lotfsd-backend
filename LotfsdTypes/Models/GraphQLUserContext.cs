using System.Security.Claims;
using GraphQL.Authorization;
using System.Collections.Generic;

namespace Lotfsd.Types.Models
{
  public class GraphQLUserContext : Dictionary<string, object>
  {
    public ClaimsPrincipal User { get; set; }
  }
}