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
		private Vector2 centerOffset;
		public Rect(Vector2 position, Vector2 size)
		{
			this.position = position;
			this.size = size;
			this.centerOffset = size/2;
		}

		public Vector2 Min
		{
			get
			{
				return position - offset - centerOffset;
			}
		}

		public Vector2 Max
		{
			get
			{
				return position - offset - centerOffset + size;
			}
		}
	}
}
