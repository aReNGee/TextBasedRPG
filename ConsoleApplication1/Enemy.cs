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
        string name;
        int weaponDMG;
        bool isAlive;
        string weaponName;
        int enemyHealth;

        // getter and setter //accessor and mutator
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int wDMG
        {
            get
            {
                return weaponDMG;
            }
            set
            {
                weaponDMG = value;
            }
        }

        public bool stillAlive
        {
            get
            {
                return isAlive;
            }
            set
            {
                isAlive = value;
            }
        }

        public string wName
        {
            get
            {
                return weaponName;
            }
            set
            {
                weaponName = value;
            }
        }

        public int eHealth
        {
            get
            {
                return enemyHealth;
            }
            set
            {
                enemyHealth = value;
            }
        }

        public Enemy()
        {
            Name = "Corpse";
            wDMG = 3;
            stillAlive = true;
            wName = "fingernails";
            eHealth = 10;
        }

        public Enemy(string enemyName, int weapondamage, bool alive, string weaponname, int enemyH)
        {
            Name = enemyName;
            wDMG = weapondamage;
            stillAlive = alive;
            wName = weaponname;
            eHealth = enemyH;
        }
    }
}
