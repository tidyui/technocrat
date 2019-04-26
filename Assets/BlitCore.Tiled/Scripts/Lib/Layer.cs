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
	/// A layer in the map.
	/// </summary>
	public sealed class Layer
	{
		/// <summary>
		/// Gets/sets the tiles.
		/// </summary>
		public Tile[,] Tiles { get; set; }

		/// <summary>
		/// Gets/sets the layer name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="width">The layer width</param>
		/// <param name="height">The layer height</param>
		public Layer(int width, int height) {
			Tiles = new Tile[width, height];
		}
	}
}

