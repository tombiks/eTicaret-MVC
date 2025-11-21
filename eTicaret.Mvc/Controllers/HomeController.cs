using System.Diagnostics;
using eTicaret.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("about-us")]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            return RedirectToAction("AboutUs", "Home");
        }

        [Route("category/{categoryName}")]
        public IActionResult Listing([FromRoute]string categoryName) 
        { 
            return View();
        }

        [Route("product/{categoryName}-{title}-{id}/details")]
        public IActionResult ProductDetail(string categoryName, string title, int id)
        {
            return View();
        }




    }
}
