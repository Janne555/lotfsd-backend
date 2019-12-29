using GraphQL;
using GraphQL.Types;

namespace LotfsdAPI.Models
{
  public class LotfsdSchema : Schema
  {
    public LotfsdSchema(IDependencyResolver resolver) : base(resolver)
    {
      Query = resolver.Resolve<LotfsdQuery>();
    }
  }
}