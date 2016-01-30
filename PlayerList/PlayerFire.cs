using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016.PlayerList
{
    class PlayerFire:Player 
    {
        private Enviroment.Enviroment enviroment;
		public PlayerFire(int width, int height, bool autoHitbox, string autoHitboxName) : base(width, height, autoHitbox, autoHitboxName)
		{
		}

		public override void Start()
		{
			base.Start();
            var baseSprite = (SpriteAsset)Engine.GetAsset("hero_0_1");
            CurrentSprite = baseSprite;
            AddAnimation("walkUp", new List<string> { "hero_0_2", "hero_1_2", "hero_2_2", "hero_3_2" }, 5);
		}

		public override void Update()
		{
			base.Update();
			
		}
        public void ChangeAnimation()
        {
            CurrentAnimation = "walkUp";
        }
    }
}
