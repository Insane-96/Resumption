using Aiv.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalGameJam2016.Enviroment
{
    class Platform:Tile
    {
        public Platform(int width, int height, int posX, int posY, TileType tileType, int id) :base(width, height, posX, posY, tileType, id)
        {

        }

        public override void Start()
        {
            base.Start();
            if (tileType == TileType.Cloud)
                CurrentSprite = (SpriteAsset)Engine.GetAsset("cloud_0_0");
        }

        public override void Update()
        {
            base.Update();
        }
    }
}
