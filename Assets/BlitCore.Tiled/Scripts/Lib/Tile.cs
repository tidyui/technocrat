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
	/// A single tile in the map.
	/// </summary>
	public sealed class Tile 
	{
		/// <summary>
		/// Gets/sets the sprite name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets/sets the sprite position.
		/// </summary>
		public int SpritePos { get; set; }
	}
}
