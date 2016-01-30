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
        
        public StartEnvironment(int width, int height):base(width,height)
        {
            gravity = 0;
            player= new Player[4];
            player[0] = Game.player;
            player[1] = Game.player2;
            player[2] = Game.player3;
            player[3] = Game.player4;
        }
        public override void Start()
        {
            base.Start();
            var baseSprite = (SpriteAsset)Engine.GetAsset("startHub_0_0");
            CurrentSprite = baseSprite;
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
            }
            else if (Engine.IsKeyDown(KeyCode.D))
            {
                ResetVector();
                Game.player2.Scale = new Vector2(1.5f, 1.5f);
            }
            else if (Engine.IsKeyDown(KeyCode.S))
            {
                ResetVector();
                Game.player3.Scale = new Vector2(1.5f, 1.5f);
            }
            else if (Engine.IsKeyDown(KeyCode.A))
            {
                ResetVector();
                Game.player4.Scale = new Vector2(1.5f, 1.5f);
            }
            
        }
        public void Movement()
        {
            if (Engine.IsKeyDown(KeyCode.E))
            {
                for(int i = 0; i < player.Length; i++)
                {
                    if(player[i].Scale.X == 1.5f)
                    {
                        player[i].Y -= 100 * Engine.DeltaTime;
                    }
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
