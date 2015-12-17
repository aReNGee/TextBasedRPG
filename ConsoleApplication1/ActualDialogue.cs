using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class ActualDialogue //class that contains all writeline statements used to display dialogue and choices
    {
        
        public static void opening() //tracker 1
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

        public static void badEnding() //tracker 2
        {
            Console.WriteLine("Fearing the light, you retreat into the darkness.");
            Console.ReadLine();
            Console.WriteLine("You walk for minutes that turn to hours, and hours that turn to days.");
            Console.WriteLine("The nothingness stretches out before you in every direction.");
            Console.WriteLine("You begin to wonder if there was even a time before this great emptiness...");
            Console.WriteLine("Slowly, during your timeless walk, you too fade away to nothing.");
            Console.WriteLine("");
            Console.WriteLine("BAD END! Try again.");
            Console.ReadLine();
        }

        public static void theDoor() //tracker 3
        {
            string dialogueChoice;
            Console.WriteLine("The door creaks open and light pours in, dazzling you.");
            Console.WriteLine("When your vision returns, you see that the light makes barely a dent in the unending blackness.");
            Console.WriteLine("Fearful now, you step hastily through the door lest it suddenly close again.");
            Console.ReadLine();
            Console.WriteLine("Your stomach lurches as you step well below where the floor should be.");
            Console.WriteLine("There's no floor! You flail your arms to try to arrest your passage, but it's too late.");
            Console.ReadLine();
            Console.WriteLine("Blinded by the light as you exit the door, you fall several feet to the ground, landing heavily.");
            Console.WriteLine("When you look up again, the door is gone.");
            Console.ReadLine();
            Console.WriteLine("Brushing yourself off, you survey your surroundings.");
            Console.WriteLine("To one side, off in the distance lies a great mountain with smoke drifting lazily around the peak.");
            Console.WriteLine("In the other direction, a small hill obscures your vision, but you can hear running water.");
            Console.WriteLine("");
            Console.WriteLine("WHICH WAY WILL YOU GO? (1 = Mountain, 2 = Hill)");
            dialogueChoice = DialogueTrees.NumChoice(2); //choice is ignored intentionally to confuse the player and amuse the dev (me)
            Console.WriteLine("After careful consideration, you quickly come to the conclusion that the mountain is too far away for you to reach.");
            Console.WriteLine("You begin your walk up the hill.");
            Console.ReadLine();
            Console.WriteLine("As you crest the ridge, you peer down the hill to see a few manmade structures of some kind next to a river.");
            Console.WriteLine("You don't spot any people, but with renewed determination you make your way down the hill.");
            Console.ReadLine();
        }

        public static void theTown() //tracker 4
        {
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

        public static void youRegretYourDecision() //tracker 5
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

        public static void notAllBad() //tracker 6
        {
            Player PlayerOne = new Player();
            Console.WriteLine("With a deep breath to steady yourself, you press forward further into the slaughterhouse.");
            Console.WriteLine("Coming across a meathook on the floor, you eagerly pick it up and clutch it tightly.");
            Console.WriteLine("Its considerable weight reassures you, and you calm slightly.");
            Console.WriteLine("[YOU NOW HAVE A MEATHOOK]");
            Console.ReadLine();
        }
        public static void ewGross() //tracker 7
        {
            Console.WriteLine("Pressing forward, you find some strips of 'jerky', but are too disgusted to touch them.");
            Console.WriteLine("When a thorough explanation reveals nothing more, you return to the entrance.");
            Console.ReadLine();
        }

        public static void perhapsNot() //tracker 9 part 1
        {
            Console.WriteLine("You begin to make your way away from the town and towards the river.");
            Console.WriteLine("As you begin to walk, you realize that you are alone, unarmed and unarmored.");
            Console.WriteLine("It would be logical to search for weapons before progressing any further.");
            Console.WriteLine("You return to the town to begin your search.");
            Console.ReadLine();
        }

        public static string somethingStrange(Player Player1) //tracker 8
        {
            string dialogueChoice;
            int numchoices = 2;
            Console.WriteLine("As you return exit the door of the slaughterhouse, you are surprised and ");
            Console.WriteLine("relieved to see another living human standing before you.");
            Console.WriteLine("A closer look reveals the human is not living at all, merely well preserved.");
            Console.WriteLine("Your relief turns into fear as the corpse lets out a moan and shuffles towards you!");
            Console.WriteLine("");
            Console.WriteLine("What will you do?");
            Console.WriteLine("");
            Console.WriteLine("1. Ignore the corpse. It means you no harm.");
            Console.WriteLine("2. Attempt to communicate with the corpse.");
            if (Player1.currentWeapon == 1)
            {
                Console.WriteLine("3. MEATHOOK DIPLOMACY! (attack)");
                numchoices++; //you don't have as many choices if you don't have a weapon
            }
            dialogueChoice = DialogueTrees.NumChoice(numchoices);
            return dialogueChoice;
        }

        public static void destroyedHouse() //tracker 12
        {
            Console.WriteLine("You cautiously enter the desiccated house, to find the interior of the house looking no better than the exterior.");
            Console.WriteLine("However, you are pleasantly surprised to find a small shrine has been set up inside.");
            Console.WriteLine("A small plaque in front of the shrine has the words 'Declare Yourself'");
            Console.WriteLine("(Declare yourself by entering your name)");
        }

        public static void Refreshed() //tracker 13
        {
            Console.WriteLine("After uttering your name, a tingle runs down your spine and you surge");
            Console.WriteLine("with newfound vitality.");
            Console.WriteLine("Thanking whoever or whatever answered your prayer, you return to the town.");
            Console.WriteLine("");
            Console.WriteLine("[YOUR HIT POINTS HAVE BEEN FULLY RESTORED]");
            Console.ReadLine();
        }

        public static void LockedShed() //tracker 14
        {
            Console.WriteLine("You walk to the shed and rattle the bar holding the door shut, only to find it holds fast.");
            Console.WriteLine("You examine the window, but it is out of your reach and filled with glass shards.");
            Console.WriteLine("Unable to enter the shed, you return to the town.");
            Console.ReadLine();
        }

        public static int stabthezombie() //tracker 11a
        {
            Console.WriteLine("Steeling yourself for what must be done, you ready your meathook.");
            Random rnd = new Random();
            int result = rnd.Next(1, 3);//returns a random number between 1 and 2
            return result;
        }

        public static void BigStab() //tracker 11b
        {
            Console.WriteLine("Your meathook smashes the corpse's head, dealing 12 damage!");
            Console.WriteLine("The corpse's head comes free of the body, and the corpse collapses.");
            Console.WriteLine("You leap back in horror and disgust as the corpse writhes for a moment before subsiding.");
            Console.WriteLine("Glad that the sordid deed is done, you return to the town.");
            Console.ReadLine();
        }

        public static void LittleStab() //tracker 11c
        {
            Console.WriteLine("Your meathook glances off the corpse's chest, dealing 6 damage!");
            Console.WriteLine("The corpse falls back and lets out a moan, but is soon shambling forward once again.");
        }

        public static void theRiver() //tracker 9
        {
            Console.WriteLine("You can feel your purpose finally becoming clear as you approach the river.");
            Console.WriteLine("An enormous Kraken lies dying upon the shore.");
            Console.WriteLine("You have been sent to put this great beast out of its misery.");
            Console.WriteLine("You clutch your Meathook tightly and prepare to swing, but are forced to jump back as the pain-crazed");
            Console.WriteLine("Kraken flails his tentacles at you.");
            Console.WriteLine("He won't go down without a fight!");
            Console.ReadLine();
        }

        public static void DeadKraken(int level, int score) //tracker 16
        {
            Console.WriteLine("The Kraken trashes once more in its death throes, then finally subsides.");
            Console.WriteLine("You toss your gory Meathook aside and sadly survey the wreckage of this once proud creature.");
            Console.WriteLine("Your melancholy subsides as you feel yourself begin to disapear.");
            Console.WriteLine("Your job complete, you're returning to whence you came.");
            Console.WriteLine();
            Console.WriteLine("Congratulations! You have beaten the game.");
            Console.WriteLine("You were level {0} and had a score of {1}.", level, score);
            Console.ReadLine();
        }

    }
}
