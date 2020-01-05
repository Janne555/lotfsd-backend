namespace Lotfsd.Data.Models
{
  public class DatabaseSettings : IDatabaseSettings
  {
    public string DatabaseName { get; set; }
    public string ConnectionString { get; set; }
    public string CharacterSheetCollectionName { get; set; }
    public string UserCollectionName { get; set; }
    public string Secret { get; set; }
    public string InfoCollectionName { get; set; }
    public string AttributesCollectionName { get; set; }
    public string AttributeModifiersCollectionName { get; set; }
    public string SavingThrowsCollectionName { get; set; }
    public string CommonActivitiesCollectionName { get; set; }
    public string WalletCollectionName { get; set; }
    public string EffectsCollectionName { get; set; }
    public string CombatOptionsCollectionName { get; set; }
    public string RetainersCollectionName { get; set; }
    public string PropertiesCollectionName { get; set; }
    public string ItemInstancesCollectionName { get; set; }
    public string ItemIndexCollectionName { get; set; }
  }

  public interface IDatabaseSettings
  {
    string DatabaseName { get; set; }

    string ConnectionString { get; set; }

    string CharacterSheetCollectionName { get; set; }

    string UserCollectionName { get; set; }

    string Secret { get; set; }

    public string InfoCollectionName { get; set; }

    public string AttributesCollectionName { get; set; }

    public string AttributeModifiersCollectionName { get; set; }

    public string SavingThrowsCollectionName { get; set; }

    public string CommonActivitiesCollectionName { get; set; }

    public string WalletCollectionName { get; set; }

    public string EffectsCollectionName { get; set; }

    public string CombatOptionsCollectionName { get; set; }

    public string RetainersCollectionName { get; set; }

    public string PropertiesCollectionName { get; set; }

    public string ItemInstancesCollectionName { get; set; }

    public string ItemIndexCollectionName { get; set; }
  }
}
