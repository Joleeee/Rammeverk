using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	class Player : Sprite
	{
		Vector2 velocity;
		float speed = 24;
		public Player(Vector2 position) : base(
			new TextureRect(Loader.Load<Texture2D>("person"), Point.Zero, new Point(17, 24), 3, 0),
			position,
			Vector2.One,
			0,
			Color.White)
		{
			velocity = new Vector2(0, 0);
		}

		double timer;
		public override void Update(GameScreen gameScreen, GameTime gameTime)
		{
			var kbs = Keyboard.GetState();
			velocity *= 0.8f;
			if (kbs.IsKeyDown(Keys.Right))
				velocity.X += speed;
			if (kbs.IsKeyDown(Keys.Left))
				velocity.X -= speed;
			if (kbs.IsKeyDown(Keys.Down))
				velocity.Y += speed;
			if (kbs.IsKeyDown(Keys.Up))
				velocity.Y -= speed;
			if (kbs.IsKeyDown(Keys.Right) || kbs.IsKeyDown(Keys.Left) || kbs.IsKeyDown(Keys.Down) || kbs.IsKeyDown(Keys.Up))
				textureRect.current = 1 + (int)(gameTime.TotalGameTime.TotalSeconds * 8 % textureRect.frames.Length); //8 is fps
			textureRect.Animate(1/30f, 1, 2);
			position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

			
			
			var l = kbs.IsKeyDown(Keys.Left);
			var r = kbs.IsKeyDown(Keys.Right);
			if((l && r) || (!l && !r))
				timer = 0;
			else
			{
				timer += gameTime.ElapsedGameTime.TotalSeconds;
			}

			if (timer > 0.5f) //although it will porbably never happend if the deltatime > 0.5f we will have bugs! and therefore we should use while instead of if
			{
				gameScreen.Add(new Particle(
					new TextureRect(Loader.Load<Texture2D>("dust")),
					position + new Vector2(-5, 12),
					scale,
					rotation,
					gravity: new Vector2(0, 1),
					startVelocity: new Vector2(0, -2)));
				timer -= 0.5f;
			}

			base.Update(gameScreen, gameTime);
		}
	}
}
