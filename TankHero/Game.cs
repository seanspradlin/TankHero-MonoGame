using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using TexturePackerLoader;
using TankHero.Engine;

namespace TankHero
{
	public class TankHero : SGame
	{
		SpriteSheet spriteSheet;
		Player player;

		protected override void LoadContent ()
		{
			var loader = new SpriteSheetLoader (Content);
			spriteSheet = loader.Load ("sprites");
			player = new Player (this, spriteSheet.Sprite (TexturePackerMonoGameDefinitions.sprites.Player_body_1), new Vector2 (200, 200), spriteSheet);
			base.LoadContent ();
		}

		protected override void Update (GameTime GameTime)
		{
			player.Update ();
		}

		protected override void Draw (GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			spriteBatch.Begin ();
//			spriteRender.Draw (
//				spriteSheet.Sprite (TexturePackerMonoGameDefinitions.sprites.Player_body_1),
//				new Vector2 (150, 150)
//			);
			player.Draw ();
			spriteBatch.End ();

			base.Draw (gameTime);
		}
	}
}

