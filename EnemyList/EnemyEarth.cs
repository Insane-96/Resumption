using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;
using GlobalGameJam2016.Enviroment;

namespace GlobalGameJam2016.EnemyList
{
	class EnemyEarth : Enemy
	{
		public CheckMovement move;
		public EnemyEarth(int width, int height, bool isEasy, string hitBoxName, int posX, int posY) : base(width, height, isEasy, posX, posY, hitBoxName)
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
			var lastY = Y;
			Y += 100 * Engine.DeltaTime;
			if (CheckCollisions().Count > 0)
			{
				Y = lastY;
			}
		}
		public override void Update()
		{
			base.Update();
			Movement();
		}

	}
	class EnemyEarthEasy : EnemyEarth
	{
		Player player;
		public EnemyEarthEasy(Engine engine, int posX, int posY) : base(60, 40, true, "Enemy_Blob", posX, posY)
		{
			this.player = Game.player;

		}

		public override void Start()
		{
			base.Start();
			SpriteAsset sprite = new SpriteAsset("playerDefault.png");
		}

		public override void Update()
		{
			base.Update();
			Movement();
		}
	}

	class EnemyEarthMedium : EnemyEarth
	{
		Player player;

		public EnemyEarthMedium(Engine engine, int posX, int posY) : base(60, 80, false, "Enemy_Mole", posX, posY)
		{
			this.player = Game.player;
		}

		public override void Start()
		{
			//create animation
			base.Start();
		}

		public override void Update()
		{
			base.Update();
			Movement();

			foreach (var obj in CheckCollisions())
			{
				if (obj.OtherHitBox.StartsWith("Wall"))
				{
					Tile otherTile = (Tile)obj.Other;
					Game.enviromentEarth.tiles[Utils.GetPos((int)(otherTile.X + this.Width / 2) / 80, (int)(otherTile.X + this.Width / 2) / 80, 16)].tileType = TileType.None;
				}
			}
		}

		public override void Movement()
		{
			base.Movement();
			if ((int)this.Y > (int)player.Y && (int)this.Y < (int)player.Y + player.Height)
			{
				if (player.X > this.X)
					move = CheckMovement.RightMovement;

				if (player.X < this.X)
					move = CheckMovement.LeftMovement;
			}

		}
	}
}
