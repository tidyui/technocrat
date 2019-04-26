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
using System.Collections.Generic;

namespace BlitCore
{
	/// <summary>
	/// Script for an object that can contain items.
	/// </summary>
	public class ContainerObject : MonoBehaviour
	{
		/// <summary>
		/// The items currently in the container.
		/// </summary>
		public IList<IItem> items;

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ContainerObject() {
			items = new List<IItem> ();
		}

		/// <summary>
		/// Adds a new item to the containers.
		/// </summary>
		public virtual void Add(IItem item) {
			items.Add (item);
		}

		/// <summary>
		/// Removes the given item from the container.
		/// </summary>
		public virtual void Remove(IItem item) {
			items.Remove (item);	
		}

		/// <summary>
		/// Called when the gameobject will be destroyed.
		/// </summary>
		protected virtual void OnDestroy() {
			// Check if destruction should instantiate items on
			// the game map.
			if (BlitEngine.Instance != null && BlitEngine.Instance.searchStyle == SearchStyle.Destroy) {
				foreach (var item in items) {
					item.Instantiate (transform.position);
				}
			}
		}
	}
}
