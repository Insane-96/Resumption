using Aiv.Engine;

namespace GlobalGameJam2016.EnvironmentList
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
