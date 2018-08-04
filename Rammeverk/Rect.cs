using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	public class Rect
	{
		public Vector2 position;
		public Vector2 size;
		public Vector2 offset;
		public Rect(Vector2 position, Vector2 size, Vector2? offset)
		{
			this.position = position;
			this.size = size;
			this.offset = offset == null ? new Vector2(0, 0) : (Vector2)offset;
		}

		public Rect(ref Vector2 position, ref Vector2 size, Vector2? offset)
		{
			this.position = position;
			this.size = size;
			this.offset = offset == null ? new Vector2(0, 0) : (Vector2)offset;
		}

		public Vector2 Min
		{
			get
			{
				return position - offset;
			}
		}

		public Vector2 Max
		{
			get
			{
				return position - offset + size;
			}
		}
	}
}
