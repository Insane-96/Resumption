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
		private static PlayerEarth player;

		public static void Init()
		{
			engine = new Engine("Game", 1280, 720, 60, true);

			Asset.BasePath = "../../assets/";

			Utils.LoadAssets(engine, "playerDefault", "playerDefault.png", 1, 1);
			player = new PlayerEarth(64, 96, true, "playerDefault");

#if DEBUG
			engine.debugCollisions = true;
#endif

			engine.SpawnObject("player", player);
		}

		public static void Run()
		{
			engine.Run();
		}
	}
}
