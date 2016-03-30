using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero.Engine
{
	public class GameObject : GameComponent
	{
		#region Fields

		#endregion

		#region Constructors

		public GameObject (Game game, Texture2D texture, Vector2 position)
			: this (game, position)
		{
			Bounds = texture.Bounds;
			Animations = new AnimationManager (this, texture);
		}

		public GameObject (Game game, Texture2D[] textures, Vector2 position)
			: this (game, position)
		{
			Bounds = textures [0].Bounds;
			Animations = new AnimationManager (this, textures);
		}

		GameObject (Game game, Vector2 position)
			: base (game)
		{
			Position = position;
			game.Components.Add (this);
		}

		#endregion

		#region Properties

		public AnimationManager Animations { get; }

		public Rectangle Bounds { get; set; }

		public Vector2 Position { get; set; }

		public Texture2D Texture { get; set; }

		#endregion

		#region Methods

		#endregion

	}
}

