/*
 * BlitCore 2D Framework
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * http://github.com/blitbusters
 * 
 */

using UnityEngine;
using System.Collections;

namespace BlitCore
{
	/// <summary>
	/// Interface for all objects that can be placed in
	/// containers & inventories.
	/// </summary>
	public interface IItem
	{
		/// <summary>
		/// Gets/sets how much space the item takes.
		/// </summary>
		int Weight { get; set; }

		/// <summary>
		/// Instantiates the item on the game map.
		/// </summary>
		/// <param name="position">The map position</param>
		GameObject Instantiate(Vector3 position);
	}
}
