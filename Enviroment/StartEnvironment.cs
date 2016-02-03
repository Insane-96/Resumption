using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;
using Aiv.Fast2D;
using OpenTK;
using Aiv.Vorbis;
using NVorbis;


namespace GlobalGameJam2016.Enviroment
{
    class StartEnvironment : Enviroment
    {
        Player[] player;
        int selected;
        bool select;

        public StartEnvironment(int width, int height) : base(width, height)
        {
            gravity = 0;

        }
        public override void Start()
        {
            base.Start();
            var baseSprite = (SpriteAsset)Engine.GetAsset("startHub_0_0");
            CurrentSprite = baseSprite;
            AudioAsset startLevel = new AudioAsset("StartMenu.ogg");
            AudioSource.Play(startLevel.Clip, true);
        }
        public override void Update()
        {
            base.Update();
            Selection();
            Movement();
        }
        public void Selection()
        {
            if (Engine.IsKeyDown(KeyCode.W) && !select)
            {
                ResetVector();
                Game.players[0].Scale = new Vector2(1.5f, 1.5f);
                selected = 0;
            }
            else if (Engine.IsKeyDown(KeyCode.D) && !select)
            {
                ResetVector();
                Game.players[1].Scale = new Vector2(1.5f, 1.5f);
                selected = 1;
            }
            else if (Engine.IsKeyDown(KeyCode.S) && !select)
            {
                ResetVector();
                Game.players[2].Scale = new Vector2(1.5f, 1.5f);
                selected = 2;

            }
            else if (Engine.IsKeyDown(KeyCode.A) && !select)
            {
                ResetVector();
                Game.players[3].Scale = new Vector2(1.5f, 1.5f);
                selected = 3;
            }
            if (Engine.IsKeyDown(KeyCode.E))
            {
                select = true;
            }

        }
        public void Movement()
        {
            if (select)
            {
                if (selected == 0)
                {
                    Game.players[0].Y -= Engine.Height / 10 * Engine.DeltaTime;
                    Game.players[0].ChangeAnimation("walkUp");
                    if (Game.players[0].Y < 0 - Game.players[0].Height) { 
                        Game.players[0].Scale = new Vector2(1f, 1f);
                        Game.players[0].currentEnviroment = EnviromentType.AirEnviroment;
                        Game.LoadEnviroment(new EnviromentAir(1280, 720));
                    }
                }
                else if (selected == 1)
                {
                    Game.players[1].X += Engine.Width / 10 * Engine.DeltaTime;
                    Game.players[1].ChangeAnimation("walkUp");
					if (Game.players[1].X > Engine.Width)
					{
						Game.players[1].currentEnviroment = EnviromentType.FireEnviroment;
						Game.players[1].Scale = new Vector2(1f, 1f);
						Game.LoadEnviroment(new EnviromentFire(1280, 720));
					}
				}
                else if (selected == 2)
                {
                    Game.players[2].Y += Engine.Height / 10 * Engine.DeltaTime;
                    Game.players[2].ChangeAnimation("walkUp");
                    if (Game.players[2].Y > Engine.Height)
                    {
                        Game.players[2].Scale = new Vector2(1f, 1f);
                        Game.players[2].currentEnviroment = EnviromentType.EarthEnviroment;
                        Game.LoadEnviroment(new EnviromentEarth(1280, 720));
                    }
                }
                else if (selected == 3)
                {
                    Game.players[3].X -= Engine.Width / 10 * Engine.DeltaTime;
                    Game.players[3].ChangeAnimation("walkUp");
	                if (Game.players[3].X < 0)
	                {
                        Game.players[3].currentEnviroment = EnviromentType.WaterEnviroment;
						Game.players[3].Scale = new Vector2(1f, 1f);
						Game.LoadEnviroment(new EnviromentWater(1280, 720));
					}
				}

            }

        }
        public void ResetVector()
        {
            Game.players[0].Scale = new Vector2(1f, 1f);
            Game.players[1].Scale = new Vector2(1f, 1f);
            Game.players[2].Scale = new Vector2(1f, 1f);
            Game.players[3].Scale = new Vector2(1f, 1f);
        }
    }
}

