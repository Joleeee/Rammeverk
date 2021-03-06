﻿using Microsoft.Xna.Framework;
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
		float speed = 6;
		public Player(Vector2 position) : base(
			new TextureRect(Loader.Load<Texture2D>("person"), Point.Zero, new Point(9, 12), 3, 0),
			position,
			Vector2.One,
			0,
			Color.White)
		{
			velocity = new Vector2(0, 0);
		}

		double timer;
		double walkingTime = 0;
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
			{
				textureRect.Animate(1 / 30f, 1, 2);
				walkingTime += gameTime.ElapsedGameTime.TotalSeconds;
			}
			else
				textureRect.SetFrame(0, 0, 0);
			position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

			var scaleSpeed = 8;
			var amount = 0.1f;
			scale.X = 1 + 0.5f * (2 * amount * (float)Math.Cos((walkingTime * scaleSpeed) % (Math.PI * 2)));
			scale.Y = 1 +        (1 * amount * (float)Math.Sin((walkingTime * scaleSpeed) % (Math.PI * 2)));
			offset.Y = (1 - scale.Y) * textureRect.size.Y * 0.5f;
			Console.WriteLine(scale.Y - 1);
			
			
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
