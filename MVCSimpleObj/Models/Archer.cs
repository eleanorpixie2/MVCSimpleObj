using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public class Archer : IFighter
    {
        public FighterEnum.FighterTypes FighterType { get; set; }

        public int AttackAmount { get; set; }

        public int DefenseAmount { get; set; }

        public string EquippedWeapon { get; set; }

        public int Health { get; set; }

        public string Name { get; set; }

        public bool CanEdit { get; set; }

        public Archer():this(false,"npcArcher",50){}

        public Archer(bool _canEdit,string _name, int _health) 
        {
            CanEdit = _canEdit;
            Name = _name;
            FighterType = FighterEnum.FighterTypes.Archer;
            AttackAmount = 6;
            DefenseAmount = 3;
            Health = _health;
            EquippedWeapon = "Long Bow";
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
