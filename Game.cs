using System;
using Aiv.Engine;
using OpenTK;
using GlobalGameJam2016.EnemyList;
using GlobalGameJam2016.Enviroment;
using GlobalGameJam2016.PlayerList;

namespace GlobalGameJam2016
{
	static class Game
	{
		private static Engine engine;
		public static PlayerEarth player3;
        public static PlayerAir player;
        public static PlayerFire player2;
        public static PlayerWater player4;
		public static EnemyEarthMedium enemy;
		public static EnviromentEarth enviromentEarth;
        public static StartEnvironment startEnvironment;
		//public static EnemyAirEasy enemyAir;


		public static void Init()
		{
			engine = new Engine("Game", 1280, 720, 60, false);

			Asset.BasePath = "../../assets/";

			/*Utils.LoadAssets(engine, "playerDefault", "playerDefault.png", 1, 1);
			player = new PlayerEarth(60, 80, true, "playerDefault");*/
            Utils.LoadAssets(engine, "startHub", "base.png", 1, 1);
            startEnvironment = new StartEnvironment(1280, 720);
            Utils.LoadAssets(engine, "hero", "images.png", 4, 4);
            player = new PlayerAir(60, 80, true, "hero");
            player.X = 600;
            player.Y = 130;
            player2 = new PlayerFire(60, 80, true, "hero");
            player2.X = 800;
            player2.Y = 330;
            player3 = new PlayerEarth(60, 80, true, "hero");
            player3.X = 600;
            player3.Y = 530;
            player4 = new PlayerWater(60, 80, true, "hero");
            player4.X = 400;
            player4.Y = 330;
			/*Utils.LoadAssets(engine, "background", "background.png", 1, 1);
			enviromentEarth = new EnviromentEarth(1280, 720);

			EnemyEarth[] enemyEarths = new EnemyEarth[Utils.Randomize(3, 7)];
			for (int i = 0; i < enemyEarths.Length; i++)
			{
				int rX, rY;
				do
				{
					rX = Utils.Randomize(1, 15);
					rY = Utils.Randomize(1, 32);
				} while (enviromentEarth.tiles[Utils.GetPos(rX, rY, 14)].tileType != TileType.None);
				if (Utils.Randomize(0, 100) < 25)
					enemyEarths[i] = new EnemyEarthMedium(engine, rX * 80, rY * 80);
				else
					enemyEarths[i] = new EnemyEarthMedium(engine, rX * 80, rY * 80);
			}

			Utils.LoadAssets(engine, "background", "background.png", 1, 1);
			enviromentEarth = new EnviromentEarth(1280, 720);

		//	Utils.LoadAssets(engine, "undestrWall", "undestrWall.png", 1, 1);
		//	Utils.LoadAssets(engine, "destrWall", "destrWall.png", 1, 1);*/

#if DEBUG
			engine.debugCollisions = true;
#endif
            engine.SpawnObject("startHub", startEnvironment);
			engine.SpawnObject("player", player);
            engine.SpawnObject("player2", player2);
            engine.SpawnObject("player3", player3);
            engine.SpawnObject("player4", player4);
			//engine.SpawnObject("enemy", enemy);
			/*for (int i = 0; i < enviromentEarth.tiles.Length; i++)
			{
				engine.SpawnObject("wall" + i, enviromentEarth.tiles[i]);
			}
			for (int i = 0; i < enemyEarths.Length; i++)
			{
				engine.SpawnObject("enemy" + Utils.Randomize(0, Int32.MaxValue), enemyEarths[i]);
			}
			//engine.SpawnObject("enemyAir", enemyAir);*/

		}
        
		public static void Run()
		{
			engine.Run();
		}
	}
}
