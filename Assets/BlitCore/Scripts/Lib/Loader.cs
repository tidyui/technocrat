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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BlitCore
{
	/// <summary>
	/// Class for loading resources into object graphs.
	/// </summary>
	public static class Loader
	{
		/// <summary>
		/// Loads the file at the given path and deserializes it into
		/// the specified type.
		/// </summary>
		/// <returns>The deserialized object</returns>
		/// <param name="path">The file path</param>
		/// <typeparam name="T">The object type</typeparam>
		public static T LoadFile<T> (string path) where T : class {
			try {
				using (var reader = new StreamReader (path)) {
					var formatter = new BinaryFormatter ();
					return (T)formatter.Deserialize (reader.BaseStream);
				}
			} catch { }
			return null;
		}
			
		/// <summary>
		/// Loads the file at the given path and returns the string data.
		/// </summary>
		/// <returns>The string content</returns>
		/// <param name="path">The file path</param>
		public static string LoadString (string path) {
			try {
				using (var reader = new StreamReader (path)) {
					return reader.ReadToEnd();
				}
			} catch { }
			return null;
		}
			
		/// <summary>
		/// Loads the resources at the given path and deserializes
		/// it into the given type.
		/// </summary>
		/// <returns>The deserialized object</returns>
		/// <param name="path">The resource path</param>
		/// <typeparam name="T">The object type</typeparam>
		public static T LoadResource<T> (string path) where T : class {
			var data = Resources.Load<TextAsset> (path);

			if (data != null) {
				var formatter = new BinaryFormatter ();

				using (var mem = new MemoryStream (data.bytes)) {
					return (T)formatter.Deserialize (mem);
				}
			}
			return null;
		}
	}
}

