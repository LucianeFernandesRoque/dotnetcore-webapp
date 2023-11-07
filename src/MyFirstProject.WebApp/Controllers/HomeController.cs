﻿using Microsoft.AspNetCore.Mvc;
using MyFirstProject.WebApp.Models;
using System.Diagnostics;

namespace MyFirstProject.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.VersionInfoNumber = _configuration.GetSection("VersionInfo:Number").Value;
            ViewBag.VersionInfoDate = _configuration.GetSection("VersionInfo:Date").Value;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}