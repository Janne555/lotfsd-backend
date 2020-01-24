using System;
using System.Collections.Generic;

namespace Lotfsd.Data.Models
{
  public class Item
  {
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public int StackSize { get; set; }
    public Double EncumbrancePoints { get; set; }
    public int Encumbrance { get; set; }
    public string Description { get; set; }
    public int BaseArmorClass { get; set; }
    public string Type { get; set; }
    public string Damage { get; set; }
    public int AttackBonus { get; set; }
    public int RangeShort { get; set; }
    public int RangeMedium { get; set; }
    public int RangeLong { get; set; }

    public List<ItemEffect> Effects { get; set; }
  }
}
