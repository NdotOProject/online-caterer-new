using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineCaterer.Web.MVC.Controllers
{
	public class AuthController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: AuthController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: AuthController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: AuthController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: AuthController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
