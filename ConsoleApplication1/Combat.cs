using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class Combat
    {

        public static void playerDamage(int damage)
        {
            Player player1 = new Player();
            player1.currentHealth -= damage;
        }
    }
}
