using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero
{
	public class GameObject
	{
		public AnimationManager Animations;
		public Vector2 Position;
		public Texture2D Texture;
		public Rectangle Bounds;
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

	public class AnimationManager
	{
		GameObject gameObject;
		Dictionary<string, Animation> animations;

		public AnimationManager (GameObject go)
		{
			gameObject = go;
			Add ("default", new[]{ go.Texture });
		}

		public void Add (string key, Texture2D[] frames, int framerate = 0)
		{
			
		}

		public void Play (string key)
		{

		}

		public Texture2D Draw ()
		{
			
		}
	}

	public class Animation
	{
		public string Key { get; }

		Texture2D frames;
		AnimationManager manager;

		public Animation ()
		{
			
		}
	}
}
	
