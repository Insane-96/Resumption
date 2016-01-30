using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalGameJam2016.PlayerList
{
    class PlayerFire : Player
    {
        public Bullet bullet;
        private Enviroment.Enviroment enviroment;
        public List<Bullet> bulletsShot;
        public Bullet.bulletsDirection direction;

        public PlayerFire(int width, int height, bool autoHitbox, string autoHitboxName) : base(width, height, autoHitbox, autoHitboxName)
        {
            bulletsShot = new List<Bullet>();
            
        }

        public override void Start()
        {
            base.Start();
            Engine.Timer.Set("coolDown", 0.5f);
        }

        public override void Update()
        {
            base.Update();
            Movement();
            attack();
        }

        public void attack()
        {
            
            if (Engine.IsKeyDown(keyMap.attack) && Engine.Timer.Get("coolDown")<=0)
            {
                
                bullet = new Bullet(direction);
                if (direction == Bullet.bulletsDirection.RIGHT)
                {
                    bullet.X = this.X + Sprite.Width;
                    bullet.Y = this.Y + Sprite.Height / 2;
                }
                if (direction == Bullet.bulletsDirection.LEFT)
                {
                    bullet.X = this.X - bullet.Width;
                    bullet.Y = this.Y + Sprite.Height / 2;
                }
                if (direction == Bullet.bulletsDirection.UP)
                {
                    bullet.X = this.X + Sprite.Width / 2 - (bullet.Width / 2);
                    bullet.Y = this.Y-bullet.Height;
                }
                if (direction == Bullet.bulletsDirection.DOWN)
                {
                    bullet.X = this.X + Sprite.Width/2-(bullet.Width/2);
                    bullet.Y = this.Y + Sprite.Height;
                }
                bulletsShot.Add(bullet);
                Engine.SpawnObject("bullet", bullet);
                bullet.isShoot = true;
                Engine.Timer.Set("coolDown", 0.5f);
            }
        }

        public void Movement()
        {
            if (Engine.IsKeyDown(keyMap.left))
            {
                X -= movSpeed * DeltaTime;
                direction = Bullet.bulletsDirection.LEFT;
            }
            if (Engine.IsKeyDown(keyMap.right))
            {
                X += movSpeed * DeltaTime;
                direction = Bullet.bulletsDirection.RIGHT;

            }
            if (Engine.IsKeyDown(keyMap.up))
            {
                Y -= movSpeed * DeltaTime;
                direction = Bullet.bulletsDirection.UP;

            }
            if (Engine.IsKeyDown(keyMap.down)) 
            {
                direction = Bullet.bulletsDirection.DOWN;
                if (CheckCollisions().Count == 0)
                {
                    Y += movSpeed * DeltaTime;
                    if (this.Y > Engine.Height / 2)
                        Engine.Camera.Y = Y - Engine.Height / 2;

                    Engine.Camera.Update();
                }
            }
        }


    }
}
