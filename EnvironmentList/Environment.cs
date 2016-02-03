using Aiv.Engine;

namespace GlobalGameJam2016.EnvironmentList
{
    enum EnviromentType
    {
        StartEnviroment,
        AirEnviroment,
        FireEnviroment,
        EarthEnviroment,
        WaterEnviroment,
    }
    class Enviroment : SpriteObject
	{
        public static float gravity;
        public Tile[] tiles;
        public Enviroment(int width, int height) : base(width, height)
        {
            gravity = 10;
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();
        }

    }
}
