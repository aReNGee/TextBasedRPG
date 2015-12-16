using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class Combat
    {

        public static string playerDamage(Player player1, int damage) //deal damage to player
        {
            player1.currentHealth -= damage;
            if (player1.currentHealth <= 0)
            {
                player1.status = "Dead";
            }
            return player1.status;
        }

        public static void enemyAttack(Enemy attackingEnemy, Player playerUNO) //enemyAttack
        {
            Console.WriteLine("The {0} strikes you with its {1}!", attackingEnemy.Name, attackingEnemy.wName);
            Console.WriteLine("You take {0} damage!", attackingEnemy.wDMG);
            playerDamage(playerUNO, attackingEnemy.wDMG);
        }

        public static bool enemyDamage (Enemy attackingEnemy, int damage)
        {
            attackingEnemy.eHealth -= damage;
            if (attackingEnemy.eHealth <= 0)
            {
                attackingEnemy.stillAlive = false;
            }
            return attackingEnemy.stillAlive;
        }

        public static void playerAttack(Player PlayerUNO, Enemy EnemyBeingAttacked)
        {
            if (PlayerUNO.currentWeapon == 0)
            {
                Console.WriteLine("You slap feebly at the {0}!", EnemyBeingAttacked.Name);
                Console.WriteLine("If only you had a weapon of some kind!");
                Console.WriteLine("You deal a mere 2 damage!");
                enemyDamage(EnemyBeingAttacked, 2);
            }
            else
            {
                Console.WriteLine("You smash the {0} with your Meathook!", EnemyBeingAttacked.Name);
                Console.WriteLine("You deal 6 damage to the {0}!", EnemyBeingAttacked.Name);
                enemyDamage(EnemyBeingAttacked, 6);
            }
        }

        public static int Battle(Enemy attackingEnemy, Player playerUNO, int nextLoc, int tracking)
        {

            do
            {
                Console.Clear();
                DialogueTrees.printStatus(playerUNO.name, playerUNO.status, playerUNO.currentHealth, playerUNO.maxHealth, playerUNO.currentWeapon);
                playerAttack(playerUNO, attackingEnemy);
                Console.WriteLine();
                if (attackingEnemy.eHealth > 0)
                {
                    enemyAttack(attackingEnemy, playerUNO);
                }
                //for debug
                //Console.WriteLine(attackingEnemy.eHealth);
                Console.ReadLine();
            }
            while (playerUNO.currentHealth > 0 && attackingEnemy.eHealth > 0);

                if (playerUNO.currentHealth <= 0)
            {
                Console.Clear();
                DialogueTrees.printStatus(playerUNO.name, playerUNO.status, playerUNO.currentHealth, playerUNO.maxHealth, playerUNO.currentWeapon);
                Console.WriteLine("You have been slain! Your adventure ends here.");
                Console.ReadLine();
                tracking = 0;
            }
            else if (attackingEnemy.eHealth <= 0)
            {
                Console.WriteLine("The {0} has been slain! You are victorious!", attackingEnemy.Name);
                Console.ReadLine();
                tracking = nextLoc;
            }
            return tracking;
        }
    }
}
