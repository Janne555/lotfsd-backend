using System.ComponentModel.DataAnnotations;

namespace Lotfsd.API.Models
{
  public class RegisterModel
  {
    public string Username { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Compare("Password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
  }
}