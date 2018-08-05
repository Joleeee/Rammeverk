using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rammeverk;

namespace RammeverkGame
{
	public class Game1 : GameScreenBase
	{
		protected override void LoadContent()
		{
			base.LoadContent();
			ActiveGameScreen = new TestScreen();
		}
	}
}
