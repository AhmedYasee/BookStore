using Microsoft.AspNetCore.Mvc;

namespace MVC.task.Controllers
{
    public class SessionController1 : Controller
    {
        public IActionResult WriteSession(string name, int price)
        {
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetInt32("price", price);
            return Content("Session Has Been Setted");
        }



        public IActionResult ReadSession()
        {
            var name = HttpContext.Session.GetString("name");
            var price = HttpContext.Session.GetInt32("Price");
            return Content($"Book Name: {name}, Book Price: {price}");
        }
    }
}
