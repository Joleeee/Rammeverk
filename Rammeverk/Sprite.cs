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
		public Vector2 position;
		public Vector2 scale;
		public float rotation;
		public Vector2 offset;

		public TextureRect textureRect;
		public Color color;
		public Sprite(TextureRect textureRect, Vector2 position, Vector2 scale, float rotation, Color color)
		{
			this.textureRect = textureRect;
			this.position = position;
			this.scale = scale;
			this.rotation = rotation;
			this.color = color;
			this.HitBox = new Rect(position, textureRect.size.ToVector2());
		}

		public virtual Rect HitBox { get; set; }

		public virtual void Update(GameScreen gameScreen, GameTime gameTime)
		{
			HitBox.position = position;
			HitBox.offset = offset;
		}

		public virtual void Draw(SpriteBatch spriteBatch, GameScreen gameScreen)
		{
			spriteBatch.Draw(textureRect, position + offset, scale, color, rotation);
		}

		public virtual void Hit(GameScreen gameScreen, IHittable other)
		{
			//Console.WriteLine("{0} got hit by {1} at {2}", this, other, position.Location.X);
		}
	}
}
