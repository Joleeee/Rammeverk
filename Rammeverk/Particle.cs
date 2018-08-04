using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TinyTween;

namespace Rammeverk
{
	public class Particle : Sprite
	{
		public Vector2 gravity;
		public Vector2 velocity;
		public float decayTime;
		public ColorTween colorTween = new ColorTween();
		public Vector2Tween scaleTween = new Vector2Tween();

		public Particle(TextureRect texture, Position position, float decayTime = 1f, Vector2? gravity = null, Vector2? startVelocity = null)
			: base(texture, position)
		{
			this.decayTime = decayTime;
			this.gravity = gravity == null ? new Vector2(0, 0) : (Vector2)gravity;
			this.velocity = startVelocity == null ? new Vector2(0, 0) : (Vector2)startVelocity;
			this.colorTween.Start(Color.White, Color.Transparent, decayTime, ScaleFuncs.Linear);
			this.scaleTween.Start(position.Scale, new Vector2(0, 0), decayTime, ScaleFuncs.Linear);
		}

		public void Update(GameScreen gameScreen, GameTime gameTime)
		{
			velocity += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
			position.Location += velocity;

			var elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds / decayTime;
			colorTween.Update(elapsed);
			scaleTween.Update(elapsed);
			position.Scale = scaleTween.CurrentValue;

			var scale = position.Scale - new Vector2();
			position.Scale = Vector2.Clamp(scale, new Vector2(0, 0), scale);
			if (position.Scale.Length() == 0) gameScreen.Remove(this);
		}

		public void Draw(SpriteBatch spriteBatch, GameScreen gameScreen)
		{
			spriteBatch.Draw(texture, position, colorTween.CurrentValue);
		}
	}
}
