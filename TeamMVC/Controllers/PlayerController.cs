using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Service.Viewmodels;
using Service.StorageService;
using Model.Viewmodels;

namespace TeamMVC.Controllers
{
    public class PlayerController : Controller
    {

        PlayerService ps;
        TeamService ts;
        StorageService ss;
        public PlayerController()
        {
            ts = new TeamService();
            ps = new PlayerService();
            ss = new StorageService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(ps.getDisplayPlayers());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreatePlayer());
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ps.ImportInsertPlayer(collection["player.Prename"].ToString(),
                    collection["player.Surname"].ToString(),
                    Convert.ToInt32(collection["player.Number"]),
                    ts.GetTeamIdByTeamName(Convert.ToString(collection["teamSelect"])));
                ps.Create(ps.insertPlayer, collection["File"].ToString());

                return RedirectToAction("Index",ps.getDisplayPlayers());
            }
            catch
            {
                return RedirectToAction("Index", ps.getDisplayPlayers());
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            
            return View(ps.GetDisplayPlayer(id));
        }

       [HttpGet]
        public ActionResult Edit(int id)
        {
            EditPlayer editPlayer = new EditPlayer();
            editPlayer.ImportPlayer(id);
            return View(editPlayer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection collection)
        {
            EditPlayer editPlayer = new EditPlayer();
            editPlayer.Id = Convert.ToInt32(collection["Id"].ToString());
            editPlayer.Prename = collection["Prename"].ToString();
            editPlayer.Surname = collection["Surname"].ToString();
            editPlayer.Number = Convert.ToInt32(collection["Number"].ToString());
            editPlayer.TeamId = ts.GetTeamIdByTeamName(Convert.ToString(collection["teamSelect"]));
          
            try
            {
               ps.Edit(editPlayer);   

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

   
        
        
        public ActionResult Delete(int id)
        {
            try
            {
                ps.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
