using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1stats = new Player(); //constructor for player class
            bool WantsToPlay = false; //opens main game loop
            bool HasNotQuit = true; //avoids both loops, quits the game
            int tracker = 1; //used to determine where in a dialogue tree we are

            string playerChoice;

            DialogueTrees.printStatus(p1stats.name, p1stats.status, p1stats.currentHealth, p1stats.maxHealth, p1stats.currentWeapon);

            while (HasNotQuit == true && WantsToPlay == false) // game menu
            {
                    Console.WriteLine("Welcome to the main game menu.");
                    Console.WriteLine("Please enter one of the following options:");
                    Console.WriteLine("1. Play the Game");
                    Console.WriteLine("2. Quit");

                    playerChoice = DialogueTrees.NumChoice(2);

                    if (playerChoice == "1")
                    {
                        WantsToPlay = true;
                    }
                    else if (playerChoice == "2")
                    {
                        HasNotQuit = false;
                    }
                    else
                    {
                        Console.WriteLine("???");
                    }
            }

            while (WantsToPlay == true ) //main game loop
                {
                Console.Clear();
                DialogueTrees.printStatus(p1stats.name, p1stats.status, p1stats.currentHealth, p1stats.maxHealth, p1stats.currentWeapon); //status update
                tracker = DialogueTrees.nextDialogue(tracker, p1stats); //next dialogue code
                if (tracker == 0) //ending the game
                {
                    WantsToPlay = false;
                }
            }

        }
    }
}