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

		public Player (SGame game, SpriteFrame sprite, Vector2 position, SpriteSheet spriteSheet) : base (game, sprite, position)
		{
			var defaultAnim = new[] {
				spriteSheet.Sprite (sprites.Player_body_1),
				spriteSheet.Sprite (sprites.Player_body_2),
				spriteSheet.Sprite (sprites.Player_body_3),
				spriteSheet.Sprite (sprites.Player_body_4),
				spriteSheet.Sprite (sprites.Player_body_5),
				spriteSheet.Sprite (sprites.Player_body_6),
			};
			Animations.Add ("default", defaultAnim, 15);
			Animations.Start ("default");

			AddChild ("cannon", spriteSheet.Sprite (sprites.Player_cannon_1), new Vector2 (-50, -20));
		}

		#endregion

		#region Properties

		#endregion

		#region Methods

		public override void Update ()
		{
			base.Update ();
		}

		#endregion
	}
}

