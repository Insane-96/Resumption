using Aiv.Engine;

namespace GlobalGameJam2016.EnvironmentList
{
    class EnviromentWater:Enviroment 
    {
        public EnviromentWater(int width, int height):base(width,height)
        {
            gravity = 5;
        }
        public override void Start()
        {
            base.Start();
            var baseSprite = (SpriteAsset)Engine.GetAsset("backgroundWater_0_0");
            CurrentSprite = baseSprite;
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
