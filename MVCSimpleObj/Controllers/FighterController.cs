using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCSimpleObj.Models;

namespace MVCSimpleObj.Controllers
{
    public class FighterController : Controller
    {
        List<IFighter> fighters;
        IFighter player;
        FighterEnum.FighterTypes currentPlayerType;
        public FighterController()
        {
            fighters = new List<IFighter>()
            {
                new Swordsman(),
                new Archer(),
                new GunSlinger(),
                new Mage()
            };

            player = new Swordsman(true,"player",50);
            currentPlayerType = player.FighterType;
            fighters.Add(player);
            
        }
        // GET: Fighter
        public ActionResult Index()
        { 
            return View(fighters);
        }

        // GET: Fighter/Details/5
        public ActionResult Details(string name)
        {
            return View(fighters.Where(n => n.Name == name).FirstOrDefault());
        }

        public ActionResult Attack(string name)
        {
            //get the enemy fighter object
            IFighter enemy= fighters.Where(n => n.Name == name).FirstOrDefault();
            //decrease the health of the enemy
            enemy.DecreaseHealth(player.AttackAmount-enemy.DefenseAmount);

            return RedirectToAction(nameof(Index));
        }

        // GET: Fighter/Edit/5
        public ActionResult Edit(string name)
        {
            IFighter fighter = fighters.Where(n => n.Name == name).FirstOrDefault();
            PopulateFighterTypeList();
            if (fighter.CanEdit)
                return View(fighter);
            else
                return RedirectToAction(nameof(Index));
        }

        // POST: Fighter/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if(player.FighterType!=currentPlayerType)
                {
                    currentPlayerType = player.FighterType;
                    switch(player.FighterType)
                    {
                        case FighterEnum.FighterTypes.Archer:
                            player = new Archer(true, "player",player.Health);
                            break;
                        case FighterEnum.FighterTypes.Gunslinger:
                            player = new GunSlinger(true, "player", player.Health);
                            break;
                        case FighterEnum.FighterTypes.Mage:
                            player = new Mage(true, "player", player.Health);
                            break;
                        case FighterEnum.FighterTypes.Swordsman:
                            player = new Swordsman(true, "player", player.Health);
                            break;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        void PopulateFighterTypeList()
        {
            List<FighterEnum.FighterTypes> types = new List<FighterEnum.FighterTypes>()
            {
                FighterEnum.FighterTypes.Archer,
                FighterEnum.FighterTypes.Gunslinger,
                FighterEnum.FighterTypes.Mage,
                FighterEnum.FighterTypes.Swordsman
            };
            ViewBag.FighterType = new SelectList(types, player.FighterType);
        }
    }
}