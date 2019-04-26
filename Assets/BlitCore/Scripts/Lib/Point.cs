/*
 * BlitCore 2D Framework
 * 
 * Copyright (c) 2017 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * http://github.com/blitbusters
 * 
 */

using System;

namespace BlitCore
{
	/// <summary>
	/// A x,y point in the world
	/// </summary>
	public class Point : IEquatable<Point>
	{
		public int x;
		public int y;

		public Point(int x, int y) {
			this.x = x;
			this.y = y;
		}

		public bool Equals (Point other) {
			return x == other.x && y == other.y;
		}
	}
}
