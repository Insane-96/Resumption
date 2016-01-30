using System;
using System.Threading.Tasks;
using Aiv.Fast2D;
using GlobalGameJam2016.Enviroment;
using OpenTK;
using OpenTK.Input;
using Aiv.Engine;

namespace GlobalGameJam2016.PlayerList
{
	class PlayerEarth : Player
	{
		private Enviroment.Enviroment enviroment;
		private bool isRight;
		public PlayerEarth(int width, int height, bool autoHitbox, string autoHitboxName) : base(width, height, autoHitbox, autoHitboxName)
		{
			isRight = true;
			X = 1280 / 2f;
			Y = -height;
		}

		public override void Start()
		{
			base.Start();
            var baseSprite = (SpriteAsset)Engine.GetAsset("hero_0_3");
            CurrentSprite = baseSprite;
		}

		public override void Update()
		{
			base.Update();
			//Movement();
			//Input();
		}

		private void Input()
		{
			if (Engine.Timer.Get("cooldown") <= 0)
			{
				if (Engine.IsKeyDown(keyMap.attack) && Engine.IsKeyDown(keyMap.down) &&
					Game.enviromentEarth.tiles[
						Utils.GetPos((int)(this.X + this.Height / 2) / 80, (int)(this.Y + (this.Height / 2)) / 80 + 1, 16)].tileType ==
					TileType.DestrWall)
				{
					Game.enviromentEarth.tiles[
						Utils.GetPos((int)(this.X + this.Height / 2) / 80, (int)(this.Y + (this.Height / 2)) / 80 + 1, 16)].tileType =
						TileType.None;
					Engine.Timer.Set("cooldown", 1.2f);

				}
				else if (Engine.IsKeyDown(keyMap.attack) && isRight &&
						 Game.enviromentEarth.tiles[
							 Utils.GetPos((int)(this.X + this.Width / 2) / 80 + 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType ==
						 TileType.DestrWall)
				{
					Game.enviromentEarth.tiles[
						Utils.GetPos((int)(this.X + this.Width / 2) / 80 + 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType =
						TileType.None;
					Engine.Timer.Set("cooldown", 1.2f);
				}
				else if (Engine.IsKeyDown(keyMap.attack) && !isRight &&
						 Game.enviromentEarth.tiles[
							 Utils.GetPos((int)(this.X + this.Width / 2) / 80 - 1, (int)(this.Y + (this.Height / 2)) / 80, 16)].tileType ==
						 TileType.DestrWall)
				{
					Game.enviromentEarth.tiles[
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

			/* (CheckCollisions().Count == 0)
			{
				this.Y += 200f * Engine.DeltaTime;
				if (this.Y > Engine.Height / 2)
					Engine.Camera.Y = Y - Engine.Height / 2;*/

				Engine.Camera.Update();

			//}
		}
	}
}
