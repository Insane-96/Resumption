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
        private bool isEasy;

        public enum CheckMovement
        {
            RightMovement,
            LeftMovement,
            UpMovement,
            DownMovement
        }

        public Enemy(int width, int height, bool isEasy, string hitBoxName = "auto") : base(width, height, true, hitBoxName)
        {

            Speed = 50;
            this.isEasy = isEasy;
        }

        // da spostare in bullet

        public override void Update()
        {
            base.Update();
            if (Health == 0)
                this.Destroy();
        }
		

    }
}
