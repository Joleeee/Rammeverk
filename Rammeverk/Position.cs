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
		public Vector2 Origin;
		public Position(Vector2 Location, float Rotation = 0, Vector2? Scale = null, Vector2? Origin = null)
		{
			this.Location = Location;
			this.Rotation = Rotation;
			this.Scale = (Scale == null) ? new Vector2(1, 1) : (Vector2)Scale;
			this.Origin = (Origin == null) ? new Vector2(0, 0) : (Vector2)Origin;
		}
	}
}
