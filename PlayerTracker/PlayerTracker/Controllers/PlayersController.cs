using PlayerTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace PlayerTracker.Controllers
{
    public class PlayersController : Controller
    {
        /*
        private ApplicationDbContext _context;
        public PlayersController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var players = _context.Players.Include(m => m.Team).ToList();
            
            return View(players);
        }
        public ActionResult Details(int id)
        {
            var player = _context.Players.Include(m => m.Team).SingleOrDefault(m => m.Id == id);

            return View(player);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var teams = _context.Teams.ToList();
            Player player = new Player()
            {
                Teams = teams
            };
            return View(player);
        }
        [HttpPost]
        public ActionResult Create(Player player)
        {
            if(player.Id == 0)
            {
                _context.Players.Add(player);
            }
            else
            {
                var playerInDB = _context.Players.Single(m => m.Id == player.Id);
                playerInDB.FirstName = player.FirstName;
                playerInDB.LastName = player.LastName;
                playerInDB.TeamId = player.TeamId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Players");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var player = _context.Players.SingleOrDefault(m => m.Id == id);
            player.Teams = _context.Teams.ToList();
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }
        [HttpPost]
        public ActionResult Edit(Player player)
        {
            var playerInDB = _context.Players.Single(m => m.Id == player.Id);
            playerInDB.FirstName = player.FirstName;
            playerInDB.LastName = player.LastName;
            playerInDB.TeamId = player.TeamId;
            playerInDB.Teams = _context.Teams.ToList();
            _context.SaveChanges();
            return RedirectToAction("Index", "Players");
        }
        public ActionResult Delete(int id)
        {
            var player = _context.Players.SingleOrDefault(m => m.Id == id);
            _context.Players.Remove(player);
            _context.SaveChanges();
            var players = _context.Players.Include(m => m.Team).ToList();
            return View("Index", players);
        }
        */
    }
}