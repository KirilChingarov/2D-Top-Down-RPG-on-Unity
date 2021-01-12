using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterStats
    {
        private int health;

        public CharacterStats()
        {
            health = 0;
        }

        public CharacterStats(int health)
        {
            this.health = health;
        }
    }    
}

