using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016
{
    class Bullet : SpriteObject
    {
        public enum bulletsDirection
        {
            UP,
            DOWN,
            RIGHT,
            LEFT
        }

        public Player player;
        public float movSpeed = 200f;
        public bool isShoot;
        public bulletsDirection bulletDirection;

        public Bullet(bulletsDirection direction):base(37,46,true,"bullet")
        {
            bulletDirection = direction;
        }
        private void LoadAnimations()
        {
            CurrentSprite = (SpriteAsset)Engine.GetAsset("bullet_0_0");
        }

        public void Movement()
        {
            if (bulletDirection == bulletsDirection.RIGHT && isShoot)
            {
                X += movSpeed * DeltaTime;
            }
            if (bulletDirection == bulletsDirection.LEFT && isShoot)
            {
                X -= movSpeed * DeltaTime;
            }
            if (bulletDirection == bulletsDirection.UP && isShoot)
            {
                Y -= movSpeed * DeltaTime;
            }
            if (bulletDirection == bulletsDirection.DOWN && isShoot)
            {
                Y += movSpeed * DeltaTime;
            }
        }

        public void Checkcollision()
        {
            if (HasCollisions())
            {
                isShoot = false;
                this.Destroy();
            }
        }

        public override void Start()
        {
            base.Start();
            LoadAnimations();
        }

        public override void Update()
        {
            base.Update();
            Movement();
            Checkcollision();
        }
    }
}
