using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public class Mage : IFighter
    {
        //the fighter type
        public FighterEnum.FighterTypes FighterType { get; set; }

        //the amount that the fighter can attack
        public int AttackAmount { get; set; }

        //the amount that the fighter can defend
        public int DefenseAmount { get; set; }

        //the weapon that the fighter has
        public string EquippedWeapon { get; set; }

        //the health that the fighter
        public int Health { get; set; }

        //whether the player type can be edited
        public bool CanEdit { get; set; }

        //id/name of the character
        public string Name { get; set; }

        //constructor
        public Mage():this(false, "npcMage",50){}

        public Mage(bool _canEdit, string _name, int _health) 
        {
            CanEdit = _canEdit;
            Name = _name;
            FighterType = FighterEnum.FighterTypes.Mage;
            AttackAmount = 5;
            DefenseAmount = 2;
            Health = _health;
            EquippedWeapon = "Magic Staff and Potions";
        }
        
        //decrease the health of the player
        public void DecreaseHealth(int amount)
        {
            if (Health > 0)
                Health -= amount;
            if (Health <= 0)
                Health = 0;
        }
    }
}
