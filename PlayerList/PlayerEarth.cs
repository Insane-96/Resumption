using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

namespace GlobalGameJam2016.PlayerList
{
	class PlayerEarth : Player
	{
		private Enviroment.Enviroment enviroment;
		public PlayerEarth(int width, int height, bool autoHitbox, string autoHitboxName) : base(width, height, autoHitbox, autoHitboxName)
		{
			
		}

		public override void Start()
		{
			base.Start();
		}

		public override void Update()
		{
			base.Update();
			Movement();
		}

		private void Movement()
		{
			if (Engine.IsKeyDown(keyMap.left))
				X -= movSpeed * Engine.DeltaTime;
			else if (Engine.IsKeyDown(keyMap.right))
				X += movSpeed * Engine.DeltaTime;

			if (CheckCollisions().Count == 0)
			{
				this.Y += 40f * Engine.DeltaTime;
			}
		}
	}
}
