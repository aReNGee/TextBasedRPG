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
            Console.Write("| Weapon Num: {0}", cWeapon); //needs to be updated with a string selector
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

        public static int nextDialogue(int tracking, Player PlayerOne)
        {
            string WhereNext;
            switch (tracking)
            {
                case 1:
                    WhereNext = opening(); //calls the first opening
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
                    badEnding();
                    tracking = 0;
                    break;
                case 3:
                    theDoor();
                    tracking = 4;
                    break;
                default:
                    Console.WriteLine("I have no idea where we are.");
                    Console.ReadLine();
                    break;
            }
            
            //tracking++; //coded out for now
            return tracking;
        }

        private static string opening()
        {
            string dialogueChoice;
            Console.WriteLine("First, there was nothing.");
            Console.ReadLine();
            Console.WriteLine("Now, you are here.");
            Console.ReadLine();
            Console.WriteLine("From whence you came? No one knows.");
            Console.WriteLine("Where you are headed? Also a mystery.");
            Console.WriteLine("Upon your back lie shapeless robes, and behind you, only darkness.");
            Console.WriteLine("Ahead of you lies a door. Light seeps out from the around the edges.");
            Console.WriteLine("");
            Console.WriteLine("WILL YOU ENTER THE DOOR? (1 = Yes, 2 = No)");
            dialogueChoice = NumChoice(2);
            return dialogueChoice;
        }

        private static void badEnding()
        {
            Console.WriteLine("Fearing the light, you retreat into the darkness.");
            Console.ReadLine();
            Console.WriteLine("You walk for minutes that turn to hours, and hours that turn to days.");
            Console.WriteLine("The nothingness stretches out before you in every direction.");
            Console.WriteLine("You begin to wonder if there was even a time before this great emptiesness...");
            Console.WriteLine("Slowly, during your timeless walk, you too fade away to nothing.");
            Console.WriteLine("");
            Console.WriteLine("BAD END! Try again.");
            Console.ReadLine();
        }

        private static void theDoor()
        {
            string dialogueChoice;
            Console.WriteLine("The door creaks open and light pours in, dazzling you.");
            Console.WriteLine("When your vision returns, you see that the light makes barely a dent in the unending blackness.");
            Console.WriteLine("Fearful now, you step hastily through the door lest it suddenly close again.");
            Console.ReadLine();
            Console.WriteLine("Your stomache lurches as you step well below where the floor should be.");
            Console.WriteLine("There's no floor! You flail your arms to try to arrest your passage, but its too late.");
            Console.ReadLine();
            Console.WriteLine("Blinded by the light as you exit the door, you fall several feet to the ground, landing heavily.");
            Console.WriteLine("When you look up again, the door is gone.");
            Console.ReadLine();
            Console.WriteLine("Brushing yourself off, you survey your surroundings.");
            Console.WriteLine("To one side, off in the distance lies a great mountain with smoke drifting lazily around the peak.");
            Console.WriteLine("In the other direction, a small hill obscures your vision, but you can hear running water.");
            Console.WriteLine("");
            Console.WriteLine("WHICH WAY WILL YOU GO? (1 = Mountain, 2 = Hill)");
            dialogueChoice = NumChoice(2);
            Console.WriteLine("After careful consideration, you quickly come to the conclusion that the mountain is too far away for you to reach.");
            Console.WriteLine("You begin your walk up the hill.");
            Console.ReadLine();
        }
    }
}
