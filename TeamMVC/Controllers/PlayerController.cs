using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
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
        // GET: Player
        public ActionResult Index()
        {
            return View(ps.getDisplayPlayers());
        }



        // GET: Player/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Player/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new CreatePlayer());
        }

        // POST: Player/Create
        [HttpPost]
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

        // GET: Player/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Player/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Player/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
