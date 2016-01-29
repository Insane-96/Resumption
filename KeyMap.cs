using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;

namespace GlobalGameJam2016
{
	class KeyMap
	{
		public KeyCode up;
		public KeyCode down;
		public KeyCode left;
		public KeyCode right;
		public KeyCode action;
		public KeyCode attack;

		public KeyMap(KeyCode up, KeyCode down, KeyCode left, KeyCode right, KeyCode action, KeyCode attack)
		{
			this.up = up;
			this.down = down;
			this.left = left;
			this.right = right;
			this.action = action;
			this.attack = attack;
		}
	}
}
