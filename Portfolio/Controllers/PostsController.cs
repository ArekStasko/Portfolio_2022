using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Data.services;

namespace Portfolio.Controllers
{
    public class PostsController : Controller
    {
        private PostsServices _service;

        public PostsController()
        {
            //Environment.GetEnvironmentVariable("MONGODB_ADRESS")
            _service = new PostsServices("TestPosts");
        }

        public IActionResult Index()
        {
            var data = _service.GetPosts("Posts");
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var post = _service.GetPostByID("Posts", id);
            if (post == null) return View("Error");
            return View(post);
        }

    }
}
