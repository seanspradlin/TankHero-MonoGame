using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;

namespace TankHero.Engine
{
	public class GameObject : GameComponent
	{
		#region Fields

		SpriteFrame _sprite;

		#endregion

		#region Constructors

		public GameObject (SGame game, SpriteFrame spriteFrame, Vector2 position) : base (game as Game)
		{
			Game = game;
			Position = position;
			game.Components.Add (this);
			_sprite = spriteFrame;
		}

		#endregion

		#region Properties

		public AnimationManager Animations { get; } = new AnimationManager();

		public Rectangle Bounds { get; set; }

		public new SGame Game { get; }

		public Vector2 Position { get; set; }

		public SpriteFrame Sprite { 
			get {
				if (!Animations.IsPlaying) {
					return _sprite;
				} else {
					return Animations.CurrentFrame;
				}
			}
		}

		#endregion

		#region Methods

		public override void Update (GameTime gameTime)
		{
			Animations.Update (gameTime);
			base.Update (gameTime);
		}

		public void Draw (GameTime gameTime, SpriteRender render)
		{
			render.Draw (Sprite, Position);
		}

		#endregion

	}
}

