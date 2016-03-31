using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TexturePackerLoader;

namespace TankHero.Engine
{
	public class SGame : Game
	{
		#region Fields

		protected SpriteBatch spriteBatch;
		protected GraphicsDeviceManager graphics;

		#endregion

		#region Constructors

		public SGame ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
		}

		#endregion

		#region Properties

		public SpriteRender Renderer { get; private set; }

		public GameTime Time { get; set; }

		#endregion

		#region Methods

		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch (GraphicsDevice);
			Renderer = new SpriteRender (spriteBatch);
			base.LoadContent ();
		}

		protected override void Update (GameTime gameTime)
		{
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif
			Time = gameTime;
			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			Time = gameTime;
			base.Draw (gameTime);
		}

		#endregion
	}
}

