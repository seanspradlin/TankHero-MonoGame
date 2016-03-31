using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;
using System.Diagnostics;

namespace TankHero.Engine
{
	public class Animation
	{
		#region Fields

		bool isPlaying = true;
		int currentFrame = 0;
		int lastChange = 0;
		SpriteFrame[] frames;

		#endregion

		#region Constructors

		public Animation (AnimationManager m, SpriteFrame[] f, int fps = 0)
		{
			if (f.Length == 0) {
				throw new Exception ("There must be at least one texture");
			}

			frames = f;
			FramesPerSecond = fps;
		}

		#endregion

		#region Properties

		public SpriteFrame Frame {
			get {
				return frames [currentFrame];
			}
		}

		public int FramesPerSecond { get; set; }

		int delta { 
			get {
				if (FramesPerSecond == 0) {
					return -1;
				}
				return 1000 / FramesPerSecond;
			}
		}

		#endregion

		#region Methods

		public void Start ()
		{
			if (frames.Length > 0) {
				isPlaying = true;
			}
		}

		public void Stop ()
		{
			isPlaying = false;
		}

        public void Previous (GameTime gameTime)
        {
            if (currentFrame > 0)
            {
                currentFrame--;
            } else
            {
                currentFrame = frames.Length;
            }
        }

        public void Next(GameTime gameTime)
        {
            if (currentFrame < frames.Length)
            {
                lastChange = gameTime.ElapsedGameTime.Milliseconds;
                currentFrame++;
            }
            else
            {
                currentFrame = 0;
            }
        }

        #endregion
    }
}

