using Microsoft.AspNetCore.Mvc;

namespace MVC.task.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult WriteCookie(string theme)
        {

            var COOKIE = new CookieOptions()
            {
                Expires = DateTime.Now.AddHours(4)
            };
            HttpContext.Response.Cookies.Append("theme", theme, COOKIE);

            return Content("Cookie Has Been Setted");
        }
        public IActionResult ReadCookie()
        {
            var theme = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "theme");


            return Content($"User Theme : {theme}");
        }
    }
}
