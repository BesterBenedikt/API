using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;


namespace TeamMVC.Controllers
{
    
    public class EventController : Controller
    {
        EventService es = new EventService();
        // GET: Event

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(es.GetEvents());
        }


        [HttpGet]
        [Authorize]
        public ActionResult  Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Domain.T003_Event ev)
        {
            es.CreateEvent(ev);
            
            return View("Index",es.GetEvents());
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            es.DeleteEvent(id);

            return View("Index", es.GetEvents());
        }
    }
}