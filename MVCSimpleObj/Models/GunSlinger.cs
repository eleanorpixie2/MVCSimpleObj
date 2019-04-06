using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public class GunSlinger : IFighter
    {
        //fighter type
        public FighterEnum.FighterTypes FighterType { get; set; }

        //the amount that the fighter can attack
        public int AttackAmount { get; set; }

        //the amount that the fighter can defend
        public int DefenseAmount { get; set; }

        //the weapon(s) that the fighter has
        public string EquippedWeapon { get; set; }

        //the health that the player has
        public int Health { get; set; }

        //whether the player type can be edited
        public bool CanEdit { get; set; }

        //id/name of the fighter
        public string Name { get; set; }

        //the default constructor
        public GunSlinger():this(false,"npcSlinger",50){}

        //constructor
        public GunSlinger(bool _canEdit,string _name, int _health)
        {
            CanEdit = _canEdit;
            Name = _name;
            FighterType = FighterEnum.FighterTypes.Gunslinger;
            AttackAmount = 7;
            DefenseAmount = 2;
            Health = _health;
            EquippedWeapon = "Semi-Automatic Rifle and a 9mm pistol";
        }

        //decrease the health amount
        public void DecreaseHealth(int amount)
        {
            if (Health > 0)
                Health -= amount;
            if(Health<=0)
                Health = 0;
        }
    }
}
