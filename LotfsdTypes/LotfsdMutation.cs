using System;
using System.Security.Claims;
using GraphQL.Types;
using Lotfsd.Data;
using Lotfsd.Data.Models;
using Lotfsd.Types.Models;

namespace Lotfsd.Types
{
  public class LotfsdMutation : ObjectGraphType
  {
    public LotfsdMutation(DataStore dataStore)
    {
      Name = "Mutation";

      Field<NonNullGraphType<CharacterSheetType>>(
        "createCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<CharacterSheetInputType>> { Name = "characterSheet" }
          ),
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var userId = userContext.User.FindFirst(ClaimTypes.Name).Value;
          var characterSheet = context.GetArgument<CharacterSheet>("characterSheet");
          characterSheet.Guid = Guid.NewGuid().ToString();
          characterSheet.UserId = Guid.Parse(userId);
          dataStore.AddCharacterSheet(characterSheet);
          return characterSheet;
        });

      Field<ListGraphType<CharacterSheetType>>(
        "deleteCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id" }
          ),
        resolve: context =>
        {
          var userContext = context.UserContext as GraphQLUserContext;
          var userId = userContext.User.FindFirst(ClaimTypes.Name).Value;
          var characterSheetId = context.GetArgument<string>("id");
          return dataStore.DeleteCharacterSheet(Guid.Parse(userId), characterSheetId);
        });

      Field<NonNullGraphType<CharacterSheetType>>(
        "updateCharacterSheet",
        arguments: new QueryArguments(
          new QueryArgument<StringGraphType> { Name = "id" },
          new QueryArgument<CharacterSheetUpdateType> { Name = "characterSheet" }
          ),
        resolve: context =>
        {
          var characterSheet = context.GetArgument<dynamic>("characterSheet");
          var characterSheetId = context.GetArgument<string>("id");
          return dataStore.UpdateCharacterSheet(characterSheet, characterSheetId);
        });

      Field<NonNullGraphType<ItemType>>(
        "createItem",
        arguments: new QueryArguments(
          new QueryArgument<ItemInputType> { Name = "item" }
          ),
        resolve: context =>
        {
          var item = context.GetArgument<Item>("item");
          return dataStore.CreateItem(item);
        });

      Field<NonNullGraphType<CharacterSheetType>>(
        "addRetainer",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<RetainerInputType>> { Name = "retainer" },
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "characterSheetId" }
          ),
        resolve: context =>
        {
          var retainer = context.GetArgument<Retainer>("retainer");
          var characterSheetId = context.GetArgument<string>("characterSheetId");
          return dataStore.AddRetainer(retainer, characterSheetId);
        });

      Field<NonNullGraphType<CharacterSheetType>>(
        "updateRetainer",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<RetainerUpdateType>> { Name = "retainerUpdate" },
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "characterSheetId" },
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "retainerId" }
          ),
        resolve: context =>
        {
          var retainerUpdate = context.GetArgument<dynamic>("retainerUpdate");
          var characterSheetId = context.GetArgument<string>("characterSheetId");
          var retainerId = context.GetArgument<string>("retainerId");
          return dataStore.UpdateRetainer(retainerUpdate, retainerId, characterSheetId);
        });


      Field<NonNullGraphType<CharacterSheetType>>(
        "addLanguage",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<LanguageInputType>> { Name = "language" },
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "characterSheetId" }
          ),
        resolve: context =>
        {
          var language = context.GetArgument<Language>("language");
          var characterSheetId = context.GetArgument<string>("characterSheetId");
          return dataStore.AddLanguage(language, characterSheetId);
        });

      Field<NonNullGraphType<CharacterSheetType>>(
        "addItemInstance",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "itemId" },
          new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "equipped" },
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "characterSheetId" }
          ),
        resolve: context =>
        {
          var itemId = context.GetArgument<string>("itemId");
          var equipped = context.GetArgument<bool>("equipped");
          var characterSheetId = context.GetArgument<string>("characterSheetId");
          return dataStore.AddItemInstance(itemId, equipped, characterSheetId);
        });

      Field<NonNullGraphType<CharacterSheetType>>(
        "addProperty",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<PropertyInputType>> { Name = "property" },
          new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "characterSheetId" }
          ),
        resolve: context =>
        {
          var property = context.GetArgument<Property>("property");
          var characterSheetId = context.GetArgument<string>("characterSheetId");
          return dataStore.AddProperty(property, characterSheetId);
        });
    }
  }
}
