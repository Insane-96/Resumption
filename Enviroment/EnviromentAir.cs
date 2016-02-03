using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016.Enviroment
{
    class EnviromentAir : Enviroment
    {
        public EnviromentAir(int width, int height) : base(width, height)
        {
            tiles = new Platform[100];
            int y = 25;
            int min = 5;
            int r;
            for (int i = 0; i < tiles.Length; i++)
            {
                do
                {
                    r = Utils.Randomize(0, 10);
                    y--;
                    min--;
                    if (r < 2 || min == 0)
                    {
                        Console.WriteLine("min " + min);
                        tiles[i] = new Platform(80, 25, Utils.Randomize(0, 1280 - 80), y * 20, TileType.Cloud, i);
                        min = 5;
                    }
                } while (r >= 2 && min > 0);
            }
        }

        public override void Start()
        {
            base.Start();
            CurrentSprite = (SpriteAsset)Engine.GetAsset("backgroundAir_0_0");

        }

        public override void Update()
        {
            base.Update();
        }

    }
}
