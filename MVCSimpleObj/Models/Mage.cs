using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public class Mage : IFighter
    {
        public FighterEnum.FighterTypes FighterType { get; set; }

        public int AttackAmount { get; set; }

        public int DefenseAmount { get; set; }

        public string EquippedWeapon { get; set; }

        public int Health { get; set; }

        public bool CanEdit { get; set; }

        public string Name { get; set; }

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
        public void DecreaseHealth(int amount)
        {
            if (Health > 0)
                Health -= amount;
            if (Health <= 0)
                Health = 0;
        }
    }
}
