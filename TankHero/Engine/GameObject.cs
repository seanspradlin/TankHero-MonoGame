using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;

namespace TankHero.Engine
{
	public class GameObject : GameComponent
	{
		#region Fields

		#endregion

		#region Constructors

		public GameObject (Game game, SpriteFrame frame, Vector2 position)
			: this (game, position)
		{
//			Bounds = SpriteFrame.Bounds;
			Animations = new AnimationManager (this, frame);
		}

		public GameObject (Game game, SpriteFrame[] frames, Vector2 position)
			: this (game, position)
		{
//			Bounds = textures [0].Bounds;
			Animations = new AnimationManager (this, frames);
		}

		public GameObject (Game game, Vector2 position)
			: base (game)
		{
			Position = position;
			game.Components.Add (this);
		}

		#endregion

		#region Properties

		public AnimationManager Animations { get; protected set; }

		public Rectangle Bounds { get; set; }

		public Vector2 Position { get; set; }

		public SpriteFrame Texture { 
			get { 
				return Animations.CurrentFrame;
			}
		}

		#endregion

		#region Methods

		public void Draw (GameTime gameTime, SpriteRender render)
		{
			render.Draw (Animations.CurrentFrame, Position);
		}

		#endregion

	}
}

