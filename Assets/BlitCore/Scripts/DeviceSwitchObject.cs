/*
 * BlitCore 2D Framework
 * 
 * Copyright (c) 2016-2017 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * http://github.com/blitbusters
 * 
 */

using UnityEngine;
using System;

namespace BlitCore
{
	/// <summary>
	/// Behaviour used to activate other devices.
	/// </summary>
	public class DeviceSwitchObject : MonoBehaviour, IDevice
	{
		// Members
		public float timeToUse = 0f;
		public Transform[] devices;

		/// <summary>
		/// Gets if the device can be used.
		/// </summary>
		public virtual bool CanUse { 
			get {
				foreach (var d in devices) {
					if (d.gameObject.IsDevice () && !d.gameObject.GetDevice ().CanUse)
						return false;
				}
				return true;
			}
		}

		/// <summary>
		/// Gets the time needed to use the device.
		/// </summary>
		public virtual float Time { 
			get { return timeToUse; }
		}

		/// <summary>
		/// Uses the device.
		/// </summary>
		/// <param name="onCompleted">Optional callback for async operations</param>
		public virtual void Use(Action onCompleted = null) {
			foreach (var d in devices) {
				if (d.gameObject.IsDevice () && d.gameObject.GetDevice ().CanUse)
					d.gameObject.GetDevice ().Use ();
			}
			if (onCompleted != null)
				onCompleted ();
		}
	}
}

