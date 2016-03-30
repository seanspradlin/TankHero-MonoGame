using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TankHero.Engine
{
    public interface IGame: IDisposable
    {
        SpriteBatch SpriteBatch { get; set; }
        GameComponentCollection Components { get; }
        ContentManager Content { get; set; }
        GraphicsDevice GraphicsDevice { get; }
        TimeSpan InactiveSleepTime { get; set; }
        bool IsActive { get; }
        bool IsFixedTimeStep { get; set; }
        bool IsMouseVisible { get; set; }
        LaunchParameters LaunchParameters { get; }
        TimeSpan MaxElapsedTime { get; set; }
        GameServiceContainer Services { get; }
        TimeSpan TargetElapsedTime { get; set; }
        GameWindow Window { get; }
        event EventHandler<EventArgs> Activated;
        event EventHandler<EventArgs> Deactivated;
        event EventHandler<EventArgs> Disposed;
        event EventHandler<EventArgs> Exiting;
        void Exit();
        void ResetElapsedTime();
        void Run();
        void Run(GameRunBehavior runBehavior);
        void RunOneFrame();
        void SuppressDraw();
        void Tick();
    }
}
