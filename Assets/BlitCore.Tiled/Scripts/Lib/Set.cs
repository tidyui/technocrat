/*
 * BlitCore 2D Framework
 * 
 * Copyright (c) 2017 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * http://github.com/blitbusters
 * 
 */

namespace BlitCore.Tiled
{
	/// <summary>
	/// A tile set.
	/// </summary>
	public sealed class Set
	{
		/// <summary>
		/// Gets/sets the set name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets/sets the global id of the first tile in the set.
		/// </summary>
		public int FirstGid { get; set; }

		/// <summary>
		/// Gets/sets the tile count in this set.
		/// </summary>
		public int TileCount { get; set; }

		/// <summary>
		/// Gets/sets the filename of the spritesheet.
		/// </summary>
		public string Filename { get; set; }

		/// <summary>
		/// Checks if the set contains the given global id.
		/// </summary>
		/// <param name="gid">The global id</param>
		public bool ContainsGid(int gid) {
			return gid >= FirstGid && gid <= FirstGid + TileCount - 1;
		}
	}
}
