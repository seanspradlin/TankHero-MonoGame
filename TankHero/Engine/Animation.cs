using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero
{
	namespace Engine
	{
		public class Animation
		{
			public string Key { get; }

			public int FramesPerSecond { get; set; }

			Texture2D[] frames;
			AnimationManager manager;

			public Animation (AnimationManager m, Texture2D[] f, int fps = 0)
			{
				manager = m;
				frames = f;
				FramesPerSecond = fps;
			}

			public void Draw ()
			{
				
			}
		}
	}
}

