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
			tiles = new Tile[14 * 30];
			for (int x = 0; x < 14; x++)
			{
				for (int y = 0; y < 30; y++)
				{
					if (x == 0 || x == 13)
					{
						tiles[Utils.GetPos(x, y, 14)] = new Tile(96, 96, x * 96 - 32, y * 96, TileType.UndestrWall, Utils.GetPos(x, y, 14));
					}
					else if (y == 0)
					{
						tiles[Utils.GetPos(x, y, 14)] = new Tile(96, 96, x * 96 - 32, y * 96, TileType.None, Utils.GetPos(x, y, 14));
					}
					else
					{
						int r = Utils.Randomize(0, 10);
						if (r < 1)
						{
							tiles[Utils.GetPos(x, y, 14)] = new Tile(96, 96, x * 96 - 32, y * 96, TileType.UndestrWall, Utils.GetPos(x, y, 14));
						}
						else if (r < 3)
						{
							tiles[Utils.GetPos(x, y, 14)] = new Tile(96, 96, x * 96 - 32, y * 96, TileType.None, Utils.GetPos(x, y, 14));
						}
						else
						{
							tiles[Utils.GetPos(x, y, 14)] = new Tile(96, 96, x * 96 - 32, y * 96, TileType.DestrWall, Utils.GetPos(x, y, 14));
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
