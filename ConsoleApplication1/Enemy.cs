using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBTextBasedRPG
{
    class Enemy
    {
        //type // name // value
        string name; //enemy name
        int weaponDMG; //attack (damage)
        bool isAlive; //notDead (mostly unusued)
        string weaponName; //weapon (type)
        int enemyHealth; //enemy health

        // getter and setter //accessor and mutator
        public string Name { get { return name; } set { name = value; } }
        public int wDMG { get { return weaponDMG; } set { weaponDMG = value; } }
        public bool stillAlive { get { return isAlive; } set { isAlive = value; } }
        public string wName { get { return weaponName; } set { weaponName = value; } }
        public int eHealth { get { return enemyHealth; } set {  enemyHealth = value; } }

        public Enemy() //default constructor for default enemy
        {
            Name = "Corpse";
            wDMG = 3;
            stillAlive = true;
            wName = "fingernails";
            eHealth = 10;
        }

        public Enemy(string enemyName, int weapondamage, bool alive, string weaponname, int enemyH)
        { //secondary constructor for a non pre defined enemy (used for final boss)
            Name = enemyName;
            wDMG = weapondamage;
            stillAlive = alive;
            wName = weaponname;
            eHealth = enemyH;
        }
    }
}
