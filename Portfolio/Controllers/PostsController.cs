using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using Portfolio.Data.services;

namespace Portfolio.Controllers
{
    public class PostsController : Controller
    {
        private PostsServices _service;
        private readonly IConfiguration _config;

        public PostsController(IConfiguration config)
        {
            _config = config;   
        }

        public IActionResult Index()
        {
            InitializeDB();
            var data = _service.GetPosts("Posts");
            return View(data);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            InitializeDB();
            var post = _service.GetPostByID("Posts", id);
            if (post == null) return View("Error");
            return View(post);
        }

        private void InitializeDB()
        {
            string mng = _config["API:MNG"];
            Console.WriteLine(mng);
            _service = new PostsServices(mng);
        }
    }
}
