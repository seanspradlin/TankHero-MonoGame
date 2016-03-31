using System;
using Microsoft.Xna.Framework;
using TexturePackerLoader;

namespace TankHero.Engine
{
	public class Animation
	{
		#region Fields

		int currentFrame = 0;
		int lastChange = 0;
		SpriteFrame[] frames;

		#endregion

		#region Constructors

		public Animation (SpriteFrame[] f, int fps = 0)
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

