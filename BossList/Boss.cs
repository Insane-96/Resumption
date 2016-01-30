using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016.BossList
{
    class Boss : SpriteObject
    {
        public int Health { get; protected set; }
        public int Speed { get; protected set; }
        
        private int width;
        private int height;

        public enum CheckMovement
        {
            RightMovement,
            LeftMovement,
            UpMovement,
            DownMovement
        }

        public Boss(int width, int height, int posX, int posY, string hitBoxName = "auto") : base(width, height, true, hitBoxName)
        {
            X = posX;
            Y = posY;
            Speed = 50;           
            this.width = width;
            this.height = height;
        }

        public override void Start()
        {
            base.Start();
            
        }

        public override void Update()
        {
            base.Update();
            if (Health == 0)
                this.Destroy();
        }

        public void Damage()
        {
            Health--;
        }
    }
}