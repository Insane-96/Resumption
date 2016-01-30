using System;
using Aiv.Engine;
using OpenTK;
using GlobalGameJam2016.EnemyList;
using GlobalGameJam2016.PlayerList;

namespace GlobalGameJam2016
{
	static class Game
	{
		private static Engine engine;
		public static PlayerEarth player;
		public static EnemyEarthMedium enemy;
        public static EnemyAirEasy enemyAir;


        public static void Init()
		{
			engine = new Engine("Game", 1280, 720, 60, false);

			Asset.BasePath = "../../assets/";

			Utils.LoadAssets(engine, "playerDefault", "playerDefault.png", 1, 1);
			player = new PlayerEarth(64, 96, true, "playerDefault");
			
			enemy = new EnemyEarthMedium(engine, 64, 96);
            enemyAir = new EnemyAirEasy(engine, 64, 96);

#if DEBUG
            engine.debugCollisions = true;
#endif

			engine.SpawnObject("player", player);
			engine.SpawnObject("enemy", enemy);
			//engine.SpawnObject("enemyAir", enemyAir);

        }

        public static void Run()
		{
			engine.Run();
		}
	}
}
