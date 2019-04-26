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

namespace BlitCore
{
	public class DestructibleObject : MonoBehaviour, IDestructible
	{
		/// <summary>
		/// The number of hit points.
		/// </summary>
		public int hitPoints;

		/// <summary>
		/// The current amount of hit points.
		/// </summary>
		public int currentHitPoints;

		/// <summary>
		/// Starts the component.
		/// </summary>
		protected virtual void Start() {
			currentHitPoints = hitPoints;
		}

		/// <summary>
		/// Causes the given amount of damage to the object.
		/// </summary>
		public virtual void Damage(int damage) {
			currentHitPoints = Math.Max (0, currentHitPoints - damage);

			if (currentHitPoints == 0)
				Destroy ();
		}

		/// <summary>
		/// Destroys the object.
		/// </summary>
		public virtual void Destroy() {
			GameObject.Destroy (this.gameObject);
		}
	}
}

