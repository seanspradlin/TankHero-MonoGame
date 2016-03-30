using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;

namespace TankHero.Engine
{
	public class Animation
	{
		#region Fields

		bool isPlaying = true;
		int currentFrame = 0;
		int lastChange = 0;
		SpriteFrame[] frames;
		AnimationManager manager;

		#endregion

		#region Constructors

		public Animation (AnimationManager m, SpriteFrame[] f, int fps = 0)
		{
			if (f.Length == 0) {
				throw new Exception ("There must be at least one texture");
			}

			manager = m;
			Game = m.Game;
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

		public Game Game { get; }

		int delta { 
			get {
				return 1000 / FramesPerSecond;
			}
		}

		#endregion

		#region Methods

		void Play ()
		{
			if (frames.Length > 0) {
				isPlaying = true;
			}
		}

		void Stop ()
		{
			isPlaying = false;
		}

		void Next (GameTime gameTime)
		{
			if (isPlaying) {
				if (lastChange + delta <= gameTime.ElapsedGameTime.Milliseconds) {
					if (currentFrame < frames.Length) {
						currentFrame++;
					} else {
						currentFrame = 0;
					}
				}
			}
		}

		#endregion
	}
}

