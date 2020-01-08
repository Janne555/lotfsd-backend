using GraphQL.Types;
using Lotfsd.Data;
using Lotfsd.Data.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Lotfsd.Types.Models
{
  public class LotfsdQuery : ObjectGraphType
  {
    private Task<T> SingleResolver<T>(
      ResolveFieldContext<object> context,
      CharacterSheetService<T> service
      ) where T : ICharacterSheet
    {
      var userContext = context.UserContext as GraphQLUserContext;
      var owner = userContext.User.FindFirst(ClaimTypes.Name).Value;
      return service.Get(context.GetArgument<string>("id"), owner);
    }

    private Task<List<T>> ManyResolver<T>(
      ResolveFieldContext<object> context,
      CharacterSheetService<T> service
      ) where T : ICharacterSheet
    {
      var userContext = context.UserContext as GraphQLUserContext;
      var owner = userContext.User.FindFirst(ClaimTypes.Name).Value;
      return service.Get(owner);
    }

    public LotfsdQuery(
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
      Name = "Query";

      Field<InfoType>(
        "info",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => SingleResolver(context, infoService));

      Field<ListGraphType<InfoType>>(
        "infos",
        resolve: context => ManyResolver(context, infoService));

      Field<AttributesType>(
        "attributes",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => SingleResolver(context, attributesService));

      Field<ListGraphType<AttributesType>>(
        "allAttributes",
        resolve: context => ManyResolver(context, attributesService));

      Field<AttributeModifiersType>(
        "attributeModifiers",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => SingleResolver(context, attributeModifiersService));

      Field<ListGraphType<AttributeModifiersType>>(
        "allAttributeModifiers",
        resolve: context => ManyResolver(context, attributeModifiersService));

      Field<SavingThrowsType>(
        "savingThrows",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => SingleResolver(context, savingThrowsService));

      Field<ListGraphType<SavingThrowsType>>(
        "allSavingThrows",
        resolve: context => ManyResolver(context, savingThrowsService));

      Field<CommonActivitiesType>(
        "commonActivities",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => SingleResolver(context, commonActivitiesService));

      Field<ListGraphType<CommonActivitiesType>>(
        "allCommonActivities",
        resolve: context => ManyResolver(context, commonActivitiesService));

      Field<WalletType>(
        "wallet",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => SingleResolver(context, walletService));

      Field<ListGraphType<WalletType>>(
        "wallets",
        resolve: context => ManyResolver(context, walletService));

      Field<EffectType>(
        "effect",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => SingleResolver(context, effectService));

      Field<ListGraphType<EffectType>>(
        "effects",
        resolve: context => ManyResolver(context, effectService));

      Field<RetainerType>(
        "retainer",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => SingleResolver(context, retainerService));

      Field<ListGraphType<RetainerType>>(
        "retainers",
        resolve: context => ManyResolver(context, retainerService));

      Field<CombatOptionsType>(
        "combatOptions",
        arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
        resolve: context => SingleResolver(context, combatOptionsService));

      Field<ListGraphType<CombatOptionsType>>(
        "allCombatOptions",
        resolve: context => ManyResolver(context, combatOptionsService));
    }
  }
}