using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;
using Aiv.Fast2D;
using OpenTK;


namespace GlobalGameJam2016.Enviroment
{
    class StartEnvironment: Enviroment
    {
        Player[] player;
        int selected;
        bool select;

        
        
        public StartEnvironment(int width, int height):base(width,height)
        {
            gravity = 0;

        }
        public override void Start()
        {
            base.Start();
            var baseSprite = (SpriteAsset)Engine.GetAsset("startHub_0_0");
            CurrentSprite = baseSprite;
            AudioAsset startLevel = new AudioAsset("StartMenu.ogg");
            AudioSource.Play(startLevel.Clip,true);
        }
        public override void Update()
        {
            base.Update();
            Selection();
            Movement();
        }
        public void Selection()
        {
            if(Engine.IsKeyDown(KeyCode.W))
            {
                ResetVector();
                Game.player.Scale = new Vector2(1.5f, 1.5f);
                selected = 0;
            }
            else if (Engine.IsKeyDown(KeyCode.D))
            {
                ResetVector();
                Game.player2.Scale = new Vector2(1.5f, 1.5f);
                selected = 1;
            }
            else if (Engine.IsKeyDown(KeyCode.S))
            {
                ResetVector();
                Game.player3.Scale = new Vector2(1.5f, 1.5f);
                selected = 2;

            }
            else if (Engine.IsKeyDown(KeyCode.A))
            {
                ResetVector();
                Game.player4.Scale = new Vector2(1.5f, 1.5f);
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
                    Game.player.Y -= 100 * Engine.DeltaTime;
                    Game.player.ChangeAnimation();
                }
                else if (selected == 1)
                {
                    Game.player2.X += 100 * Engine.DeltaTime;
                    Game.player2.ChangeAnimation();
                }
                else if (selected == 2)
                {
                    Game.player3.Y += 100 * Engine.DeltaTime;
                    Game.player3.ChangeAnimation();
                }
                else if (selected == 3)
                {
                    Game.player4.X -= 100 * Engine.DeltaTime;
                    Game.player4.ChangeAnimation();
                }
            }
            

        }
        public void ResetVector()
        {
            Game.player.Scale = new Vector2(1f, 1f);
            Game.player2.Scale = new Vector2(1f, 1f);
            Game.player3.Scale = new Vector2(1f, 1f);
            Game.player4.Scale = new Vector2(1f, 1f);
        }

    }
}
