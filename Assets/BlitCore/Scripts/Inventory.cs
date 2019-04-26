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
using System;
using System.Collections.Generic;

namespace BlitCore
{
	/// <summary>
	/// Generic inventory for holding player items.
	/// </summary>
	[Serializable]
	public class Inventory 
	{
		/// <summary>
		/// The capacity of the current inventory.
		/// </summary>
		public int capacity = 10;

		/// <summary>
		/// The items currenctly in the inventory.
		/// </summary>
		public IList<IItem> items = new List<IItem>();

		/// <summary>
		/// Gets the currectly used capacity.
		/// </summary>
		public int UsedCapacity {
			get {
				var used = 0;

				foreach (var item in items)
					used += item.Weight;
				return used;
			}
		}

		/// <summary>
		/// Gets if the inventory is currently full.
		/// </summary>
		public bool IsFull {
			get {
				return UsedCapacity >= capacity;
			}
		}

		/// <summary>
		/// Adds a new item to the inventory.
		/// </summary>
		/// <param name="item">The item to add</param>
		public bool Add(IItem item) {
			if (item.Weight < capacity - UsedCapacity) {
				items.Add (item);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Adds a new item to the inventory.
		/// </summary>
		/// <param name="go">The item to add</param>
		public bool Add(ItemObject go) {
			if (Add (go.item)) {
				GameObject.Destroy (go.gameObject);
				return true;
			}
			return false;
		}
	}
}
