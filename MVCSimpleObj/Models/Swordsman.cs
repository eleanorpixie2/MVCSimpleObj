using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public class Swordsman : IFighter
    {
        //fighter type
        public FighterEnum.FighterTypes FighterType { get; set; }

        //the amount that the fighter can attack
        public int AttackAmount { get; set; }

        //the amount that the fighter can defend
        public int DefenseAmount { get; set; }

        //the weapon(s) that the fighter has
        public string EquippedWeapon { get; set; }

        //The health that the player has
        public int Health { get; set; }

        //whether the player type can be edited
        public bool CanEdit { get; set; }

        //id/name of the player
        public string Name { get; set; }

        //default constructor
        public Swordsman() : this(false,"npcSword",50){}

        //constructor
        public Swordsman(bool _canEdit,string _name,int _health)
        {
            CanEdit = _canEdit;
            Name = _name;
            FighterType = FighterEnum.FighterTypes.Swordsman;
            AttackAmount = 5;
            DefenseAmount = 3;
            Health = _health;
            EquippedWeapon = "Broad Sword";
        }
        //decrease the player's health
        public void DecreaseHealth(int amount)
        {
            if (Health > 0)
                Health -= amount;
            if (Health <= 0)
                Health = 0;
        }
    }
}
