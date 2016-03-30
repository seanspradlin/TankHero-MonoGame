using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero.Engine
{
	public class AnimationManager
	{
		#region Fields

		Dictionary<string, Animation> animations;
		string currentAnimation;
		GameObject gameObject;

		#endregion

		#region Constructors

		public AnimationManager (GameObject go, Texture2D texture)
			: this (go, new[] { texture })
		{
		}

		public AnimationManager (GameObject go, Texture2D[] textures)
		{
			gameObject = go;
			animations = new Dictionary<string, Animation> ();
			currentAnimation = "default";
			Game = gameObject.Game;
			Add (currentAnimation, textures);
		}

		#endregion

		#region Properties

		public Texture2D CurrentFrame {
			get {
				return animations [currentAnimation].Frame;
			}
		}

		public Game Game { get; }

		#endregion

		#region Methods

		public void Add (string key, Texture2D[] frames, int framerate = 0)
		{
			var animation = new Animation (this, frames, framerate);
			animations.Add (key, animation);
		}

		public void Play (string key)
		{
			if (animations.ContainsKey (key)) {
				currentAnimation = key;
			} else {
				throw new KeyNotFoundException ();
			}
		}

		#endregion
	}
}

