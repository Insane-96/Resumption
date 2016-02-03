using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;
using GlobalGameJam2016.Enviroment;

namespace GlobalGameJam2016.PlayerList
{
	class PlayerFire : Player
	{
		public Bullet bullet;
		private Enviroment.Enviroment enviroment;
		public List<Bullet> bulletsShot;
		public Bullet.bulletsDirection direction;
		private bool isRight;

		public PlayerFire(int width, int height, bool autoHitbox, string autoHitboxName, Enviroment.EnviromentType environment) : base(width, height, autoHitbox, autoHitboxName, environment)
		{
			// bulletsShot = new List<Bullet>();
			isRight = true;
			X = 1280 / 2f;
			Y = -height;
		}

		public override void Start()
		{
			base.Start();
			Engine.Timer.Set("coolDown", 0.5f);
			var baseSprite = (SpriteAsset)Engine.GetAsset("hero_3_1");
			CurrentSprite = baseSprite;
			//var fireSprite = (SpriteAsset)Engine.GetAsset("LeftFire_1_0");
			AddAnimation("walkUp", new List<string> { "hero_0_2", "hero_1_2", "hero_2_2", "hero_3_2" }, 5);
			AddAnimation("PlayerFire_Up", new List<string> { "PlayerFire_0_3", "PlayerFire_1_3", "PlayerFire_2_3", "PlayerFire_3_3" }, 5);
			AddAnimation("PlayerFire_Down", new List<string> { "PlayerFire_0_0", "PlayerFire_1_0", "PlayerFire_2_0", "PlayerFire_3_0" }, 5);
			AddAnimation("PlayerFire_Right", new List<string> { "PlayerFire_0_2", "PlayerFire_1_2", "PlayerFire_2_2", "PlayerFire_3_2" }, 5);
			AddAnimation("PlayerFire_Left", new List<string> { "PlayerFire_0_1", "PlayerFire_1_1", "PlayerFire_2_1", "PlayerFire_3_1" }, 5);
			//CurrentAnimation = "PlayerFire_Left";
		}


		public override void Update()
		{
			base.Update();
			if (currentEnviroment == EnviromentType.FireEnviroment)
			{
				Movement();
				Input();
			}
		}

		private void Input()
		{
			if (Engine.Timer.Get("cooldown") <= 0)
			{
				if (Engine.IsKeyDown(keyMap.attack) && Engine.IsKeyDown(keyMap.up) &&
					Game.currentEnvironment.tiles[
						Utils.GetPos((int)(this.X + this.Height / 2) / 80, (int)(this.Y + (this.Height / 2)) / 80 - 1, 16)].tileType ==
					TileType.DestrWall)
				{
					Game.currentEnvironment.tiles[
						Utils.GetPos((int)(this.X + this.Height / 2) / 80, (int)(this.Y + (this.Height / 2)) / 80 - 1, 16)].tileType =
						TileType.None;
					Engine.Timer.Set("cooldown", 1.2f);

				}
				else if (Engine.IsKeyDown(keyMap.attack) && isRight &&
						 Game.currentEnvironment.tiles[
							 Utils.GetPos((int)(this.X + this.Width / 2) / 80 + 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType ==
						 TileType.DestrWall)
				{
					Game.currentEnvironment.tiles[
						Utils.GetPos((int)(this.X + this.Width / 2) / 80 + 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType =
						TileType.None;
					Engine.Timer.Set("cooldown", 1.2f);
				}
				else if (Engine.IsKeyDown(keyMap.attack) && !isRight &&
						 Game.currentEnvironment.tiles[
							 Utils.GetPos((int)(this.X + this.Width / 2) / 80 - 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType ==
						 TileType.DestrWall)
				{
					Game.currentEnvironment.tiles[
						Utils.GetPos((int)(this.X + this.Width / 2) / 80 - 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType =
						TileType.None;
					Engine.Timer.Set("cooldown", 1.2f);
				}
			}
		}


		private void Movement()
		{
			if (Engine.IsKeyDown(keyMap.left))
			{
				foreach (var obj in CheckCollisions())
				{
					if (!obj.OtherHitBox.StartsWith("Wall") || !obj.HitBox.EndsWith("Left"))
						X -= movSpeed * Engine.DeltaTime;
					break;
				}
				isRight = false;
			}
			else if (Engine.IsKeyDown(keyMap.right))
			{
				foreach (var obj in CheckCollisions())
				{
					if (!obj.OtherHitBox.StartsWith("Wall") || !obj.HitBox.EndsWith("Right"))
						X += movSpeed * Engine.DeltaTime;
					break;
				}
				isRight = true;
			}

			if (Engine.IsKeyDown(keyMap.up) && (CheckCollisions().Count == 0))
			{
				this.Y -= movSpeed * Engine.DeltaTime;


				if (this.Y < 80*32 - Engine.Height / 2)
				{
					Engine.Camera.Y = Y - Engine.Height / 2;
					Game.currentEnvironment.Y = Engine.Camera.Y;
				}

				Engine.Camera.Update();


			}
		}
	}
}
