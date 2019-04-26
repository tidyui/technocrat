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

namespace BlitCore
{
	/// <summary>
	/// Script for an item placed on the game map.
	/// </summary>
	[RequireComponent(typeof(Collider2D))]
	public class ItemObject : MonoBehaviour
	{
		/// <summary>
		/// The current item.
		/// </summary>
		public IItem item;
	}
}
