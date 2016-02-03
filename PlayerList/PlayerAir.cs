using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;
using GlobalGameJam2016.EnvironmentList;

namespace GlobalGameJam2016.PlayerList
{
    class PlayerAir : Player
    {
        private EnvironmentList.Enviroment enviroment;
        private float accelleration;
        public PlayerAir(int width, int height, bool autoHitbox, string autoHitboxName, EnviromentType environment) : base(width, height, autoHitbox, autoHitboxName, environment)
        {
        }

        public override void Start()
        {
            base.Start();
            var baseSprite = (SpriteAsset)Engine.GetAsset("hero_0_0");
            CurrentSprite = baseSprite;
            AddAnimation("walkUp", new List<string> { "hero_0_3", "hero_1_3", "hero_2_3", "hero_3_3" }, 5);
            accelleration = 200;
        }

        public override void Update()
        {
            base.Update();
            if (currentEnviroment == EnviromentType.AirEnviroment)
            {
                Movement();
                Input();
            }


        }

        private void Input()
        {
            if (Engine.IsKeyDown(keyMap.left))
            {
                this.X -= movSpeed * Engine.DeltaTime;
            }
            else if (Engine.IsKeyDown(keyMap.right))
            {
                this.X += movSpeed * Engine.DeltaTime;
            }
        }

        private void Movement()
        {
            this.Y -= accelleration * Engine.DeltaTime;
            accelleration -= 40f * Engine.DeltaTime;
            if (accelleration < 0)
            {
                foreach(var obj in CheckCollisions())
                    if (obj.HitBox.EndsWith("Down"))
                    {
                        accelleration = 150;
         
                    }
            }

            if (this.Y < Engine.Height / 2 /*&& accelleration > 0*/)
            {
                Engine.Camera.Y = Y - Engine.Height / 2;
                Game.currentEnvironment.Y = Engine.Camera.Y;
            }

            Engine.Camera.Update();
        }

    }
}
