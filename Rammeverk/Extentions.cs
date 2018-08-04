using Microsoft.Xna.Framework;
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
		public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Position position, Color? color = null)
		{
			Color realColor = color == null ? Color.White : (Color)color;
			spriteBatch.Draw(texture, position.Location, null, realColor, position.Rotation, texture.Bounds.Size.ToVector2()/2, position.Scale, SpriteEffects.None, 0);
		}

		public static void Draw(this SpriteBatch spriteBatch, TextureRect textureRect, Position position, Color? color = null)
		{
			Color realColor = color == null ? Color.White : (Color)color;
			spriteBatch.Draw(textureRect.texture, position.Location, textureRect.currentRectangle, realColor, position.Rotation, textureRect.currentRectangle.Size.ToVector2() / 2, position.Scale, SpriteEffects.None, 0);
		}

		public static Vector2 GetCenter(this Texture2D texture)
		{
			return texture.Bounds.Size.ToVector2() / 2;
		}

		public static bool Overlaps(this Rect a, Rect b)
		{
			if (a.Max.X < b.Min.Y || a.Max.Y < b.Min.Y) return false;
			if (a.Min.X > b.Max.X || a.Min.Y > b.Max.Y) return false;
			return true;
		}
	}
}
