using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public interface IFighter
    {
        //Fighter type
        FighterEnum.FighterTypes FighterType { get; set; }
        //the amount that the fighter can attack
        int AttackAmount { get; }
        //the amount that the fighter can defend
        int DefenseAmount { get; }
        //the health amount that the fighter has
        int Health { get; }
        //the weapon(s) that the fighter
        string EquippedWeapon { get; set; }
        //the id/name of the player
        string Name { get; }
        //whether the player type can be edited
        bool CanEdit { get; }
        //decreases the player's health
        void DecreaseHealth(int amount);
    }
}
