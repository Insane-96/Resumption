    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016.Enviroment
{
	class EnviromentEarth : Enviroment
	{
		public Tile[] tiles;

		public EnviromentEarth(int width, int height) : base(width, height)
		{
			tiles = new Tile[16 * 32];
			for (int x = 0; x < 16; x++)
			{
				for (int y = 0; y < 32; y++)
				{
					if (x == 0 || x == 15)
					{
						tiles[Utils.GetPos(x, y, 16)] = new Tile(80, 80, x * 80, y * 80, TileType.UndestrWall, Utils.GetPos(x, y, 16));
					}
					else if (y == 0)
					{
						tiles[Utils.GetPos(x, y, 16)] = new Tile(80, 80, x * 80, y * 80, TileType.None, Utils.GetPos(x, y, 16));
					}
					else
					{
						int r = Utils.Randomize(0, 10);
						if (r < 1)
						{
							tiles[Utils.GetPos(x, y, 16)] = new Tile(80, 80, x * 80, y * 80, TileType.UndestrWall, Utils.GetPos(x, y, 16));
						}
						else if (r < 3)
						{
							tiles[Utils.GetPos(x, y, 16)] = new Tile(80, 80, x * 80, y * 80, TileType.None, Utils.GetPos(x, y, 16));
						}
						else
						{
							tiles[Utils.GetPos(x, y, 16)] = new Tile(80, 80, x * 80, y * 80, TileType.DestrWall, Utils.GetPos(x, y, 16));
						}
					}
				}
			}
		}

		public override void Start()
		{
			base.Start();
			CurrentSprite = (SpriteAsset)Engine.GetAsset("background_0_0");
		}

		public override void Update()
		{
			base.Update();

		}
	}
}
