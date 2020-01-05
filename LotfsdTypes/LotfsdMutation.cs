using GraphQL.Types;
using Lotfsd.Data;
using Lotfsd.Data.Models;
using System.Security.Claims;
using Lotfsd.Types.Models;
using System.Threading.Tasks;

namespace Lotfsd.Types
{
  public class LotfsdMutation : ObjectGraphType
  {
    private Task<T> AddResolver<T>(
      ResolveFieldContext<object> context,
      CharacterSheetService<T> service,
      string name
      ) where T : ICharacterSheet
    {
      var userContext = context.UserContext as GraphQLUserContext;
      var doc = context.GetArgument<T>(name);
      doc.Owner = userContext.User.FindFirst(ClaimTypes.Name).Value;
      return service.Create(doc);
    }


    private Task<T> ReplaceResolver<T>(
      ResolveFieldContext<object> context,
      CharacterSheetService<T> service,
      string name
      ) where T : ICharacterSheet
    {
      var userContext = context.UserContext as GraphQLUserContext;
      var doc = context.GetArgument<T>(name);
      var id = doc.Id;
      var owner = userContext.User.FindFirst(ClaimTypes.Name).Value;
      doc.Owner = owner;
      return service.Replace(owner, doc, id);
    }



    public LotfsdMutation(
      CharacterSheetService<Info> infoService,
      CharacterSheetService<Attributes> attributesService,
      CharacterSheetService<AttributeModifiers> attributeModifiersService,
      CharacterSheetService<SavingThrows> savingThrowsService,
      CharacterSheetService<CommonActivities> commonActivitiesService,
      CharacterSheetService<Wallet> walletService,
      CharacterSheetService<Effect> effectService,
      CharacterSheetService<Retainer> retainerService,
      CharacterSheetService<CombatOptions> combatOptionsService
      )
    {
      Name = "Mutation";

      Field<InfoType>(
        "addInfo",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<InfoInputType>> { Name = "info" }
          ),
        resolve: context => AddResolver(context, infoService, "info"));

      Field<InfoType>(
        "replaceInfo",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<InfoInputType>> { Name = "info" }
          ),
        resolve: context => ReplaceResolver(context, infoService, "info"));

      Field<AttributesType>(
        "addAttributes",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<AttributesInputType>> { Name = "attributes" }
          ),
        resolve: context => AddResolver(context, attributesService, "attributes"));

      Field<AttributesType>(
        "replaceAttributes",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<AttributesInputType>> { Name = "attributes" }
          ),
        resolve: context => ReplaceResolver(context, attributesService, "attributes"));

      Field<AttributeModifiersType>(
        "addAttributeModifiers",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<AttributeModifiersInputType>> { Name = "attributeModifiers" }
          ),
        resolve: context => AddResolver(context, attributeModifiersService, "attributeModifiers"));

      Field<AttributeModifiersType>(
        "replaceAttributeModifiers",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<AttributeModifiersInputType>> { Name = "attributeModifiers" }
          ),
        resolve: context => ReplaceResolver(context, attributeModifiersService, "attributeModifiers"));

      Field<SavingThrowsType>(
        "addSavingThrows",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<SavingThrowsInputType>> { Name = "savingThrows" }
          ),
        resolve: context => AddResolver(context, savingThrowsService, "savingThrows"));

      Field<SavingThrowsType>(
        "replaceSavingThrows",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<SavingThrowsInputType>> { Name = "savingThrows" }
          ),
        resolve: context => ReplaceResolver(context, savingThrowsService, "savingThrows"));

      Field<CommonActivitiesType>(
        "addCommonActivities",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<CommonActivitiesInputType>> { Name = "commonActivities" }
          ),
        resolve: context => AddResolver(context, commonActivitiesService, "commonActivities"));

      Field<CommonActivitiesType>(
        "replaceCommonActivities",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<CommonActivitiesInputType>> { Name = "commonActivities" }
          ),
        resolve: context => ReplaceResolver(context, commonActivitiesService, "commonActivities"));

      Field<WalletType>(
        "addWallet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<WalletInputType>> { Name = "wallet" }
          ),
        resolve: context => AddResolver(context, walletService, "wallet"));

      Field<WalletType>(
        "replaceWallet",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<WalletInputType>> { Name = "wallet" }
          ),
        resolve: context => ReplaceResolver(context, walletService, "wallet"));

      Field<EffectType>(
        "addEffect",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<EffectInputType>> { Name = "effect" }
          ),
        resolve: context => AddResolver(context, effectService, "effect"));

      Field<InfoType>(
        "replaceEffect",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<EffectInputType>> { Name = "effect" }
          ),
        resolve: context => ReplaceResolver(context, effectService, "effect"));

      Field<RetainerType>(
        "addRetainer",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<RetainerInputType>> { Name = "retainer" }
          ),
        resolve: context => AddResolver(context, retainerService, "retainer"));

      Field<InfoType>(
        "replaceRetainer",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<RetainerInputType>> { Name = "retainer" }
          ),
        resolve: context => ReplaceResolver(context, retainerService, "retainer"));

      Field<CombatOptionsType>(
        "addCombatOptions",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<CombatOptionsInputType>> { Name = "combatOptions" }
          ),
        resolve: context => AddResolver(context, combatOptionsService, "combatOptions"));

      Field<InfoType>(
        "replaceCombatOptions",
        arguments: new QueryArguments(
          new QueryArgument<NonNullGraphType<CombatOptionsInputType>> { Name = "combatOptions" }
          ),
        resolve: context => ReplaceResolver(context, combatOptionsService, "combatOptions"));
    }
  }
}
