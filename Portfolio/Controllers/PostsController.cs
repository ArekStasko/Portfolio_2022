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
        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind("Title", "GithubLink", "SummaryDescription",
            "PhotoLink", "VideoLink", "Description")]Post post)
        {

            _service.InsertPost("Posts", post);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var post = _service.GetPostByID("Posts", id);
            if (post == null) return View("Error");
            return View(post);
        }

        [HttpPost]
        public ActionResult Delete(Guid _id)
        {
            Console.WriteLine(_id);
            var post = _service.GetPostByID("Posts", _id);
            if (post == null) return View("Error");
           
            _service.DeletePost("Posts", _id);
            return RedirectToAction("Index");
        }

    }
}
