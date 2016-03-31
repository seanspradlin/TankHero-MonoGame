using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TexturePackerLoader;

namespace TankHero.Engine
{
	public class AnimationManager
	{
		#region Fields

		Dictionary<string, Animation> animations = new Dictionary<string, Animation> ();
		string currentAnimation;

		#endregion

		#region Constructors

		public AnimationManager (GameObject gameObject)
		{
			GameObject = gameObject;
			Game = gameObject.Game;
		}

		#endregion

		#region Properties

		public Animation CurrentAnimation {
			get {
				if (!String.IsNullOrWhiteSpace (currentAnimation)
				    && animations.ContainsKey (currentAnimation)) {
					return animations [currentAnimation];
				} else {
					return null;
				}
			}
		}

		public SpriteFrame CurrentFrame {
			get {
				return animations [currentAnimation].Frame;
			}
		}

		public SGame Game { get; }

		public GameObject GameObject { get; }

		public bool IsPlaying { get; private set; }

		public bool IsReverse { get; set; } = false;

		#endregion

		#region Methods

		public void Add (string key, SpriteFrame[] frames, int framerate = 0)
		{
			if (animations.ContainsKey (key)) {
				throw new Exception ("Animation key already exists");
			}

			animations.Add (key, new Animation (this, frames, framerate));
		}

		public void Remove (string key)
		{
			if (animations.ContainsKey (key)) {
				animations.Remove (key);
			}
		}

		public void Start ()
		{
			if (!String.IsNullOrWhiteSpace (currentAnimation)) {
				IsPlaying = true;
			} else {
				throw new ArgumentOutOfRangeException ("currentAnimation cannot be null");
			}
		}

		public void Start (string key)
		{
			if (animations.ContainsKey (key)) {
				IsPlaying = true;
				currentAnimation = key;
			} else {
				throw new KeyNotFoundException ();
			}
		}

		public void Stop ()
		{
			IsPlaying = false;
		}

		public void Update ()
		{
			if (IsPlaying && CurrentAnimation != null) {
				if (IsReverse) {
					CurrentAnimation.Previous ();
				} else {
					CurrentAnimation.Next ();
				}
			}
		}

		#endregion
	}
}

