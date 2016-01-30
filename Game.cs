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
		public static PlayerEarth player;
		public static EnemyEarthMedium enemy;
		public static EnviromentEarth enviromentEarth;
		//public static EnemyAirEasy enemyAir;


		public static void Init()
		{
			engine = new Engine("Game", 1280, 720, 60, true);

			Asset.BasePath = "../../assets/";

			Utils.LoadAssets(engine, "playerDefault", "playerDefault.png", 1, 1);
			player = new PlayerEarth(64, 96, true, "playerDefault");

			Utils.LoadAssets(engine, "background", "background.png", 1, 1);
			enviromentEarth = new EnviromentEarth(1280, 720);

			//         enemyAir = new EnemyAirEasy(engine, 64, 96);

			EnemyEarthEasy[] enemyEarths = new EnemyEarthEasy[Utils.Randomize(30, 31)];
			for (int i = 0; i < enemyEarths.Length; i++)
			{
				int rX, rY;
				do
				{
					rX = Utils.Randomize(1, 14);
					rY = Utils.Randomize(1, 30);
				} while (enviromentEarth.tiles[Utils.GetPos(rX, rY, 14)].tileType != TileType.None);
				enemyEarths[i] = new EnemyEarthEasy(engine, 64, 40, rX * 96 - 32, rY * 96);
			}

			Utils.LoadAssets(engine, "background", "background.png", 1, 1);
			enviromentEarth = new EnviromentEarth(1280, 720);

			Utils.LoadAssets(engine, "undestrWall", "undestrWall.png", 1, 1);
			Utils.LoadAssets(engine, "destrWall", "destrWall.png", 1, 1);

#if DEBUG
			engine.debugCollisions = true;
#endif

			engine.SpawnObject("player", player);
			//engine.SpawnObject("enemy", enemy);
			for (int i = 0; i < enviromentEarth.tiles.Length; i++)
			{
				engine.SpawnObject("wall" + i, enviromentEarth.tiles[i]);
			}
			for (int i = 0; i < enemyEarths.Length; i++)
			{
				engine.SpawnObject("enemy" + Utils.Randomize(0, Int32.MaxValue), enemyEarths[i]);
			}
			//engine.SpawnObject("enemyAir", enemyAir);

		}

		public static void Run()
		{
			engine.Run();
		}
	}
}
