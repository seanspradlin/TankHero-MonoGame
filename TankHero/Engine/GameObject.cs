using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankHero.Engine
{
    public class GameObject
    {
        public IGame Game { get; }
        public AnimationManager Animations { get; }

        public Vector2 Position { get; set; }

        public Texture2D Texture { get; set; }

        public Rectangle Bounds { get; set; }

        public GameObject(IGame game, Texture2D texture, Vector2 position)
        {
            Game = game;
            Position = position;
            Texture = texture;
            Bounds = texture.Bounds;
            Animations = new AnimationManager(this);
        }
    }
}

