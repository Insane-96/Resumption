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
			engine = new Engine("Game", 1280, 720, 60, true);
		}

		public static void Run()
		{
			engine.Run();
		}
	}
}
