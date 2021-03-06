﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	public static class Extentions
	{
		public static void Draw(this SpriteBatch spriteBatch, TextureRect textureRect, Vector2 position, Vector2 scale, Color color, float rotation = 0, float depth = 0)
		{
			spriteBatch.Draw(textureRect.texture, position, textureRect.currentRectangle, color, rotation, textureRect.currentRectangle.Size.ToVector2() / 2, scale, SpriteEffects.None, depth);
		}

		public static bool Overlaps(this Rect a, Rect b)
		{
			if (a.Max.X < b.Min.Y || a.Max.Y < b.Min.Y) return false;
			if (a.Min.X > b.Max.X || a.Min.Y > b.Max.Y) return false;
			return true;
		}
	}
}
