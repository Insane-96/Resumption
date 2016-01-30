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
        public int Health { get; protected set; }
        public int Speed { get; protected set; }
        private bool isEasy;
        private int width;
        private int height;

        public enum CheckMovement
        {
            RightMovement,
            LeftMovement,
            UpMovement,
            DownMovement
        }

        public Enemy(int width, int height, bool isEasy, int posX, int posY, string hitBoxName = "auto") : base(width, height, true, hitBoxName)
        {
            X = posX;
            Y = posY;
            Speed = 50;
            this.isEasy = isEasy;
            this.width = width;
            this.height = height;
        }

        public override void Start()
        {
            base.Start();
            AddHitBox("Enemy_Coll", 0, 0, width, height / 2);
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
