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
  }

  public interface IDatabaseSettings
  {
    string DatabaseName { get; set; }

    string ConnectionString { get; set; }

    string CharacterSheetCollectionName { get; set; }

    string UserCollectionName { get; set; }

    string Secret { get; set; }

    public string InfoCollectionName { get; set; }
  }
}
