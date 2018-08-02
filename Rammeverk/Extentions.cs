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
		public static void Draw(this SpriteBatch spriteBatch, Texture2D texture, Position position)
		{
			spriteBatch.Draw(texture, position.Location, null, Color.White, position.Rotation, position.Origin, position.Scale, SpriteEffects.None, 0);
		}
	}
}
