using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero.Engine
{
    public class Animation
    {
        int currentFrame = 0;
        Texture2D[] frames;
        AnimationManager manager;

        public Animation(AnimationManager m, Texture2D[] f, int fps = 0)
        {
            if (f.Length == 0)
            {
                throw new Exception("There must be at least one texture");
            }

            manager = m;
            Game = m.Game;
            frames = f;
            FramesPerSecond = fps;
        }

        public Texture2D Frame
        {
            get
            {
                return frames[currentFrame];
            }
        }

        public int FramesPerSecond { get; set; }

        public string Key { get; }

        public IGame Game { get; }
    }
}

