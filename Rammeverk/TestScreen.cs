using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rammeverk
{
	class TestScreen : GameScreen
	{
		public override void LoadContent()
		{
			base.LoadContent();
			//Add(new Sprite(Loader.Load<Texture2D>("test"), new Position(new Vector2(70, 20), 0, null)));
			//Add(new Sprite(Loader.Load<Texture2D>("test"), new Position(new Vector2(90, 20), 0, null)));
			Add(new Player(new Position(new Vector2(20, 20))));
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}
	}
}
