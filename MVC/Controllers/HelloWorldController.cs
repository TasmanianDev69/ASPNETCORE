using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MVC.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();

        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
        // 
        // GET: /HelloWorld/Welcome/4?name=X

        //public string Welcome(string name, int id = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, ID is: {id}");
        //}
    }
}
