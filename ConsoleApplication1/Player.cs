using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class Player
    {
        string pname; //player name
        int pcHealth; //current health
        int pmHealth; //max health (for display purposes)
        string pStatus; //alive/dead
        int pcWeapon; //what weapon do we have
        int currentLevel; //not displayed, but tracked
        int score; //not displayed, but tracked

        //cleaner getters/setters than enemy class

        public string name { get { return pname; } set { pname = value; } }
        public int currentHealth { get { return pcHealth; } set { pcHealth = value; } }
        public int maxHealth { get { return pmHealth; } set { pmHealth = value; } }
        public string status { get { return pStatus; } set { pStatus = value; } }
        public int currentWeapon { get { return pcWeapon; } set { pcWeapon = value; } }
        public int pLevel { get { return currentLevel; } set { currentLevel = value; } }
        public int pScore { get { return score; } set { score = value; } }

        public Player() //default constructor with default values.
        {
            name = "UNKNOWN"; //player name is not set at the beginning of the story, but can be set later
            currentHealth = 26; //feeling pretty healthy
            maxHealth = 26;
            currentWeapon = 0; //no weapon
            status = "Alive"; //not dead
            pLevel = 1;
            pScore = 0;
        }

        public Player(string pname, int chealth, int mhealth, string pstatus, int cweapon)
        { //never actually used, but I know how to do it
            pname = name;
            chealth = currentHealth;
            mhealth = maxHealth;
            pstatus = status;
            cweapon = currentWeapon;
        }

        public void changePlayerWeapon(int newWeapon)
        {
            currentWeapon = newWeapon; //updates the player weapon when they pick up an item
        }

        public void changePlayerName()
        {
            name = Console.ReadLine(); //changes the player's name
        }

        public void fullHeal()
        {
            currentHealth = maxHealth; //heals the player
        }
    }
}
