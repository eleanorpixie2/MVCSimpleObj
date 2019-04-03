using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public interface IFighter
    {
        FighterEnum.FighterTypes FighterType { get; set; }
        int AttackAmount { get; }
        int DefenseAmount { get; }
        int Health { get; }
        string EquippedWeapon { get; set; }
        string Name { get; }
        bool CanEdit { get; }
        void DecreaseHealth(int amount);
    }
}
