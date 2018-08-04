using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	public struct Position
	{
		public Vector2 Location;
		public float Rotation;
		public Vector2 Scale;
		public Position(Vector2 Location, float Rotation = 0, Vector2? Scale = null)
		{
			this.Location = Location;
			this.Rotation = Rotation;
			this.Scale = (Scale == null) ? new Vector2(1, 1) : (Vector2)Scale;
		}
	}
}
