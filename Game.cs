using System;
using Aiv.Engine;
using OpenTK;
using Aiv.Vorbis;
using GlobalGameJam2016.EnemyList;
using GlobalGameJam2016.EnvironmentList;
using GlobalGameJam2016.PlayerList;

namespace GlobalGameJam2016
{
	static class Game
	{
		private static Engine engine;
		public static EnvironmentList.Enviroment currentEnvironment;
		public static Enemy[] enemies;
		public static Player[] players;
		//public static EnemyAirEasy enemyAir;

		public static void Init()
		{
			engine = new Engine("Game", 1280, 720, 60, false);

			Asset.BasePath = "../../assets/";

			players = new Player[4];

			Utils.LoadAssets(engine, "playerDefault", "playerDefault.png", 1, 1);
			Utils.LoadAssets(engine, "startHub", "base.png", 1, 1);
			currentEnvironment = new StartEnvironment(1280, 720);
			Utils.LoadAssets(engine, "hero", "images.png", 4, 4);
			players[0] = new PlayerAir(60, 80, true, "hero", EnviromentType.StartEnviroment);
			players[0].X = 600;
			players[0].Y = 130;
			players[1] = new PlayerFire(60, 80, false, "hero", EnviromentType.StartEnviroment);
			players[1].X = 800;
			players[1].Y = 330;
			players[2] = new PlayerEarth(60, 80, true, "hero", EnviromentType.StartEnviroment);
			players[2].X = 600;
			players[2].Y = 530;
			players[3] = new PlayerWater(60, 80, true, "hero", EnviromentType.StartEnviroment);
			players[3].X = 400;
			players[3].Y = 330;

			SpriteAsset sprite = new SpriteAsset("Montagna.png", 0, 0);
			Utils.LoadAssets(engine, "PlayerFire", "PlayerFire.png", 6, 4);
			Utils.LoadAssets(engine, "LeftFire", "LeftFire.png", 2, 4);

			Utils.LoadAssets(engine, "backgroundEarth", "backgroundEarth.png", 1, 1);
			Utils.LoadAssets(engine, "backgroundFire", "backgroundFire.png", 1, 1);
			Utils.LoadAssets(engine, "backgroundAir", "Montagna.png", 1, 1);
			Utils.LoadAssets(engine, "backgroundWater", "Fondale.png", 1, 1);

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
			enviromentEarth = new EnviromentEarth(1280, 720);*/

			Utils.LoadAssets(engine, "undestrWall", "undestrWall.png", 1, 1);
			Utils.LoadAssets(engine, "destrWall", "destrWall.png", 1, 1);
			Utils.LoadAssets(engine, "cloud", "cloud.png", 1, 1);
			Utils.LoadAssets(engine, "blob", "Blob.png", 2, 3);
			Utils.LoadAssets(engine, "bullet", "EnemyHeart.png", 1, 2);

#if DEBUG
            engine.debugCollisions = true;
#endif
			engine.SpawnObject("startHub", currentEnvironment);
			engine.SpawnObject("player0", players[0]);
			engine.SpawnObject("player1", players[1]);
			engine.SpawnObject("player2", players[2]);
			engine.SpawnObject("player3", players[3]);
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

		public static void LoadEnviroment(EnvironmentList.Enviroment enviroment)
		{
			engine.RemoveObject(currentEnvironment);
			for (int i = 0; i < players.Length; i++)
			{
				engine.RemoveObject(players[i]);
			}
			currentEnvironment = enviroment;

			if (enviroment.GetType() == typeof(EnviromentEarth))
			{
				engine.SpawnObject("backgroundEarth", currentEnvironment);
				players[2].X = engine.Width / 2f;
				players[2].Y = -players[2].Height;
				engine.SpawnObject("player", players[2]);
				enemies = new EnemyEarth[Utils.Randomize(3, 7)];
				for (int i = 0; i < enemies.Length; i++)
				{
					int rX, rY;
					do
					{
						rX = Utils.Randomize(1, 15);
						rY = Utils.Randomize(1, 32);
					} while (currentEnvironment.tiles[Utils.GetPos(rX, rY, 14)].tileType != TileType.None);
					if (Utils.Randomize(0, 100) < 25)
						enemies[i] = new EnemyEarthMedium(engine, rX * 80, rY * 80);
					else
						enemies[i] = new EnemyEarthEasy(engine, rX * 80, rY * 80);
				}
				for (int i = 0; i < currentEnvironment.tiles.Length; i++)
				{
					engine.SpawnObject("wall" + i, currentEnvironment.tiles[i]);
				}
				for (int i = 0; i < enemies.Length; i++)
				{
					engine.SpawnObject("enemy" + Utils.Randomize(0, Int32.MaxValue), enemies[i]);
				}
			}
			if (enviroment.GetType() == typeof(EnviromentWater))
			{
				engine.SpawnObject("backgroundWater", currentEnvironment);
				players[3].X = engine.Width / 2f;
				players[3].Y = 0;
				engine.SpawnObject("player", players[3]);
				enemies = new EnemyWater[Utils.Randomize(10, 15)];
				for (int i = 0; i < enemies.Length; i++)
				{
					int rX, rY;
					rY = 0;

					rX = Utils.Randomize(1, 4);
					if (rX == 1)
					{
						rY = Utils.Randomize(1, engine.Width);
					}
					else if (rX == 2)
					{
						rX = engine.Width - 60;
						rY = Utils.Randomize(1, engine.Height);
					}
					else if (rX == 3)
					{
						rX = Utils.Randomize(1, engine.Width);
						rY = engine.Height - 80;
					}

					if (Utils.Randomize(0, 100) < 25)
						enemies[i] = new EnemyWaterMedium(engine, rX, rY);
					else
						enemies[i] = new EnemyWaterEasy(engine, rX, rY);
				}
				for (int i = 0; i < enemies.Length; i++)
				{
					engine.SpawnObject("enemy" + Utils.Randomize(0, Int32.MaxValue), enemies[i]);
				}

			}

			if (enviroment.GetType() == typeof(EnviromentAir))
			{
				engine.SpawnObject("Montagna", currentEnvironment);

				players[0].X = engine.Width / 2f;
				players[0].Y = engine.Height + players[0].Height;
				engine.SpawnObject("player", players[0]);

				for (int i = 0; i < currentEnvironment.tiles.Length; i++)
				{
					engine.SpawnObject("platform" + i, currentEnvironment.tiles[i]);
				}

			}
			if (enviroment.GetType() == typeof(EnviromentFire))
			{

				engine.SpawnObject("Fire", currentEnvironment);

				players[1].X = engine.Width / 2f;
				players[1].Y = (80 * 32) - players[1].Height;
				engine.SpawnObject("player", players[1]);
				engine.Camera.Y = players[1].Y - engine.Height / 2;
				enemies = new EnemyEarth[Utils.Randomize(3, 7)];
				for (int i = 0; i < enemies.Length; i++)
				{
					int rX, rY;
					do
					{
						rX = Utils.Randomize(1, 15);
						rY = Utils.Randomize(1, 32);
					} while (currentEnvironment.tiles[Utils.GetPos(rX, rY, 14)].tileType != TileType.None);
					if (Utils.Randomize(0, 100) < 25)
						enemies[i] = new EnemyEarthMedium(engine, rX * 80, rY * 80);
					else
						enemies[i] = new EnemyEarthEasy(engine, rX * 80, rY * 80);
				}
				for (int i = 0; i < currentEnvironment.tiles.Length; i++)
				{
					engine.SpawnObject("wall" + i, currentEnvironment.tiles[i]);
				}
				for (int i = 0; i < enemies.Length; i++)
				{
					engine.SpawnObject("enemy" + Utils.Randomize(0, Int32.MaxValue), enemies[i]);
				}


			}
		}
	}
}