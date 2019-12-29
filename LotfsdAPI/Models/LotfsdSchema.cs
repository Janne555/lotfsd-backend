using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace LotfsdAPI.Models
{
  public class LotfsdSchema : Schema
  {
    public LotfsdSchema(IServiceProvider provider) : base(provider)
    {
      Query = provider.GetRequiredService<LotfsdQuery>();
    }
  }
}