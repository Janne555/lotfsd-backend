using System;
namespace Lotfsd.Data.Models
{
  public class Retainer
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public int Hitpoints { get; set; }
    public int Wage { get; set; }
    public int Share { get; set; }
  }
}
