using System;
using Microsoft.Xna.Framework;

namespace TankHero.Engine
{
	public interface IGameProperties
	{
		SGame Game { get; }

		GameTime Time { get; }
	}
}

