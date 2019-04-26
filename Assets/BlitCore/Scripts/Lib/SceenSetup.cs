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
	/// Class for representing the current camera & screen setup.
	/// </summary>
	[Serializable]
	public class ScreenSetup
	{
		/// <summary>
		/// The real width of the game texture.
		/// </summary>
		public int width;

		/// <summary>
		/// The real height of the game texture. 
		/// </summary>
		public int height;

		/// <summary>
		/// The current camera zoom.
		/// </summary>
		public int zoom;

		/// <summary>
		/// How many units fits on the horizontal axis.
		/// </summary>
		public float unitWidth;

		/// <summary>
		/// How many unit fints on the vertical axis.
		/// </summary>
		public float unitHeight;

		/// <summary>
		/// The horizontal ortographic camera size without zoom.
		/// </summary>
		public float cameraWidth;

		/// <summary>
		/// The horizontal ortographic camera size with zoom included.
		/// </summary>
		public float zoomedCameraWidth ;

		/// <summary>
		/// The ortographic camera size without zoom.
		/// </summary>
		public float cameraHeight;

		/// <summary>
		/// The ortographic camera size with zoom included.
		/// </summary>
		public float zoomedCameraHeight ;

		/// <summary>
		/// Gets the current screen setup for the given parameters.
		/// </summary>
		/// <param name="width">The current screen width</param>
		/// <param name="height">The current screen height</param>
		/// <param name="targetHeight">The target height</param>
		/// <param name="pixelsPerUnit">The number of pixels per units</param>
		public static ScreenSetup Get (int width, int height, int targetHeight, int pixelsPerUnit) {
			var setup = new ScreenSetup ();
			var prev = 0f;

			// Get the zoom level that gets closest to target height
			for (setup.zoom = 1; setup.zoom < 10; setup.zoom++) {
				var curr = height / setup.zoom;

				if (prev != 0 && Math.Abs(targetHeight - prev) < Math.Abs(targetHeight - curr)) {
					setup.zoom--;
					break;
				}
				prev = curr;
			}

			// Now calculate the rest
			setup.width = Convert.ToInt32 (Math.Ceiling ((double)width / setup.zoom));
			setup.height = Convert.ToInt32 (Math.Ceiling ((double)height / setup.zoom));
			setup.unitWidth = (float)setup.width / pixelsPerUnit;
			setup.unitHeight = (float)setup.height / pixelsPerUnit;
			setup.cameraWidth = width / (pixelsPerUnit * 2f);
			setup.zoomedCameraWidth = width / (pixelsPerUnit * 2f * setup.zoom);
			setup.cameraHeight = height / (pixelsPerUnit * 2f);
			setup.zoomedCameraHeight = height / (pixelsPerUnit * 2f * setup.zoom);

			return setup;
		}
	}
}
