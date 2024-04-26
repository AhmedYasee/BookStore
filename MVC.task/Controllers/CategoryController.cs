using Microsoft.AspNetCore.Mvc;
using MVC.task.Models;

namespace MVC.task.Controllers
{
    public class CategoryController : Controller
    {
        List<Category> categorys = new List<Category>
        {
            new Category()
            {
                Id = 1,
                Name = "Human Development",
                Books = new List<Book>
                {
                    new Book()
                    {
                        id = 1,
                        name="Happy Planning",
                        price=50

                    },
                       new Book()
                    {
                        id = 2,
                        name="Peak Mind",
                        price=100

                    },
                       new Book()
                    {
                        id = 3,
                        name="The Snow ball effect",
                        price=150

                    },

                }
            },
            new Category()
            {
                Id = 2,
                Name = "Algorithms & Data Structures",
                Books = new List<Book>
                {
                    new Book()
                    {
                        id = 4,
                        name="Algorithm Design",
                        price=50

                    },
                       new Book()
                    {
                        id = 5,
                        name="An Introduction to the Analysis of Algorithms",
                        price=100

                    },
                       new Book()
                    {
                        id = 6,
                        name="Data structures in Java",
                        price=150

                    },

                }
            }
        };
        public IActionResult Index()
        {
            return View();
        }
    }
}
