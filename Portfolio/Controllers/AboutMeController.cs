using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.services;

namespace Portfolio.Controllers
{
    public class AboutMeController : Controller
    {
        private AboutMeServices _service;

        public AboutMeController()
        {
            _service = new AboutMeServices("TestPosts");
        }

        public IActionResult Index()
        {
            var data = _service.GetAboutMe();
            return View(data);
        }

    }
}
