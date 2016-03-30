using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero.Engine
{
    public class Animation
    {
        public string Key { get; }

        public int FramesPerSecond { get; set; }

        Texture2D[] frames;
        AnimationManager manager;
        TankHero game;
        int currentFrame = 0;

        public Animation(AnimationManager m, Texture2D[] f, int fps = 0)
        {
            if (f.Length == 0)
            {
                throw new Exception("There must be at least one texture");
            }

            manager = m;
            frames = f;
            FramesPerSecond = fps;
        }

        public void Draw()
        {

        }
    }
}

