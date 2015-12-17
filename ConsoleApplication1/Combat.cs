using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class Combat
    {

        public static string playerDamage(Player player1, int damage) //deals damage to player
        {
            player1.currentHealth -= damage;
            if (player1.currentHealth <= 0)
            {
                player1.status = "Dead"; //if the player is dead... the player is dead
            }
            return player1.status;
        }

        public static void enemyAttack(Enemy attackingEnemy, Player playerUNO) //enemy attacks
        {
            Console.WriteLine("The {0} strikes you with its {1}!", attackingEnemy.Name, attackingEnemy.wName);
            Console.WriteLine("You take {0} damage!", attackingEnemy.wDMG); //textual representation of the attack
            playerDamage(playerUNO, attackingEnemy.wDMG); //actual outcome of the attack
        }

        public static bool enemyDamage (Enemy attackingEnemy, int damage) //deals damage to the enemy
        {
            attackingEnemy.eHealth -= damage;
            if (attackingEnemy.eHealth <= 0)
            {
                attackingEnemy.stillAlive = false; //if the enemy is dead
            }
            return attackingEnemy.stillAlive;
        }

        public static void playerAttack(Player PlayerUNO, Enemy EnemyBeingAttacked) //depends on your weapon
        {
            if (PlayerUNO.currentWeapon == 0)
            {
                Console.WriteLine("You slap feebly at the {0}!", EnemyBeingAttacked.Name); //not a great attack. find a meathook
                Console.WriteLine("If only you had a weapon of some kind!");
                Console.WriteLine("You deal a mere 2 damage!");
                enemyDamage(EnemyBeingAttacked, 2);
            }
            else //there is only one weapon
            {
                Console.WriteLine("You smash the {0} with your Meathook!", EnemyBeingAttacked.Name);
                Console.WriteLine("You deal 6 damage to the {0}!", EnemyBeingAttacked.Name);
                enemyDamage(EnemyBeingAttacked, 6);
            }
        }

        public static int Battle(Enemy attackingEnemy, Player playerUNO, int nextLoc, int tracking) //combat loop
        {

            do
            {
                Console.Clear(); //clear screen, status update
                DialogueTrees.printStatus(playerUNO.name, playerUNO.status, playerUNO.currentHealth, playerUNO.maxHealth, playerUNO.currentWeapon); 
                playerAttack(playerUNO, attackingEnemy); //first the player attacks
                Console.WriteLine();
                if (attackingEnemy.eHealth > 0) //if the enemy is alive, they counter attack
                {
                    enemyAttack(attackingEnemy, playerUNO);
                }
                Console.ReadLine(); //waits to let you see it
            }
            while (playerUNO.currentHealth > 0 && attackingEnemy.eHealth > 0); //if no one has died, continue the battle

                if (playerUNO.currentHealth <= 0) //if you died
            {
                Console.Clear();
                DialogueTrees.printStatus(playerUNO.name, playerUNO.status, playerUNO.currentHealth, playerUNO.maxHealth, playerUNO.currentWeapon);
                Console.WriteLine("You have been slain! Your adventure ends here."); //sad day
                Console.ReadLine();
                tracking = 0; //ends the game
            }
            else if (attackingEnemy.eHealth <= 0)
            {
                playerUNO.pLevel++; //level up!
                playerUNO.pScore += 200; //score up!
                Console.WriteLine("The {0} has been slain! You are victorious!", attackingEnemy.Name); //nice job!
                Console.ReadLine();
                tracking = nextLoc; //nextLoc is passed in to the battle function so it knows where to next if you win
            }
            return tracking; //lets it know where to go next
        }
    }
}
