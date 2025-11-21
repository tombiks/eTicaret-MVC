using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace eTicaret.Mvc.Controllers
{
    [Route("profile")]
    public class ProfileController : Controller
    {

        [Route("details")]
        public IActionResult Details(int UserId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int UserId) 
        {
            return Ok("change success");
        }

        public IActionResult MyOrders(int UserId)
        {
            return Ok();
        }

        public IActionResult MyProducts(int UserId)
        {
            return Ok();
        }
    }

    
    
}
