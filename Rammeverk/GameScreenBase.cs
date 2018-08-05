using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Rammeverk
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class GameScreenBase : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		private GameScreen activeGameScreen;
		public GameScreen ActiveGameScreen { get { return activeGameScreen; } set { activeGameScreen = value; activeGameScreen.LoadContent(); } }

		Vector2 realResolution = new Vector2(128, 72);

		public GameScreenBase()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = (int)realResolution.X * 6;
			graphics.PreferredBackBufferHeight = (int)realResolution.Y * 6;
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			Randomizer.random = new System.Random();
			Window.AllowUserResizing = true;

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			Loader.ContentManager = Content;
			spriteBatch = new SpriteBatch(GraphicsDevice);
			if(activeGameScreen != null && activeGameScreen.loaded == false)
				activeGameScreen.LoadContent();
			// TODO: use this.Content to load your game content here
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			activeGameScreen.Update(gameTime);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			Vector2 resolution = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
			spriteBatch.Begin(transformMatrix: Matrix.CreateScale(resolution.X / realResolution.X, resolution.Y / realResolution.Y, 1), samplerState: SamplerState.PointClamp);
			activeGameScreen.Draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
		
	}
}
