﻿using BigSchoolRemake.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace BigSchoolRemake.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext = new ApplicationDbContext();
        //private ApplicationDbContext _dbContext = new ApplicationDbContext();
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourses = _dbContext.Courses
            .Include(c => c.Lecturer)
            .Include(c => c.Category)
            .Where(c => c.datetime > DateTime.Now);
            return View(upcommingCourses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}