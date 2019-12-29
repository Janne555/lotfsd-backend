using System.Security.Claims;
using GraphQL.Authorization;

namespace LotfsdAPI.Models
{
  public class GraphQLUserContext : IProvideClaimsPrincipal
  {
    public ClaimsPrincipal User { get; set; }
  }
}