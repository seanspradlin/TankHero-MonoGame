using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero.Engine
{
    public class AnimationManager
    {
        TankHero game;
        GameObject gameObject;
        Dictionary<string, Animation> animations;
        string currentAnimation;

        public AnimationManager(GameObject go)
        {
            gameObject = go;
            currentAnimation = "default";
            Add(currentAnimation, new[] { go.Texture });
        }

        public void Add(string key, Texture2D[] frames, int framerate = 0)
        {
            var animation = new Animation(this, frames, framerate);
            animations.Add(key, animation);
        }

        public void Play(string key)
        {
            if (animations.ContainsKey(key))
            {
                currentAnimation = key;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public Texture2D Draw()
        {
            throw new NotImplementedException();
        }
    }
}

