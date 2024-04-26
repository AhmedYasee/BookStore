using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.task.Context;
using MVC.task.Models;
using MVC.task.ViewModel;
using System.Security.Claims;

namespace MVC.task.Controllers
{
	public class AuthController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}


		public IActionResult Register()
		{
			return View();
		}

		public IActionResult SubmitResgiter(AddUser user)
		{
			var contex = new BookContext();

			var newUser = new User()
			{
				Email = user.Email,
				Name = user.Name,
				Password = user.Password,
				Role = user.Role,
			};
			contex.Users.Add(newUser);
			contex.SaveChanges();
			return RedirectToAction("Login","Auth");
		}


		public IActionResult Login()
		{
			return View();
		}

		public async Task<IActionResult> SubmitLogin(LoginCred loginCred)
		{
			var context = new BookContext();
			var user = context.Users.FirstOrDefault(u => (u.Email == loginCred.Email && u.Password == loginCred.Password));
			if (user == null)
			{
				ModelState.AddModelError("", "Wrong Email Or Password");
				return View("Login", loginCred);
			}
			var claimsIdentity = new ClaimsIdentity("MyCookie");
			claimsIdentity.AddClaim(new Claim("Id", "Id", user.Id.ToString()));
			claimsIdentity.AddClaim(new Claim("Name", user.Name));
			claimsIdentity.AddClaim(new Claim("Email", user.Email));
			claimsIdentity.AddClaim(new Claim("Role", user.Role));
			var princable = new ClaimsPrincipal(claimsIdentity);
			await HttpContext.SignInAsync("MyCookie", princable, new AuthenticationProperties()
			{
				IsPersistent = true,
				ExpiresUtc = DateTime.UtcNow.AddHours(8),
			});
			return RedirectToAction("Index", "Book");
		}



		[Authorize]
		public IActionResult AuthView()
		{

			return View();
		}

		[Authorize(Policy = "Policy1")]
		public IActionResult ProtectedView()
		{
			return View();
		}

		public IActionResult Fobidden()
		{
			return View();
		}
		public IActionResult ResetPassword()
		{
			return View();
		}
		[HttpPost]
		public IActionResult SubmitResetPassword(ResetPasswordViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View("ResetPassword", model);
			}

			var context = new BookContext();
			var user = context.Users.FirstOrDefault(u => u.Email == model.Email);

			if (user == null)
			{
				ModelState.AddModelError("", "Invalid email address.");
				return View("ResetPassword", model);
			}

			// Update the user's password
			user.Password = model.NewPassword;
			context.SaveChanges();

			return RedirectToAction("Login");
		}

	}
}
