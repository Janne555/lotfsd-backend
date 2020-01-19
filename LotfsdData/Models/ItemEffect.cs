using System;
namespace Lotfsd.Data.Models
{
  public class ItemEffect
  {
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public string Method { get; set; }
    public string Target { get; set; }
    public int Value { get; set; }
  }
}
