using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;

namespace TankHero.Engine
{
	public class AnimationManager
	{
		#region Fields

		Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
        string currentAnimation;
        bool isPlaying = false;

        #endregion

        #region Properties

        public Animation CurrentAnimation {
            get {
                if (!String.IsNullOrWhiteSpace(currentAnimation) 
                    && animations.ContainsKey(currentAnimation))
                {
                    return animations[currentAnimation];
                }
                else
                {
                    return null;
                }
            }
        }

        public SpriteFrame CurrentFrame {
			get {
				return animations [currentAnimation].Frame;
			}
		}

        public bool Reverse { get; set; } = false;

		#endregion

		#region Methods

		public void Add (string key, SpriteFrame[] frames, int framerate = 0)
		{
            if (animations.ContainsKey(key))
            {
                throw new Exception("Animation key already exists");
            }

			animations.Add (key, new Animation (frames, framerate));
		}

        public void Remove(string key)
        {
            if (animations.ContainsKey(key))
            {
                animations.Remove(key);
            }
        }

        public void Start()
        {
            if (!String.IsNullOrWhiteSpace(currentAnimation))
            {
                isPlaying = true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("currentAnimation cannot be null");
            }
        }

		public void Start (string key)
		{
			if (animations.ContainsKey (key)) {
                isPlaying = true;
				currentAnimation = key;
			} else {
				throw new KeyNotFoundException ();
			}
		}

        public void Stop ()
        {
            isPlaying = false;
        }

		public void Update (GameTime gameTime)
		{
            if (isPlaying && CurrentAnimation != null)
            {
                if (Reverse)
                {
                    CurrentAnimation.Next(gameTime);
                } else
                {
                    CurrentAnimation.Previous(gameTime);
                }
            }
        }

		#endregion
	}
}

