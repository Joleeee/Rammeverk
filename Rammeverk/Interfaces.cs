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
		//Used by all so we can have them in one list
	}

	public interface IDrawable : IListable
	{
		void Draw(SpriteBatch spriteBatch, GameScreen gameScreen);
	}

	public interface IUpdateable : IListable
	{
		void Update(GameScreen gameScreen, GameTime gameTime);
	}

	public interface IHittable : IListable
	{
		Rect HitBox { get; set; }
		void Hit(GameScreen gameScreen, IHittable other);
	}
}
