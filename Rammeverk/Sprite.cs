using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	class Sprite : IDrawable, IUpdateable
	{
		Position position;
		Texture2D texture;
		public Sprite(Texture2D texture, Position position)
		{
			this.texture = texture;
			this.position = position;
		}
		public void Draw(SpriteBatch spriteBatch, GameScreen gameScreen)
		{
			spriteBatch.Draw(texture, position);
		}

		public void Update(GameScreen gameScreen, GameTime gameTime)
		{
			position.Location.X += 1;
			Console.WriteLine(position.Location.X);
		}
	}
}
