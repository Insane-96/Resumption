using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Aiv.Engine;
using Aiv.Fast2D;
using OpenTK;

namespace GlobalGameJam2016
{
	class Player : SpriteObject
	{
		int health;
		int lifes;
		int energy;
		public int movSpeed;
		public float gravitySpeed;
		public KeyMap keyMap;

		public Player(int width, int height, bool autoHitbox, string autoHitboxName) : base(width, height, autoHitbox, autoHitboxName)
		{
			health = 16;
			lifes = 3;
			energy = 100;
			movSpeed = 100;
			gravitySpeed = 0;
			keyMap = new KeyMap(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.E, KeyCode.Space);
		}

		private void LoadAnimations()
		{
			this.AddAnimation("player_idle", new List<string> { "playerDefault_0_0" }, 10);
			this.CurrentAnimation = "player_idle";
		}

		public override void Start()
		{
			base.Start();
			//LoadAnimations();
		}

		public override void Update()
		{
			base.Update();
		}
	}
}
