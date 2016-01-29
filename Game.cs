using System;
using System.Collections.Generic;
using System.Drawing;
using Aiv.Engine;
using OpenTK;

namespace GlobalGameJam2016
{
	static class Game
	{
		private static Engine engine;

		public static void Init()
		{
			Engine engine = new Engine("Game", 1280, 720, 60, true);
			TextObject Text = new TextObject(new Vector2(1, 1), new Color(), 1f, new TextConfig(new Asset("../../assets/fontCalibri.png"), new Dictionary<char, Tuple<Vector2, Vector2>>()
			{
				{'A', new Tuple<Vector2, Vector2>( new Vector2(7, 9), new Vector2(85, 99))}
			}));
		}

		public static void Run()
		{
			engine.Run();
		}
	}
}
