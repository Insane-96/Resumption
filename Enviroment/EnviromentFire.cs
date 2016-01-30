using Aiv.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalGameJam2016.Enviroment
{
    class EnviromentFire : Enviroment
    {
        public EnviromentFire(int width, int height) : base(width, height)
        {

        }
        public override void Start()
        {
            base.Start();
            CurrentSprite = (SpriteAsset)Engine.GetAsset("backgroundFire_0_0");
        }
        public override void Update()
        {
            base.Update();
        }
    }
}
