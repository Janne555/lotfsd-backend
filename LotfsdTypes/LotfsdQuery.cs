using System;
using System.Linq;
using System.Security.Claims;
using GraphQL.Types;
using Lotfsd.Data;
using Lotfsd.Data.Models;
using Lotfsd.Types.Models;
using Microsoft.EntityFrameworkCore;
namespace Lotfsd.Types
{
  public class LotfsdQuery : ObjectGraphType
  {

    public LotfsdQuery(DataStore dataStore, LotfsdContext dbcontext)
    {
      Name = "Query";
      Field<ListGraphType<NonNullGraphType<CharacterSheetType>>>(
        "CharacterSheets",
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var userId = userContext.User.FindFirst(ClaimTypes.Name).Value;
          return dataStore.GetCharacterSheets(Guid.Parse(userId));
        });

      Field<CharacterSheetType>(
        "CharacterSheet",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          var userContext = context.UserContext as GraphQLUserContext;
          var userId = userContext.User.FindFirst(ClaimTypes.Name).Value;
          return dataStore.GetCharacterSheet(Guid.Parse(userId), id);
        });

      Field<ListGraphType<NonNullGraphType<ItemType>>>(
        "Items",
        resolve: context =>
        {
          return dbcontext.Items.ToList();
        });

      Field<NonNullGraphType<ItemType>>(
        "Item",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context =>
        {
          var id = context.GetArgument<string>("id");
          return dbcontext.Items.Where(x => x.Guid.ToString() == id).FirstOrDefault();
        });
    }
  }
}