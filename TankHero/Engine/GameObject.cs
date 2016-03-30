using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero.Engine
{
	public class GameObject
	{
		#region Fields

		#endregion

		#region Constructors

		public GameObject (IGame game, Texture2D texture, Vector2 position)
			: this (game, position)
		{
			Bounds = texture.Bounds;
			Animations = new AnimationManager (this, texture);
		}

		public GameObject (IGame game, Texture2D[] textures, Vector2 position)
			: this (game, position)
		{
			Bounds = textures [0].Bounds;
			Animations = new AnimationManager (this, textures);
		}

		GameObject (IGame game, Vector2 position)
		{
			Game = game;
			Position = position;
		}

		#endregion

		#region Properties

		public AnimationManager Animations { get; }

		public Rectangle Bounds { get; set; }

		public IGame Game { get; }

		public Vector2 Position { get; set; }

		public Texture2D Texture { get; set; }

		#endregion

		#region Methods

		#endregion

	}
}

