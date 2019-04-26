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
	[Serializable]
	public class Room
	{
		/// <summary>
		/// The start x coordinate.
		/// </summary>
		public int x;

		/// <summary>
		/// The start y coordinate.
		/// </summary>
		public int y;

		/// <summary>
		/// The unit width.
		/// </summary>
		public int width;

		/// <summary>
		/// The unit height.
		/// </summary>
		public int height;

		/// <summary>
		/// The optional blocking object.
		/// </summary>
		public Transform blocker;
	}
}
