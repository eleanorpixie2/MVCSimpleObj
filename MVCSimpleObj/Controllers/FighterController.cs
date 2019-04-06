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

        // GET: Fighter
        public ActionResult Index()
        { 
            return View(Fighters.fighters);
        }

        // GET: Fighter/Details/5
        public ActionResult Details(string name)
        {
            return View(Fighters.fighters.Where(n => n.Name == name).FirstOrDefault());
        }

        //attack action
        public ActionResult Attack(string name)
        {
            Fighters.Attack(Fighters.fighters.Where(n => n.Name == name).FirstOrDefault());          

            return RedirectToAction(nameof(Index));
        }

        // GET: Fighter/Edit/5
        public ActionResult Edit(string name)
        {
            //populate the visual list
            PopulateFighterTypeList();
            //if the fighter can be edited then call the edit view other wise go back to index
            if (Fighters.fighters.Where(n => n.Name == name).FirstOrDefault().CanEdit)
                return View(Fighters.fighters.Where(n => n.Name == name).FirstOrDefault());
            else
                return RedirectToAction(nameof(Index));
        }

        // POST: Fighter/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            int index = Fighters.fighters.FindIndex(f => f.Name == "player");
            string selectedValue = Request.Form["FighterType"].ToString();
            //Fighters.fighters[index].FighterType = FighterEnum.FighterTypes.Archer;
            try
            {
                //change the type of fighter that the player is, but keep the health the same
                if(selectedValue != Fighters.currentPlayerType.ToString())
                {
                    switch(selectedValue)
                    {
                        case "Archer":
                            Fighters.fighters[index] = new Archer(true, "player", Fighters.fighters[index].Health);
                            Fighters.currentPlayerType = FighterEnum.FighterTypes.Archer;
                            break;
                        case "Gunslinger":
                            Fighters.fighters[index] = new GunSlinger(true, "player", Fighters.fighters[index].Health);
                            Fighters.currentPlayerType = FighterEnum.FighterTypes.Gunslinger;
                            break;
                        case "Mage":
                            Fighters.fighters[index] = new Mage(true, "player", Fighters.fighters[index].Health);
                            Fighters.currentPlayerType = FighterEnum.FighterTypes.Mage;
                            break;
                        case "Swordsman":
                            Fighters.fighters[index] = new Swordsman(true, "player", Fighters.fighters[index].Health);
                            Fighters.currentPlayerType = FighterEnum.FighterTypes.Swordsman;
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

        //populate the list that will be shown when edit is called
        void PopulateFighterTypeList()
        {
            List<FighterEnum.FighterTypes> types = new List<FighterEnum.FighterTypes>()
            {
                FighterEnum.FighterTypes.Archer,
                FighterEnum.FighterTypes.Gunslinger,
                FighterEnum.FighterTypes.Mage,
                FighterEnum.FighterTypes.Swordsman
            };
            ViewBag.FighterType = types;
        }
    }
}