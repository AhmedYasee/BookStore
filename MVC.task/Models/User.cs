using System.ComponentModel.DataAnnotations;
namespace MVC.task.Models
{
	public class User
	{
		public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]  
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Passwerd Is Required")]
        public string Password { get; set; }
		public string Role { get; set; }
	}
}
