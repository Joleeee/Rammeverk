using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	public class Sprite : IDrawable, IUpdateable, IHittable
	{
		public Position position;
		public TextureRect texture;
		public Color color;
		public Sprite(TextureRect texture, Position position)
		{
			this.texture = texture;
			this.position = position;
			this.HitBox = new Rect(ref position, texture.texture.Bounds.Size.ToVector2(), texture.texture.GetCenter());
		}

		public Sprite(ref TextureRect texture, ref Position position)
		{
			this.texture = texture;
			this.position = position;
			this.HitBox = new Rect(ref position, texture.texture.Bounds.Size.ToVector2(), texture.texture.GetCenter());
		}

		public virtual Rect HitBox { get; set; }

		public virtual void Draw(SpriteBatch spriteBatch, GameScreen gameScreen)
		{
			spriteBatch.Draw(texture, position, color);
		}

		public virtual void Hit(GameScreen gameScreen, IHittable other)
		{
			//Console.WriteLine("{0} got hit by {1} at {2}", this, other, position.Location.X);
		}

		public virtual void Update(GameScreen gameScreen, GameTime gameTime)
		{

		}
	}
}
