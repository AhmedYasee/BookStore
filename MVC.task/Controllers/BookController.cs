using Microsoft.AspNetCore.Mvc;
using MVC.task.Context;
using MVC.task.Migrations;
using MVC.task.Models;
using MVC.task.ViewModel;

namespace MVC.task.Controllers
{
    public class BookController : Controller
    {
        //List<Book> Books = new List<Book>
        //{
        //    new Book()
        //            {
        //                id = 1,
        //                name="Happy Planning",
        //                price=50

        //            },
        //               new Book()
        //            {
        //                id = 2,
        //                name="Peak Mind",
        //                price=100

        //            },
        //               new Book()
        //            {
        //                id = 3,
        //                name="The Snow ball effect",
        //                price=150

        //            },
        //                new Book()
        //            {
        //                id = 4,
        //                name="Algorithm Design",
        //                price=50

        //            },
        //               new Book()
        //            {
        //                id = 5,
        //                name="An Introduction to the Analysis of Algorithms",
        //                price=100

        //            },
        //               new Book()
        //            {
        //                id = 6,
        //                name="Data structures in Java",
        //                price=150

        //            }

        //};
        public IActionResult Index()
        {
            var context = new BookContext();
            var Books = context.Books.ToList();
            return View(Books);
        }
        public IActionResult Details(int id)
        {
            var context = new BookContext();
            var Books = context.Books.FirstOrDefault(b=>b.id==id);
            return View(Books);
        }

        public IActionResult AddBook()
        {
            var context = new BookContext();
            var Category = context.Categories.ToList();
            ViewData["cat"]= Category;
            return View();
        }
        public IActionResult SaveBook(NewBook Book)
        {
            var context = new BookContext();
            if (ModelState.IsValid)
            {
                var newBook = new Book()
                {
                    name = Book.name,
                    price = Book.price,
                    CategoryId = Book.CategoryId

                };
                context.Books.Add(newBook);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
			var Category = context.Categories.ToList();
			ViewData["cat"] = Category;
			return View("AddBook",Book);

		}
        public IActionResult UpdateBook(int id )
        {
            var context = new BookContext();
            var Book = context.Books.FirstOrDefault(c => c.id == id);

            var BookModel = new UpdateBook()
            {
                id = Book.id,
                price = Book.price,
                name = Book.name,
                CategoryId = Book.CategoryId,
            };

            var Category = context.Categories.ToList();
            ViewData["cat"] = Category;
            return View(BookModel);
        }
        public IActionResult SaveUpdateBook(UpdateBook Books)
        {
            var context = new BookContext();


            var Book = context.Books.FirstOrDefault(c => c.id == Books.id);


            Book.name = Books.name; 
            Book.price = Books.price;  
            Book.CategoryId = Books.CategoryId;

            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBook(int id)
        {
            var context = new BookContext();
            var Book = context.Books.FirstOrDefault(c => c.id ==id);
            context.Books.Remove(Book);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
