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
			Animations = new AnimationManager (this);
		}

		#endregion

		#region Properties

		public AnimationManager Animations { get; }

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

		public virtual void Update ()
		{
			Animations.Update ();
			base.Update (Game.Time);
		}

		public void Draw ()
		{
			Game.Renderer.Draw (Sprite, Position);
		}

		#endregion

	}
}

