using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	class Sprite : IDrawable, IUpdateable, IHittable
	{
		Position position;
		Texture2D texture;
		public Sprite(Texture2D texture, Position position)
		{
			this.texture = texture;
			this.position = position;
			this.HitBox = new Rect(ref position, texture.Bounds.Size.ToVector2());
		}

		public Rect HitBox { get; set; }

		//private Rect hitBox;
		//public Rect HitBox { get { return hitBox; } set { hitBox = value; } }

		public void Draw(SpriteBatch spriteBatch, GameScreen gameScreen)
		{
			spriteBatch.Draw(texture, position);
		}

		public void Hit(GameScreen gameScreen, IHittable other)
		{
			Console.WriteLine("{0} got hit by {1} at {2}", this, other, position.Location.X);
		}

		public void Update(GameScreen gameScreen, GameTime gameTime)
		{
			position.Location.X += 1;
			Console.WriteLine(position.Location.X);
		}
	}
}
