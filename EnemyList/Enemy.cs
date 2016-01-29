using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016.EnemyList
{
     class Enemy : SpriteObject
    {
        public float Health { get; protected set; }
        public int Speed { get; protected set; }
        private int range;

        public Enemy(int width, int height , string hitBoxName = "auto") : base (width,height,true,hitBoxName)
        {
            Health = 100;
            Speed = 100;
        }

        // da spostare in bullet
        public void GetDamage()
        {
            if(HasCollisions())
            {
                if (range == 1) // Easy
                {
                    Health -= 100; // sistemare variabili
                }
                else if (range == 2) // Medium 
                {
                    Health -= 50;
                }
                else if (range == 3) // Boss
                {
                    Health -= 25;
                }
            }
        }

        public virtual void Moviment()
        {
            
        }



        
        

        
    }
}
