
namespace Lotfsd.Data.Models
{
  public class ItemInstance
  {
    public int Id { get; set; }
    public string Guid { get; set; }

    public int ItemId { get; set; }
    public Item Item { get; set; }
    public string ItemGuid { get; set; }

    public bool Equipped { get; set; }
  }
}
