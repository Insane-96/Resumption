using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016
{
	static class Utils
	{
		private static Random r = new Random();
		public static int Randomize(int n, int m)
		{
			return r.Next(n, m);
		}

		public static void LoadAssets(Engine engine, string assetName, string pathName, int rows, int cols)
		{
			SpriteAsset spriteAsset = new SpriteAsset(pathName);
			int width = spriteAsset.Width/cols;
			int height = spriteAsset.Height/rows;
			for (int x = 0; x < cols; x++)
			{
				for (int y = 0; y < rows; y++)
				{
					engine.LoadAsset(assetName + "_" + x + "_" + y, new SpriteAsset(pathName, x*width, y*height, width, height));
				}
			}
		}
	}
}
