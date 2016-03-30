using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using TexturePackerLoader;
using TankHero.Engine;

namespace TankHero
{
	public class TankHero : Game
	{
		SpriteBatch spriteBatch;
		GraphicsDeviceManager graphics;
		SpriteSheet spriteSheet;
		SpriteRender spriteRender;

		public TankHero ()
		{
			graphics = new GraphicsDeviceManager (this);
			Content.RootDirectory = "Content";
		}

		protected override void LoadContent ()
		{
			var loader = new SpriteSheetLoader (Content);
			spriteSheet = loader.Load ("sprites");
			spriteBatch = new SpriteBatch (GraphicsDevice);
			spriteRender = new SpriteRender (spriteBatch);
		}

		protected override void Update (GameTime gameTime)
		{
			#if !__IOS__ &&  !__TVOS__
			if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
				Exit ();
			#endif
			base.Update (gameTime);
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			spriteBatch.Begin ();
			spriteRender.Draw (
				spriteSheet.Sprite (TexturePackerMonoGameDefinitions.sprites.Player_body_1),
				new Vector2 (150, 150)
			);
			spriteBatch.End ();

			base.Draw (gameTime);
		}
	}
}

