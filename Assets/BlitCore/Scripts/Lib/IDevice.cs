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
	/// Interface for a device that can be used.
	/// </summary>
	public interface IDevice
	{
		/// <summary>
		/// Gets if the device can be used.
		/// </summary>
		bool CanUse { get; }

		/// <summary>
		/// Gets the time needed to use the device.
		/// </summary>
		float Time { get; }

		/// <summary>
		/// Uses the device.
		/// </summary>
		/// <param name="onCompleted">Optional callback for async operations</param>
		void Use(Action onCompleted = null);
	}
}
