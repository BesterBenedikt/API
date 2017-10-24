using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
namespace TeamMVC.Controllers
{
    public class MatchController : Controller
    {
        private MatchService ms; 
        
        public MatchController()
        {
            ms = new MatchService();
        }
        // GET: Match
        public ActionResult Index()
        {

            return View(ms.GetAllMatches());
        }
    }
}