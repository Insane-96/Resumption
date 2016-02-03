using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Aiv.Engine;
using Aiv.Fast2D;
using OpenTK;
using GlobalGameJam2016.EnvironmentList;

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
        public EnviromentType currentEnviroment;

        public Player(int width, int height, bool autoHitbox, string autoHitboxName, EnviromentType environment) : base(width, height, autoHitbox, autoHitboxName)
        {
            health = 16;
            lifes = 3;
            energy = 100;
            movSpeed = 100;
            gravitySpeed = 0;
            keyMap = new KeyMap(KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D, KeyCode.E, KeyCode.Space);
            currentEnviroment = environment;
        }
        public void ChangeAnimation(string texture)
        {
            CurrentAnimation = "walkUp";
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
            AddHitBox("PlayerLeft", 0, (int)this.Height / 3, (int)this.Width / 2, (int)this.Height / 3);
            AddHitBox("PlayerRight", (int)this.Width / 2, (int)this.Height / 3, (int)this.Width / 2, (int)this.Height / 3);
            AddHitBox("PlayerUp", 0, 0, (int)this.Width, (int)this.Height / 3);
            AddHitBox("PlayerDown", 0, (int)this.Height / 3 * 2, (int)this.Width, (int)this.Height / 3);
        }

		public override void Update()
		{
			base.Update();
		}
	}
}
