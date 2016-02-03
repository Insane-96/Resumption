using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;
using GlobalGameJam2016.Enviroment;

namespace GlobalGameJam2016.PlayerList
{
	class PlayerWater : Player
	{
		public Bullet bullet;
		public List<Bullet> bulletsShot;
		public Bullet.bulletsDirection direction;
		private bool isRight;
		private Enviroment.Enviroment enviroment;
		public PlayerWater(int width, int height, bool autoHitbox, string autoHitboxName, EnviromentType Enviroment)
			: base(width, height, autoHitbox, autoHitboxName, Enviroment)
		{
			bulletsShot = new List<Bullet>();
		}

		public override void Start()
		{
			base.Start();
			var baseSprite = (SpriteAsset)Engine.GetAsset("hero_0_2");
			CurrentSprite = baseSprite;
			AddAnimation("walkUp", new List<string> { "hero_0_2", "hero_1_2", "hero_2_2", "hero_3_2" }, 5);
		}

		public override void Update()
		{
			base.Update();
			if (this.currentEnviroment == EnviromentType.WaterEnviroment)
			{
				Movement();
				attack();
			}
		}
		private void Movement()
		{
			if (Engine.IsKeyDown(keyMap.left))
			{
				isRight = false;
				X -= 300 * DeltaTime;
			}
			else if (Engine.IsKeyDown(keyMap.right))
			{
				X += 300 * DeltaTime;
				isRight = true;
			}
			else if (Engine.IsKeyDown(keyMap.up))
			{
				Y -= 300 * DeltaTime;
				isRight = true;
			}
			else if (Engine.IsKeyDown(keyMap.down))
			{
				Y += 300 * DeltaTime;
				isRight = true;
			}

		}
		public void attack()
		{

			if (Engine.IsKeyDown(keyMap.attack) && Engine.Timer.Get("coolDown") <= 0)
			{

				bullet = new Bullet(direction);
				if (direction == Bullet.bulletsDirection.RIGHT)
				{
					bullet.X = this.X + Sprite.Width;
					bullet.Y = this.Y + Sprite.Height / 2;
				}
				if (direction == Bullet.bulletsDirection.LEFT)
				{
					bullet.X = this.X - bullet.Width;
					bullet.Y = this.Y + Sprite.Height / 2;
				}
				if (direction == Bullet.bulletsDirection.UP)
				{
					bullet.X = this.X + Sprite.Width / 2 - (bullet.Width / 2);
					bullet.Y = this.Y - bullet.Height;
				}
				if (direction == Bullet.bulletsDirection.DOWN)
				{
					bullet.X = this.X + Sprite.Width / 2 - (bullet.Width / 2);
					bullet.Y = this.Y + Sprite.Height;
				}
				bulletsShot.Add(bullet);
				Engine.SpawnObject("bullet", bullet);
				bullet.isShoot = true;
				Engine.Timer.Set("coolDown", 0.5f);
			}
		}
	}
}