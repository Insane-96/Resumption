using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016.PlayerList
{
    class PlayerAir:Player
    {
        private Enviroment.Enviroment enviroment;
		public PlayerAir(int width, int height, bool autoHitbox, string autoHitboxName) : base(width, height, autoHitbox, autoHitboxName)
		{
		}

		public override void Start()
		{
			base.Start();
            var baseSprite = (SpriteAsset)Engine.GetAsset("hero_0_0");
            CurrentSprite = baseSprite;
            AddAnimation ("walkUp",new List <string>{"hero_0_3","hero_1_3","hero_2_3", "hero_3_3"}, 5);
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
