/*
 * BlitCore 2D Framework
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * http://github.com/blitbusters
 * 
 */

using System;

namespace BlitCore
{
	/// <summary>
	/// Interface for destructible objects.
	/// </summary>
	public interface IDestructible
	{
		/// <summary>
		/// Causes the given amount of damage to the object.
		/// </summary>
		void Damage(int damage);

		/// <summary>
		/// Destroys the object
		/// </summary>
		void Destroy();
	}
}

