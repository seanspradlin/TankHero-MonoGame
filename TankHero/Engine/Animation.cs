using System;
using Microsoft.Xna.Framework;
using TexturePackerLoader;

namespace TankHero.Engine
{
	public class Animation
	{
		#region Fields

		int currentFrame = 0;
		double lastChange = 0;
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

		double delta { 
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
                currentFrame = frames.Length - 1;
            }
        }

        public void Next(GameTime gameTime)
        {
            if (lastChange + delta < gameTime.TotalGameTime.TotalMilliseconds)
            {
                lastChange = gameTime.TotalGameTime.TotalMilliseconds;
                if (currentFrame < frames.Length - 1)
                {
                    currentFrame++;
                }
                else
                {
                    currentFrame = 0;
                }
            }
        }

        #endregion
    }
}

