namespace MVC.task.Models
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int CategoryId { get; set; }
        public Category CAtegory { get; set; }



    }
}
