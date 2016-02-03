using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;
using OpenTK;

namespace GlobalGameJam2016.EnemyList
{
    class EnemyWater : Enemy
    {

        public CheckMovement move;
        public EnemyWater(int width, int height, bool isEasy, string hitBoxName, int posX, int posY) : base(width, height, isEasy, posX, posY, hitBoxName)
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
            Engine.Timer.Set("Cooldown", 2f);
        }

        public virtual void Movement()
        {
            if (move == CheckMovement.RightMovement)
            {
                X += Speed * Engine.DeltaTime;

                if (Engine.Timer.Get("Cooldown") <= 0)
                {
                    move = CheckMovement.LeftMovement;
                    Engine.Timer.Set("Cooldown", 2f);
                }
                    
            }

            if (move == CheckMovement.LeftMovement)
            {
                X -= Speed * Engine.DeltaTime;

                if (Engine.Timer.Get("Cooldown") <= 0)
                {
                    move = CheckMovement.RightMovement;
                    Engine.Timer.Set("Cooldown", 2f);
                }
            }
        }
        public override void Update()
        {
            base.Update();
            Movement();
        }

    }
    class EnemyWaterEasy : EnemyWater
    {
        Player player;
        public EnemyWaterEasy(Engine engine, int posX, int posY) : base(60, 40, true, "Enemy_", posX, posY) // change name
        {
            this.player = Game.players[3];
            // Utils.LoadAssets(engine,);
        }

        public override void Start()
        {
            base.Start();
            SpriteAsset sprite = new SpriteAsset("playerDefault.png");
			this.AddAnimation("blob_idle", new List<string> { "blob_0_0" }, 10);

			this.CurrentAnimation = "blob_idle";
		}

        public override void Update()
        {
            base.Update();
			Movement();

		}

		public override void Movement()
        {
            base.Movement();
			Vector2 playersPosition = new Vector2(Game.players[3].X, Game.players[3].Y);
			Vector2 enemyMediumPosition = new Vector2(X, Y);
			Vector2 distance = playersPosition - enemyMediumPosition;
			/* distance.X = Game.players[3].X - X;
             if(distance.X < 0)
             {
                 distance.X = X - Game.players[3].X;
             }
             distance.Y = Game.players[3].Y - Y;
             if (distance.Y < 0)
             {
                 distance.Y = Y - Game.players[3].Y;
             }*/

			X += (distance.X * DeltaTime) / 2;
			Y += (distance.Y * DeltaTime) / 2;
		}
    }

    class EnemyWaterMedium : EnemyWater
    {
        Player player;

        public EnemyWaterMedium(Engine engine, int posX, int posY) : base(60, 80, false, "Enemy_", posX, posY)
        {
            this.player = Game.players[3];
            // Utils.LoadAssets(engine,);
        }

		public override void Start()
		{
			//create animation
			base.Start();
			this.AddAnimation("blob_idle", new List<string> { "blob_0_0" }, 10);

			this.CurrentAnimation = "blob_idle";
		}

		public override void Update()
		{
			base.Update();
			Movement();
		}

		public override void Movement()
		{
			base.Movement();
			Vector2 playersPosition = new Vector2(Game.players[3].X, Game.players[3].Y);
			Vector2 enemyMediumPosition = new Vector2(X, Y);
			Vector2 distance = playersPosition - enemyMediumPosition;
			/* distance.X = Game.players[3].X - X;
			 if(distance.X < 0)
			 {
				 distance.X = X - Game.players[3].X;
			 }
			 distance.Y = Game.players[3].Y - Y;
			 if (distance.Y < 0)
			 {
				 distance.Y = Y - Game.players[3].Y;
			 }*/

			X += distance.X * DeltaTime;
			Y += distance.Y * DeltaTime;
			if (HasCollisions())
			{
				// destroy block
			}
		}
	}
}
