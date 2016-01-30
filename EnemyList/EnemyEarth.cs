using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;


namespace GlobalGameJam2016.EnemyList
{
    class EnemyEarth : Enemy
    {
        public EnemyEarth(int width, int height, bool isEasy, string hitBoxName) : base(width, height, isEasy, hitBoxName)
        {
            if (isEasy)
            {
                Health = 1;
            }
            else
            {
                Health = 2;
            }
        }

        public override void Start()
        {
            base.Start();
        }
        public override void Movement()
        {
            base.Movement();
            X += Speed * Engine.DeltaTime;
            if(HasCollisions())
            {
                X *= -1;
            }
        }
        public override void Update()
        {
            base.Update();
            Movement();
        }

        class EnemyEarthEasy : EnemyEarth
        {
            Player player;
            public EnemyEarthEasy(Player player,  Engine engine, int width, int height) : base(width, height, true, "Enemy_Blob")
            {
                this.player = player;
               // Utils.LoadAssets(engine,);
            }

            public override void Start()
            {
                base.Start();
            }

            public override void Update()
            {
                base.Update();
            }

            public override void Movement()
            {
                base.Movement();
                
            }
        }

        class EnemyEarthMedium : EnemyEarth
        {
            Player player;

            public EnemyEarthMedium(Player player, Engine engine, int width, int height) : base(width, height, false, "Enemy_Mole")
            {
                this.player = player;
                // Utils.LoadAssets(engine,);
            }

            public override void Start()
            {
                //create animation
                base.Start();
            }

            public override void Update()
            {
                base.Update();
            }

            public override void Movement()
            {
                base.Movement();
                
                if (HasCollisions())// aggiungere vector
                {
                    // destroy block
                }
            }
        }
    }
}
