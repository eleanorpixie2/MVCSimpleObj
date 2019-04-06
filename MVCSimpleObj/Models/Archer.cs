using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public class Archer : IFighter
    {
        //Fighter type
        public FighterEnum.FighterTypes FighterType { get; set; }

        //the amount that the fighter can attack
        public int AttackAmount { get; set; }

        //the amount that the fighter can defense
        public int DefenseAmount { get; set; }

        //the weapon(s) that the fighter has
        public string EquippedWeapon { get; set; }

        //The health of the fighter
        public int Health { get; set; }

        //The id/name of the character
        public string Name { get; set; }

        //can edit/ change type
        public bool CanEdit { get; set; }

        //default constructor
        public Archer():this(false,"npcArcher",50){}

        //constructor that can set the can edit, id/name, health
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
        //decrease health
        public void DecreaseHealth(int amount)
        {
            if (Health > 0)
                Health -= amount;
            if (Health <= 0)
                Health = 0;
        }
    }
}
