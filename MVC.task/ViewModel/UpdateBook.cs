using System.ComponentModel.DataAnnotations;

namespace MVC.task.ViewModel
{
    public class UpdateBook
    {
        
        public int id  { get; set; }
		[Required(ErrorMessage = "Name Is Required")]
		[MinLength(5, ErrorMessage = "Minimum Length is 5 Char")]
		public string name { get; set; }
		[Required(ErrorMessage = "price Is Required")]
		public int price { get; set; }
		[Required]
		public int CategoryId { get; set; }
    }
}
