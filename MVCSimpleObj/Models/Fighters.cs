using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSimpleObj.Models
{
    public class Fighters
    {
        //Enemy fighters
        private static IFighter enemySword = new Swordsman();
        private static IFighter enemyArcher = new Archer();
        private static IFighter enemyGun = new GunSlinger();
        private static IFighter enemyMage = new Mage();
        //player
        private static IFighter player = new Swordsman(true, "player", 75);

        //Create a list of fighters
        public static List<IFighter> fighters=new List<IFighter>()
        {
            enemySword,
            enemyArcher,
            enemyGun,
            enemyMage,
            player
        };
        //The current player type
        public static FighterEnum.FighterTypes currentPlayerType=fighters.Where(n => n.Name == player.Name).FirstOrDefault().FighterType;

        public Fighters()
        {

        }

        //attack an enemy
        public static void Attack(IFighter enemy)
        {
            if (fighters.Where(n => n == enemy).FirstOrDefault().Health > 0)
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                IFighter player = fighters.Where(n => n.Name == "player").FirstOrDefault();
                //decrease the health of the enemy
                fighters.Where(n => n == enemy).FirstOrDefault().DecreaseHealth(player.AttackAmount - fighters.Where(n => n == enemy).FirstOrDefault().DefenseAmount);

                //attack the player back
                int enemyRetaliation = rnd.Next(1, fighters.Where(n => n == enemy).FirstOrDefault().AttackAmount);
                int hitAmount = enemyRetaliation - player.DefenseAmount;
                if (hitAmount > 0)
                    player.DecreaseHealth(hitAmount);
            }
        }
    }
}
