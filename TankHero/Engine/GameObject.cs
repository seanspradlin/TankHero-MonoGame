using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TexturePackerLoader;

namespace TankHero.Engine
{
	public class GameObject : GameComponent
	{
		#region Fields

		SpriteFrame _sprite;

		#endregion

		#region Constructors

		public GameObject (SGame game, SpriteFrame spriteFrame, Vector2 position)
			: base (game as Game)
		{
			Game = game;
			Position = position;
			game.Components.Add (this);
			_sprite = spriteFrame;
			Animations = new AnimationManager (this);
			Children = new Dictionary<string, GameObject> ();
		}

		public GameObject (GameObject parent, SpriteFrame spriteFrame, Vector2 position)
			: this (parent.Game, spriteFrame, position)
		{
			Parent = parent;
		}

		#endregion

		#region Properties

		public AnimationManager Animations { get; }

		public Rectangle Bounds { get; set; }

		public Dictionary<string, GameObject> Children { get; }

		public new SGame Game { get; }

		public GameObject Parent { get; }

		public Vector2 Position { get; set; }

		public Vector2 GlobalPosition {
			get {
				if (Parent == null) {
					return Position;
				} else {
					var x = Parent.Position.X + Position.X;
					var y = Parent.Position.Y + Position.Y;
					return new Vector2 (x, y);
				}
			}
		}

		public SpriteFrame Sprite { 
			get {
				if (!Animations.IsPlaying) {
					return _sprite;
				} else {
					return Animations.CurrentFrame;
				}
			}
		}

		#endregion

		#region Methods

		public GameObject AddChild (string key, SpriteFrame spriteFrame, Vector2 position)
		{
			if (Children.ContainsKey (key)) {
				throw new Exception ("Child key already in use");
			}
			var child = new GameObject (this, spriteFrame, position);
			Children.Add (key, child);
			return child;
		}

		public virtual void Update ()
		{
			Animations.Update ();
			base.Update (Game.Time);
		}

		public void Draw ()
		{
			Game.Renderer.Draw (Sprite, Position);
			Children.Values.ToList ().ForEach (x => {
				Game.Renderer.Draw (x.Sprite, x.GlobalPosition);
			});
		}

		#endregion

	}
}

