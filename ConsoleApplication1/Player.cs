using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class Player
    {
        string pname;
        int pcHealth;
        int pmHealth;
        string pStatus;
        int pcWeapon;

        public string name { get { return pname; } set { pname = value; } }
        public int currentHealth { get { return pcHealth; } set { pcHealth = value; } }
        public int maxHealth { get { return pmHealth; } set { pmHealth = value; } }
        public string status { get { return pStatus; } set { pStatus = value; } }
        public int currentWeapon { get { return pcWeapon; } set { pcWeapon = value; } }

        public Player() //default constructor with default values.
        {
            name = "default";
            currentHealth = 10; //feeling pretty healthy
            maxHealth = 10;
            currentWeapon = 0; //no weapon
            status = "Alive"; //not dead
        }

        public void playerDamage(int damage)
        {
            currentHealth -= damage;
        }

        public void changePlayerWeapon(int newWeapon)
        {
            currentWeapon = newWeapon;
            Console.WriteLine(currentWeapon);
            Console.WriteLine(newWeapon);
        }
        /*
        string p1Name;
        int currentHealth;
        int maxHealth;
        int armorType; //0 for none, 1 for light, 2 for medium, 3 for heavy
        int missingBodyParts; //0 = no damage reduction, 1 = 20% damage reduction, 2 = 50% damage reduction, 3 = 80% damage reduction, 4 = you can't move
        int currentWeapon; //0 = none, 1 = Knight's Blade, 2 = Fencing Foil, 3 = Claymore, 4 = Falchion
        int weaponDurability;
        bool playerAlive;

        

        public Player(string playerName, int cHealth, int mHealth, int aType, int wType, int mBodyParts, int durability, bool notDead)
        {
            if (playerName != "Miguel" && playerName != "miguel" )
            {
                p1Name = playerName;
            }
            else
            {
                p1Name = "still not Miguel"; //still banned
            }

            currentHealth = cHealth;
            maxHealth = mHealth;
            armorType = aType;
            missingBodyParts = mBodyParts;
            currentWeapon = wType;
            weaponDurability = durability;
            playerAlive = notDead;
            
    }*/
    }
}
