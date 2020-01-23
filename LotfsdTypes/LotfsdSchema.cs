using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace Lotfsd.Types
{
  public class LotfsdSchema : Schema
  {
    public LotfsdSchema(IServiceProvider provider) : base(provider)
    {
      Query = provider.GetRequiredService<LotfsdQuery>();
      Mutation = provider.GetRequiredService<LotfsdMutation>();
    }
  }
}