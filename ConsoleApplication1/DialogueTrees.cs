using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class DialogueTrees
    {

        public static void printStatus(string pName, string pStatus, int cHealth, int mHealth, int cWeapon) //creates the status menu
        {                                                                                                   //updated every time the game loops
            Console.SetCursorPosition(2, 1);
            Console.Write("==============================");
            Console.SetCursorPosition(2, 2);
            Console.Write("| Name: {0}", pName);
            Console.SetCursorPosition(31, 2);
            Console.Write("|");
            Console.SetCursorPosition(2, 3);
            Console.Write("| Health: {0} / {1}", cHealth, mHealth);
            Console.SetCursorPosition(31, 3);
            Console.Write("|");
            Console.SetCursorPosition(2, 4);
            Console.Write("| Status: {0}", pStatus);
            Console.SetCursorPosition(31, 4);
            Console.Write("|");
            Console.SetCursorPosition(2, 5);

            switch (cWeapon) //converts cWeapons int value into strings to display
            {
                case 1:
                    Console.Write("| Weapon: Meathook");
                    break;
                default:
                    Console.Write("| Weapon: No weapon equiped");
                    break;
            }

            Console.SetCursorPosition(31, 5);
            Console.Write("|");
            Console.SetCursorPosition(2, 6);
            Console.Write("==============================");
            Console.SetCursorPosition(0, 7);
        }


        public static string NumChoice(int numChoices) //recursive choice selection. Used every time the player is given a choice
        {
            string choice;
            int choiceNum;
            bool legalNumber = false;

            do
            {
                choice = Console.ReadLine(); //reads player imput
                if (Int32.TryParse(choice, out choiceNum) && choiceNum <= numChoices && choiceNum >= 1) //checks if the player input a number between 1 and your entered number
                {
                    legalNumber = true; //lets the program contine
                }
                else
                {
                    legalNumber = false; //rereads input if the input was not within the bounds or an int value
                    Console.WriteLine("I'm sorry, I didn't understand. Please re-enter your choice.");
                }
            } while (legalNumber == false);


            return choice;
        }

        public static int nextDialogue(int tracking, Player PlayerOne, Enemy FirstEnemy, Enemy FinalBoss)
        {
            string WhereNext;   //used for choices
            switch (tracking)   //huge tree to see where we go in dialogue trees. Calls ActualDialogue for the writeline strings
            {                   //calls Combat when combat occurs. Bounces back to the main game loop to clear the screen and refresh player status
                case 1:
                    ActualDialogue.opening(); //calls the first opening
                    WhereNext = NumChoice(2); //first choice!
                    if (WhereNext == "1")
                    {
                        tracking = 3;
                    }
                    else
                    {
                        tracking = 2;
                    }
                    break;
                case 2:
                    ActualDialogue.badEnding(); //if you choose this... you just lose. Don't choose this.
                    tracking = 0;
                    break;
                case 3:
                    ActualDialogue.theDoor();
                    tracking = 4;
                    break;
                case 4:
                    ActualDialogue.theTown();
                    WhereNext = NumChoice(4); //lots of things to see!
                    switch (WhereNext)
                    {
                        case "1":
                            tracking = 5; //slaughterhouse
                            break;
                        case "2":
                            tracking = 12; //ruined house
                            break;
                        case "3":
                            tracking = 14; //locked shed
                            break;
                        case "4":
                            tracking = 9; //to the river
                            break;
                        default:
                            Console.WriteLine("Super Error. Back to Start.");
                            tracking = 1;
                            break;
                    }
                    break;
                case 5:
                    ActualDialogue.youRegretYourDecision();
                    WhereNext = NumChoice(2); //keep exploring, or run away?
                    if (WhereNext == "1")
                    {
                        tracking = 6;
                    }
                    else if (WhereNext == "2")
                    {
                        tracking = 8;
                    }
                    else
                    {
                        Console.WriteLine("Super Error. Back to Start.");
                        tracking = 1;
                    }
                    break;
                case 6:
                    ActualDialogue.notAllBad();
                    PlayerOne.changePlayerWeapon(1); //weapon found
                    tracking = 7;
                    break;
                case 7:
                    ActualDialogue.ewGross();
                    tracking = 8;
                    break;
                case 8:
                    if (FirstEnemy.eHealth > 0) //if you haven't killed the zombie yet
                    {
                        WhereNext = ActualDialogue.somethingStrange(PlayerOne);
                        switch (WhereNext) //how will you interact with the zombie
                        {
                            case "1":
                                tracking = 10; //ignore it
                                break;
                            case "2":
                                tracking = 10; //talk to it
                                break;
                            case "3":
                                tracking = 11; //attack it
                                break;
                            default:
                                Console.WriteLine("Super Error. Back to Start.");
                                tracking = 1;
                                break;
                        }
                    }
                    else
                    {
                        tracking = 4; //otherwise nothing happens (no endless parade of zombies)
                    }
                    break;
                case 9:
                    if (PlayerOne.currentWeapon != 0)
                    {
                        ActualDialogue.theRiver();
                        tracking = 15;
                    }
                    else
                    {
                        ActualDialogue.perhapsNot(); //if you don't have a weapon, you can't go to the river yet (you would die)
                        tracking = 4;
                    }
                    break;
                case 10:
                    //you get attacked
                    Console.WriteLine("Ignoring your quite reasonable attempts to be inclusive and open-minded, the corpse attacks!");
                    Combat.enemyAttack(FirstEnemy, PlayerOne);
                    Console.ReadLine();
                    tracking = Combat.Battle(FirstEnemy, PlayerOne, 4, tracking);
                    break;
                case 11:
                    //you attack the zombie
                    int zombiestab = ActualDialogue.stabthezombie();
                    if (zombiestab == 1)
                    {
                        ActualDialogue.BigStab();
                        Combat.enemyDamage(FirstEnemy, 12);
                        //zombie just dies
                        PlayerOne.pScore += 200;
                        PlayerOne.pLevel++; //score and level increase
                        tracking = 4;
                    }
                    else
                    {
                        ActualDialogue.LittleStab();
                        Combat.enemyDamage(FirstEnemy, 6);
                        Console.ReadLine();
                        //combat begins
                        tracking = Combat.Battle(FirstEnemy, PlayerOne, 4, tracking);
                    }
                    break;
                case 12:
                    ActualDialogue.destroyedHouse();
                    PlayerOne.changePlayerName(); //updates your player name!
                    PlayerOne.fullHeal(); //also heals you
                    tracking = 13;
                    break;
                case 13:
                    ActualDialogue.Refreshed();
                    tracking = 4;
                    break;
                case 14:
                    ActualDialogue.LockedShed(); //you can't get in
                    tracking = 4;
                    break;
                case 15:
                    tracking = Combat.Battle(FinalBoss, PlayerOne, 16, tracking); //the final battle!
                    break;
                case 16:
                    ActualDialogue.DeadKraken(PlayerOne.pLevel, PlayerOne.pScore); //you won! Congratulations!
                    tracking = 0;
                    break;
                default: //if you end up in a weird place (you shouldn't)
                    Console.WriteLine("I have no idea where we are.");
                    Console.ReadLine();
                    break;
            }
            return tracking; //returns the value so it knows where to go next
        }
    }
}
