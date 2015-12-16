using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class DialogueTrees
    {
        

        public static void printStatus(string pName, string pStatus, int cHealth, int mHealth, int cWeapon)
        {
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

            switch (cWeapon)
            {
                case 1:
                    Console.Write("| Weapon: Meathook");
                    break;
                default:
                    Console.Write("| Weapon: No weapon equiped");
                    break;
            }

             //needs to be updated with a string selector
            Console.SetCursorPosition(31, 5);
            Console.Write("|");
            Console.SetCursorPosition(2, 6);
            Console.Write("==============================");
            Console.SetCursorPosition(0, 7);
        }


        public static string NumChoice(int numChoices)
        {
            string choice;
            int choiceNum;
            bool legalNumber = false;

            do {
            choice = Console.ReadLine(); //reads player imput
            if (Int32.TryParse(choice, out choiceNum) && choiceNum <= numChoices && choiceNum >= 1) //checks if the player input a number between 1 and your entered number
            {
                legalNumber = true; //lets the program contine
            }
            else
            {
                legalNumber = false; //rereads input
                Console.WriteLine("I'm sorry, I didn't understand. Please re-enter your choice.");
            }
            } while (legalNumber == false);


            return choice;
        }

        public static int nextDialogue(int tracking, Player PlayerOne, Enemy FirstEnemy, Enemy FinalBoss)
        {   
            string WhereNext;
            switch (tracking)
            {
                case 1:
                    ActualDialogue.opening(); //calls the first opening
                    WhereNext = NumChoice(2);
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
                    ActualDialogue.badEnding();
                    tracking = 0;
                    break;
                case 3:
                    ActualDialogue.theDoor();
                    tracking = 4;
                    break;
                case 4:
                    ActualDialogue.theTown();
                    WhereNext = NumChoice(4);
                        switch (WhereNext)
                        {
                            case "1":
                                tracking = 5;
                                break;
                            case "2":
                                tracking = 12;
                                break;
                            case "3":
                            tracking = 14;
                            break;
                            case "4":
                                tracking = 9;
                                break;
                            default:
                                Console.WriteLine("Super Error. Back to Start.");
                                tracking = 1;
                                break;
                        }
                    break;
                case 5:
                    ActualDialogue.youRegretYourDecision();
                    WhereNext = NumChoice(2);
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
                    PlayerOne.changePlayerWeapon(1);
                    tracking = 7;
                    break;
                case 7:
                    ActualDialogue.ewGross();
                    tracking = 8;
                    break;
                case 8:
                    if (FirstEnemy.eHealth > 0)
                    {
                        WhereNext = ActualDialogue.somethingStrange(PlayerOne);
                        switch (WhereNext)
                        {
                            case "1":
                                tracking = 10;
                                break;
                            case "2":
                                tracking = 10;
                                break;
                            case "3":
                                tracking = 11;
                                break;
                            default:
                                Console.WriteLine("Super Error. Back to Start.");
                                tracking = 1;
                                break;
                        }
                    }
                    else
                    {
                        tracking = 4;
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
                        ActualDialogue.perhapsNot();
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
                        //zombie dies
                        tracking = 4;
                    }
                    else
                    {
                        ActualDialogue.LittleStab();
                        Combat.enemyDamage(FirstEnemy, 6);
                        //Combat.enemyAttack(FirstEnemy, PlayerOne);
                        Console.ReadLine();
                        //combat begins
                        tracking = Combat.Battle(FirstEnemy, PlayerOne, 4, tracking);
                    }
                    break;
                case 12:
                    ActualDialogue.destroyedHouse();
                    PlayerOne.changePlayerName();
                    PlayerOne.fullHeal();
                    tracking = 13;
                    break;
                case 13:
                    ActualDialogue.Refreshed();
                    tracking = 4;
                    break;
                case 14:
                    ActualDialogue.LockedShed();
                    tracking = 4;
                    break;
                case 15:
                    tracking = Combat.Battle(FinalBoss, PlayerOne, 16, tracking);
                    break;
                case 16:
                    ActualDialogue.DeadKraken();
                    tracking = 0;
                    break;
                default:
                    Console.WriteLine("I have no idea where we are.");
                    Console.ReadLine();
                    break;
            }
            return tracking;
        }
    }
}
