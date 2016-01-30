using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016.EnemyList
{
    class EnemyFire : Enemy
    {
        Player player;
        public CheckMovement move;
        public bool isJumping;
        public int jumpGravity = 5;

        public EnemyFire(int width, int height, bool isEasy, string hitBoxName, int posX, int posY) : base(width, height, isEasy, posX, posY, hitBoxName)
        {
            move = CheckMovement.RightMovement;
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
            this.AddAnimation("player_idle", new List<string> { "playerDefault_0_0" }, 10);
            this.CurrentAnimation = "player_idle";
        }

        public virtual void Movement()
        {

            if (move == CheckMovement.RightMovement)
            {
                X += Speed * Engine.DeltaTime;
                if (HasCollisions())
                    move = CheckMovement.LeftMovement;
            }

            if (move == CheckMovement.LeftMovement)
            {
                X -= Speed * Engine.DeltaTime;
                if (HasCollisions())
                    move = CheckMovement.RightMovement;
            }
        }
        public override void Update()
        {
            base.Update();
            Movement();
        }

    }
    class EnemyFireEasy : EnemyFire
    {
        Player player;
        public EnemyFireEasy(Engine engine, int width, int height,int posX, int posY) : base(width, height, true, "Enemy_Blob", posX, posY) // change name
        {
            this.player = Game.player;
            // Utils.LoadAssets(engine,);
        }

        public override void Start()
        {
            base.Start();
            SpriteAsset sprite = new SpriteAsset("playerDefault.png");
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

    class EnemyFirerMedium : EnemyFire
    {
        Player player;

        public EnemyFirerMedium(Engine engine, int width, int height, int posX, int posY) : base(width, height, false, "Enemy_Mole",posX,posY)
        {
            this.player = Game.player;
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

            int _x = Utils.Randomize(70, 101);
            if (move == CheckMovement.RightMovement)
            {
                X += Speed * Engine.DeltaTime;
                if (isJumping)
                {
                    Y -= jumpGravity * Engine.DeltaTime;
                    Y += jumpGravity * Engine.DeltaTime;
                    isJumping = false;
                }

                if (HasCollisions())
                    move = CheckMovement.LeftMovement;
            }

            if (move == CheckMovement.LeftMovement)
            {
                X -= Speed * Engine.DeltaTime;
                if (isJumping)
                {
                    Y -= jumpGravity * Engine.DeltaTime;
                    Y += jumpGravity * Engine.DeltaTime;
                    isJumping = false;
                }

                if (HasCollisions())
                    move = CheckMovement.RightMovement;
            }
        }
    }
}
