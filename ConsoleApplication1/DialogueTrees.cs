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

        public static int nextDialogue(int tracking, Player PlayerOne)
        {
            string WhereNext;
            switch (tracking)
            {
                case 1:
                    opening(); //calls the first opening
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
                    badEnding();
                    tracking = 0;
                    break;
                case 3:
                    theDoor();
                    tracking = 4;
                    break;
                case 4:
                    theTown();
                    WhereNext = NumChoice(4);
                        switch (WhereNext)
                        {
                            case "1":
                                tracking = 5;
                                break;
                            case "2":
                                //not yet added
                                break;
                            case "3":
                                //not yet added
                                break;
                            case "4":
                                //not yet added
                                break;
                            default:
                                Console.WriteLine("Super Error. Back to Start.");
                                tracking = 1;
                                break;
                        }
                    break;
                case 5:
                    youRegretYourDecision();
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
                    notAllBad();
                    PlayerOne.changePlayerWeapon(1);
                    tracking = 7;
                    break;
                case 7:
                    ewGross();
                    tracking = 8;
                    break;
                case 8:
                    //iceRoomCombat();
                    break;
                default:
                    Console.WriteLine("I have no idea where we are.");
                    Console.ReadLine();
                    break;
            }
            return tracking;
        }

        private static void opening() //tracker 1
        {
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
        }

        private static void badEnding() //tracker 2
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

        private static void theDoor() //tracker 3
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
            dialogueChoice = NumChoice(2); //choice is ignored intentionally to confuse the player and amuse the dev (me)
            Console.WriteLine("After careful consideration, you quickly come to the conclusion that the mountain is too far away for you to reach.");
            Console.WriteLine("You begin your walk up the hill.");
            Console.ReadLine();
        }

        private static void theTown() //tracker 4
        {
            Console.WriteLine("As you crest the ridge, you peer down the hill to see a few man made structures of some kind next to a river.");
            Console.WriteLine("You don't spot any people, but with renewed determination you make your way down the hill.");
            Console.ReadLine();
            Console.WriteLine("As you approach the buildings, you call out, but no one answers.");
            Console.WriteLine("There are three main buildings: The first is a large, solid looking structure with two doors.");
            Console.WriteLine("The second building appears to have been a house in days past, but it has fallen into disrepair.");
            Console.WriteLine("The roof has caved in and the door is missing entirely.");
            Console.WriteLine("The final building is much smaller than the others, and appears to be more of a shed.");
            Console.WriteLine("A solid-looking bar holds the doors shut, but it might be possible to squeeze through an open window.");
            Console.WriteLine("Alternatively, you could continue on your way towards the river.");
            Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("WHERE WILL YOU GO?");
            Console.WriteLine("1. Large Building");
            Console.WriteLine("2. Destroyed House");
            Console.WriteLine("3. Locked Shed");
            Console.WriteLine("4. The River");
        }

        private static void youRegretYourDecision() //tracker 5
        {
            Console.WriteLine("You meander towards the largest building, figuring that if people are anywhere, they're hiding in there.");
            Console.WriteLine("The first door you try is locked, but the second is slightly ajar.");
            Console.WriteLine("Slipping inside, you are instantly chilled. The room is freezing!");
            Console.ReadLine();
            Console.WriteLine("It appears to be a meat storage room of some kind. Chunks of meat hanging on meathooks surround you.");
            Console.WriteLine("Upon closer inspection, you draw back in revulsion! The meat in this building... comes from people!");
            Console.WriteLine("Instantly on your guard, you spin around to the exit, and are relieved to see that it remains open.");
            Console.WriteLine("");
            Console.WriteLine("WHAT WILL YOU DO?");
            Console.WriteLine("1. Continue to explore");
            Console.WriteLine("2. Leave the building");
        }

        private static void notAllBad() //tracker 6
        {
            Player PlayerOne = new Player();
            Console.WriteLine("With a deep breath to steady yourself, you press forward further into the slaughterhouse.");
            Console.WriteLine("Coming across a meathook on the floor, you eagerly pick it up and clutch it tightly.");
            Console.WriteLine("Its considerable weight reassures you, and you calm slightly.");
            Console.WriteLine("[YOU NOW HAVE A MEATHOOK]");
            Console.ReadLine();
        }
        private static void ewGross() //tracker 7
        {
            Console.WriteLine("Pressing forward, you find some strips of 'jerky', but are too disgusted to touch them.");
            Console.WriteLine("When a thorough explanation reveals nothing more, you return to the enterance.");
            Console.ReadLine();
        }
    }
}
