using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	public interface IListable
	{

	}

	public interface IDrawable : IListable
	{
		void Draw(SpriteBatch spriteBatch, GameScreen gameScreen);
	}

	public interface IUpdateable : IListable
	{
		void Update(GameScreen gameScreen, GameTime gameTime);
	}
}
