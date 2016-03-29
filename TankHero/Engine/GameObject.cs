using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero
{
	namespace Engine
	{
		public class GameObject
		{
			public AnimationManager Animations { get; }

			public Vector2 Position { get; set; }

			public Texture2D Texture { get; set; }

			public Rectangle Bounds { get; set; }

			TankHero game;

			public GameObject (TankHero g, Texture2D texture, Vector2 position)
			{
				game = g;
				Position = position;
				Texture = texture;
				Bounds = texture.Bounds;
				Animations = new AnimationManager (this);
			}
		}
	}
}
	
