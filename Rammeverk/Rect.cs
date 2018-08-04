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
		public Vector2 offset;
		public Rect(Position position, Vector2 size, Vector2? offset)
		{
			this.position = position;
			this.size = size;
			this.offset = offset == null ? new Vector2(0, 0) : (Vector2)offset;
		}

		public Rect(ref Position position, Vector2 size, Vector2? offset)
		{
			this.position = position;
			this.size = size;
			this.offset = offset == null ? new Vector2(0, 0) : (Vector2)offset;
		}

		public Vector2 Min
		{
			get
			{
				return position.Location - offset;
			}
		}

		public Vector2 Max
		{
			get
			{
				return position.Location - offset + size;
			}
		}
	}
}
