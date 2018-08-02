using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	public struct Rect
	{
		public Position position;
		public Vector2 size;
		public Rect(Position position, Vector2 size)
		{
			this.position = position;
			this.size = size;
		}

		public Rect(ref Position position, Vector2 size)
		{
			this.position = position;
			this.size = size;
		}

		public Vector2 Min
		{
			get
			{
				return position.Location - position.Origin;
			}
		}

		public Vector2 Max
		{
			get
			{
				return position.Location  - position.Origin + size;
			}
		}
	}
}
