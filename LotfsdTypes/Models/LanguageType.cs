using System;
using GraphQL.Types;
using Lotfsd.Data.Models;

namespace Lotfsd.Types.Models
{
  public class LanguageType : ObjectGraphType<Language>
  {
    public LanguageType()
    {
      Name = "Language";
      Field(x => x.Name);
      Field(x => x.Guid).Name("Id");
      Field(x => x.Known);
    }
  }

  public class LanguageInputType : InputObjectGraphType<Language>
  {
    public LanguageInputType()
    {
      Name = "LanguageInput";
      Field(x => x.Name);
      Field(x => x.Known);
    }
  }
}
