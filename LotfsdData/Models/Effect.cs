using System;
namespace Lotfsd.Data.Models
{
  public class Effect
  {
    public int Id { get; set; }
    public string Type { get; set; }
    public string Target { get; set; }
    public string Method { get; set; }
    public int Value { get; set; }
  }
}
