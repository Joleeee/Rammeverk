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

		public TextureRect textureRect;
		public Color color;
		public Sprite(TextureRect textureRect, Vector2 position, Vector2 scale, float rotation)
		{
			this.textureRect = textureRect;
			this.position = position;
			this.scale = scale;
			this.rotation = rotation;
			this.HitBox = new Rect(position, textureRect.size.ToVector2(), textureRect.size.ToVector2()/2);
		}

		public Rect HitBox { get; set; } = new Rect(Vector2.Zero, Vector2.Zero, Vector2.Zero);

		public virtual void Draw(SpriteBatch spriteBatch, GameScreen gameScreen)
		{
			spriteBatch.Draw(textureRect, position, scale, color, rotation);
		}

		public virtual void Hit(GameScreen gameScreen, IHittable other)
		{
			//Console.WriteLine("{0} got hit by {1} at {2}", this, other, position.Location.X);
		}

		public virtual void Update(GameScreen gameScreen, GameTime gameTime)
		{
			Rect hb = HitBox;
			hb.position = position;
			HitBox = hb;
			HitBox.position = position;
		}
	}
}
