using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using MongoDB.Driver;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                string constr = ConfigurationManager.AppSettings["DefaultConnectionString"];
                var Client = new MongoClient(constr);
                var DB = Client.GetDatabase("Post");
                var collection = DB.GetCollection<Post>("Post");
                collection.InsertOneAsync(post);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
