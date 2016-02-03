using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Engine;

namespace GlobalGameJam2016.Enviroment
{
	enum TileType
	{
		None,
		UndestrWall,
		DestrWall,
        Cloud
	}

	class Tile : SpriteObject
	{
		public TileType tileType;
		private int id;
		public Tile(int width, int height, int posX, int posY, TileType tileType, int id) : base(width, height, true, "Wall_" + id)
		{
			X = posX;
			Y = posY;
			this.tileType = tileType;
			this.id = id;
		}

		public override void Start()
		{
			base.Start();
			if (tileType == TileType.UndestrWall)
				CurrentSprite = (SpriteAsset)Engine.GetAsset("undestrWall_0_0");
			else if (tileType == TileType.DestrWall)
				CurrentSprite = (SpriteAsset)Engine.GetAsset("destrWall_0_0");
		}

		public override void Update()
		{
			base.Update();
			if (tileType == TileType.UndestrWall)
				CurrentSprite = (SpriteAsset)Engine.GetAsset("undestrWall_0_0");
			else if (tileType == TileType.DestrWall)
				CurrentSprite = (SpriteAsset)Engine.GetAsset("destrWall_0_0");
			else if (tileType == TileType.None)
			{
				this.Destroy();
			}
		}
	}
}
