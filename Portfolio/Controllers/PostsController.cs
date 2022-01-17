using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Data.services;

namespace Portfolio.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            //Environment.GetEnvironmentVariable("MONGODB_ADRESS")
            var _service = new PostsServices("TestPosts");

            var examplePost = new Post()
            {
                Title = "ExamplePost",
                SummaryDescription = "This is example post",
                Description = "This is example post This is example post This is example post",
                PhotoLink = "None",
                VideoLink = "None"
            };

            //_service.InsertPost("Posts");

            return RedirectToAction("Index");
        }
    }
}
