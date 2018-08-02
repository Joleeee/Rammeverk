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
			Add(new Sprite(Loader.Load<Texture2D>("test"), new Position(new Vector2(20, 20), 0, null)));
			Add(new Sprite(Loader.Load<Texture2D>("test"), new Position(new Vector2(30, 20), 0, null)));
		}
	}
}
