using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.services;

namespace Portfolio.Controllers
{
    public class AboutMeController : Controller
    {
        private AboutMeServices _service;

        private readonly IConfiguration _config;

        public AboutMeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            InitializeDB();
            var data = _service.GetAboutMe();
            return View(data);
        }
        
        private void InitializeDB()
        {
            string mng = _config["API:MNG"];
            Console.WriteLine(mng);
            _service = new AboutMeServices(mng);
        }
       

    }
}
