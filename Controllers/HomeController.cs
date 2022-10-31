using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Controllers
{
    public class HomeController : Controller
    {
        private readonly SpaContext _context;

        public HomeController(SpaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult InquiryForm()
        {
            ViewBag.Posted = false;                                 //will be able to see if the form wasn't posted
            //[name] ....select list is a special list for a select tag (it creates our options)
            //the context object has an underscore to make it more secure
            //_context.Services is our collection
            //connecting to the classsification in the model
            //text we want displayed is the actual classificiation
            //it's a GET so nothing is currently selected so we don't want that final option so we omit it.
            ViewData["ServicesID"] = new SelectList(_context.Services, "Classification", "Classification"); //retrieve services and setup for a select dropdown list
            return View();
        }
        [HttpPost]
        public IActionResult InquiryForm(Contact model)
        {
            ViewBag.Posted = true;                                  //will be able to see if the form was posted
            return View(model);                                     //bringing in the model and returning it to the view
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Employees()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
