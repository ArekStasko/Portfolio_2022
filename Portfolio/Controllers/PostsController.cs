﻿using Microsoft.Extensions.Configuration.EnvironmentVariables;
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

        [HttpPost]
        public ActionResult Create()
        {
            var examplePost = new Post()
            {
                Title = "ExamplePost2",
                SummaryDescription = "This is example post",
                Description = "This is example post This is example post This is example post",
                PhotoLink = "https://static.wirtualnemedia.pl/media/top/gd-robot655.jpg",
                VideoLink = "None"
            };

            _service.InsertPost("Posts", examplePost);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var post = _service.GetPostByID("Posts", id);
            if (post == null) return View("Error");
            return View(post);
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            _service.DeletePost("Posts", id);
            return RedirectToAction("Index");
        }

    }
}
