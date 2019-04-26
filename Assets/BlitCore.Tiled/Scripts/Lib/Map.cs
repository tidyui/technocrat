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
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace BlitCore.Tiled
{
	public class Map
	{
		/// <summary>
		/// Gets/sets the map width.
		/// </summary>
		public int Width { get; private set; }

		/// <summary>
		/// Gets/sets the map height.
		/// </summary>
		public int Height { get; private set; }

		/// <summary>
		/// Gets/sets the available tile sets.
		/// </summary>
		public List<Set> Sets { get; set; }

		/// <summary>
		/// Gets/sets the available layers.
		/// </summary>
		public List<Layer> Layers { get; set; }

		/// <summary>
		/// Default private constructor.
		/// </summary>
		/// <param name="width">The map width</param>
		/// <param name="height">The map height</param>
		private Map(int width, int height) {
			Width = width;
			Height = height;
			Sets = new List<Set> ();
			Layers = new List<Layer> ();
		}

		/// <summary>
		/// Loads the map from the given xml string.
		/// </summary>
		/// <param name="xml">The xml string</param>
		public static Map Load(string xml) {
			var doc = new XmlDocument ();
			doc.LoadXml (xml);

			return Load (doc);
		}

		/// <summary>
		/// Loads the map from the given xml doc.
		/// </summary>
		/// <param name="doc">The xml document</param>
		public static Map Load(XmlDocument doc) {
			var root = doc.DocumentElement;

			// Create map
			var map = new Map (Convert.ToInt32 (root.GetAttribute ("width")),
				Convert.ToInt32 (root.GetAttribute ("height")));

			// Create tilesets
			foreach (XmlNode child in root.ChildNodes) {
				if (child.Name == "tileset") {
					var set = new Set () { 
						Name = child.Attributes["name"].Value,
						FirstGid = Convert.ToInt32(child.Attributes["firstgid"].Value),
						TileCount = Convert.ToInt32(child.Attributes["tilecount"].Value)
					};
					map.Sets.Add (set);
				}
			}

			// Create layers
			foreach (XmlNode child in root.ChildNodes) {
				if (child.Name == "layer") {
					var layer = new Layer (map.Width, map.Height) { 
						Name = child.Attributes["name"].Value
					};

					int x = 0, y = 0;

					var data = child.ChildNodes [0].InnerText.Split (new char[] { ',' });
					foreach (var str in data) {
						var gid = Convert.ToInt32 (str.Trim());
						var set = map.Sets.SingleOrDefault (s => s.ContainsGid (gid));

						if (set != null) {
							layer.Tiles [x, y] = new Tile () { 
								Name = set.Name,
								SpritePos = gid - set.FirstGid
							};
						}
						x = (x + 1) % map.Width;
						if (x == 0)
							y++;
					}
					map.Layers.Add (layer);
				}	
			}
			return map;	
		}
	}
}
