using System;
using Microsoft.Xna.Framework;
using TankHero.Engine;
using TexturePackerLoader;
using TexturePackerMonoGameDefinitions;

namespace TankHero
{
	public class Player : GameObject
	{
		#region Fields

		#endregion

		#region Constructors

		public Player (Game game, Vector2 position, SpriteSheet spriteSheet) : base (game, position)
		{
			var defaultAnim = new[] {
				spriteSheet.Sprite (sprites.Player_body_1),
				spriteSheet.Sprite (sprites.Player_body_2),
				spriteSheet.Sprite (sprites.Player_body_3),
				spriteSheet.Sprite (sprites.Player_body_4),
				spriteSheet.Sprite (sprites.Player_body_5),
				spriteSheet.Sprite (sprites.Player_body_6),
			};
			Animations = new AnimationManager (this, defaultAnim, 15);
		}

		#endregion

		#region Properties

		#endregion

		#region Methods

		public override void Update (GameTime gameTime)
		{
			Animations.Update (gameTime);
			base.Update (gameTime);
		}

		#endregion
	}
}

