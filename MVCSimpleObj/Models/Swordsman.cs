using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public class Swordsman : IFighter
    {
        [BindRequired]
        public FighterEnum.FighterTypes FighterType { get; set; }

        public int AttackAmount { get; set; }

        public int DefenseAmount { get; set; }

        public string EquippedWeapon { get; set; }

        [BindRequired]
        public int Health { get; set; }

        public bool CanEdit { get; set; }

        public string Name { get; set; }

        public Swordsman() : this(false,"npcSword",50){}

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
        public void DecreaseHealth(int amount)
        {
            if (Health > 0)
                Health -= amount;
            if (Health <= 0)
                Health = 0;
        }
    }
}
