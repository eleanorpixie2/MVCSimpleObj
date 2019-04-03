using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public class GunSlinger : IFighter
    {
        public FighterEnum.FighterTypes FighterType { get; set; }

        public int AttackAmount { get; set; }

        public int DefenseAmount { get; set; }

        public string EquippedWeapon { get; set; }

        public int Health { get; set; }

        public bool CanEdit { get; set; }

        public string Name { get; set; }

        public GunSlinger():this(false,"npcSlinger",50){}

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

        public void DecreaseHealth(int amount)
        {
            if (Health > 0)
                Health -= amount;
            if(Health<=0)
                Health = 0;
        }
    }
}
