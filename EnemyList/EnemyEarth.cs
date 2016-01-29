using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;


namespace GlobalGameJam2016.EnemyList
{
    class EnemyEarth : Enemy
    {
        public EnemyEarth(Engine engine, int width, int height) : base(width, height, "Enemy_Earth")
        {

        }

        public override void Start()
        {
            base.Start();
        }
        public override void Moviment()
        {
            base.Moviment();
        }
        public override void Update()
        {
            base.Update();
            Moviment();

        }


    }
}
