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
			new TextureRect(Loader.Load<Texture2D>("person"), Point.Zero, new Point(17, 24), 2, 0),
			position,
			Vector2.One,
			0)
		{
			velocity = new Vector2(0, 0);
		}

		double timer;
		public override void Update(GameScreen gameScreen, GameTime gameTime)
		{
			textureRect.current = (textureRect.current + 1) % 2;
			var kbs = Keyboard.GetState();
			velocity *= 0.8f;
			Vector2 move = velocity;
			move.X += kbs.IsKeyDown(Keys.Right) ? speed : 0;
			move.X += kbs.IsKeyDown(Keys.Left) ? -speed : 0;
			move.Y += kbs.IsKeyDown(Keys.Down) ? speed : 0;
			move.Y += kbs.IsKeyDown(Keys.Up) ? -speed : 0;
			move = Vector2.Clamp(move, new Vector2(-speed), new Vector2(speed));
			velocity = move;
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
				position += new Vector2(-5, 12);
				gameScreen.Add(new Particle(
					new TextureRect(Loader.Load<Texture2D>("dust")),
					position,
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
