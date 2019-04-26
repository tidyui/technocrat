/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

using BlitCore;
using BlitCore.Tiled;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class RoomBuilder 
{
	/// <summary>
	/// Creates the room from the specified tmx-file.
	/// </summary>
	[MenuItem("Technocrat/Create Room")]
	public static void CreateRoom () {
		var scene = EditorSceneManager.GetActiveScene ();
		RoomManager mgr = null;

		foreach (var go in scene.GetRootGameObjects()) {
			mgr = go.GetComponent<RoomManager> ();
			if (mgr != null)
				break;
		}

		if (mgr != null) {
			var mapData = Loader.LoadString (mgr.mapPath);
			var map = Map.Load (mapData);

			if (map != null) {
				DestroyRoom ();

				var baseLayout = Ensure (mgr.gameObject, RoomConstants.BASE);

				var topNone = Ensure (mgr.gameObject, RoomConstants.TOP_NONE);
				var topCenter = Ensure (mgr.gameObject, RoomConstants.TOP_CENTER);
				var topFull = Ensure (mgr.gameObject, RoomConstants.TOP_FULL);
				var topLeft = Ensure (mgr.gameObject, RoomConstants.TOP_LEFT);
				var topRight = Ensure (mgr.gameObject, RoomConstants.TOP_RIGHT);

				var bottomNone = Ensure (mgr.gameObject, RoomConstants.BOTTOM_NONE);
				var bottomCenter = Ensure (mgr.gameObject, RoomConstants.BOTTOM_CENTER);
				var bottomFull = Ensure (mgr.gameObject, RoomConstants.BOTTOM_FULL);
				var bottomLeft = Ensure (mgr.gameObject, RoomConstants.BOTTOM_LEFT);
				var bottomRight = Ensure (mgr.gameObject, RoomConstants.BOTTOM_RIGHT);

				var leftNone = Ensure (mgr.gameObject, RoomConstants.LEFT_NONE);
				var leftCenter = Ensure (mgr.gameObject, RoomConstants.LEFT_CENTER);
				var leftFull = Ensure (mgr.gameObject, RoomConstants.LEFT_FULL);
				var leftBottom = Ensure (mgr.gameObject, RoomConstants.LEFT_BOTTOM);
				var leftTop = Ensure (mgr.gameObject, RoomConstants.LEFT_TOP);

				var rightNone = Ensure (mgr.gameObject, RoomConstants.RIGHT_NONE);
				var rightCenter = Ensure (mgr.gameObject, RoomConstants.RIGHT_CENTER);
				var rightFull = Ensure (mgr.gameObject, RoomConstants.RIGHT_FULL);
				var rightBottom = Ensure (mgr.gameObject, RoomConstants.RIGHT_BOTTOM);
				var rightTop = Ensure (mgr.gameObject, RoomConstants.RIGHT_TOP);

				foreach (var layer in map.Layers) {
					GameObject current = null;

					if (layer.Name.Contains (RoomConstants.TOP_NONE))
						current = topNone;
					else if (layer.Name.Contains (RoomConstants.TOP_CENTER))
						current = topCenter;
					else if (layer.Name.Contains (RoomConstants.TOP_FULL))
						current = topFull;
					else if (layer.Name.Contains (RoomConstants.TOP_LEFT))
						current = topLeft;
					else if (layer.Name.Contains (RoomConstants.TOP_RIGHT))
						current = topRight;
					
					else if (layer.Name.Contains (RoomConstants.BOTTOM_NONE))
						current = bottomNone;
					else if (layer.Name.Contains (RoomConstants.BOTTOM_CENTER))
						current = bottomCenter;
					else if (layer.Name.Contains (RoomConstants.BOTTOM_FULL))
						current = bottomFull;
					else if (layer.Name.Contains (RoomConstants.BOTTOM_LEFT))
						current = bottomLeft;
					else if (layer.Name.Contains (RoomConstants.BOTTOM_RIGHT))
						current = bottomRight;
					
					else if (layer.Name.Contains (RoomConstants.LEFT_NONE))
						current = leftNone;
					else if (layer.Name.Contains (RoomConstants.LEFT_CENTER))
						current = leftCenter;
					else if (layer.Name.Contains (RoomConstants.LEFT_FULL))
						current = leftFull;
					else if (layer.Name.Contains (RoomConstants.LEFT_BOTTOM))
						current = leftBottom;
					else if (layer.Name.Contains (RoomConstants.LEFT_TOP))
						current = leftTop;

					else if (layer.Name.Contains (RoomConstants.RIGHT_NONE))
						current = rightNone;
					else if (layer.Name.Contains (RoomConstants.RIGHT_CENTER))
						current = rightCenter;
					else if (layer.Name.Contains (RoomConstants.RIGHT_FULL))
						current = rightFull;
					else if (layer.Name.Contains (RoomConstants.RIGHT_BOTTOM))
						current = rightBottom;
					else if (layer.Name.Contains (RoomConstants.RIGHT_TOP))
						current = rightTop;
					else
						current = baseLayout;


					var import = Ensure (current, "Imported");

					for (var x = 0; x < map.Width; x++) {
						for (var y = 0; y < map.Height; y++) {
							var tile = layer.Tiles [x, y];

							if (tile != null) {
								var name = tile.Name.ToLower () + "_" + tile.SpritePos;

								var prefab = (GameObject)Resources.Load ("Prefabs/" + name);

								if (prefab != null) {
									var go = (GameObject)GameObject.Instantiate (prefab, new Vector3 (x, map.Height - y - 1, 0), Quaternion.identity);
									go.transform.parent = import.transform; // current.transform;
								} else {
									Debug.Log ("Missing prefab: " + tile.Name.ToLower () + "_" + tile.SpritePos);
								}
							}

							if (current == baseLayout) {
								var prefab = (GameObject)Resources.Load ("Prefabs/floors_0");
								var go = (GameObject)GameObject.Instantiate (prefab, new Vector3 (x, map.Height - y - 1, 0), Quaternion.identity);
								go.transform.parent = import.transform;
							}
						}
					}
				}
			}
		}
	}


	/// <summary>
	/// Destroys the current room.
	/// </summary>
	[MenuItem("Technocrat/Destroy Room")]
	public static void DestroyRoom () {
		var scene = EditorSceneManager.GetActiveScene ();
		RoomManager mgr = null;

		foreach (var go in scene.GetRootGameObjects()) {
			mgr = go.GetComponent<RoomManager> ();
			if (mgr != null)
				break;
		}

		if (mgr != null) {
			for (var n = 0; n < mgr.transform.childCount; n++) {					
				var child = mgr.transform.GetChild (n).gameObject;

				for (var i = 0; i < child.transform.childCount; i++) {
					if (child.transform.GetChild (i).name == "Imported") {
						GameObject.DestroyImmediate (child.transform.GetChild (i).gameObject);
						break;
					}
				}
			}
		}
	}

	static GameObject Ensure(GameObject parent, string name) {
		var trans = parent.transform.Find (name);
		var go = trans != null ? trans.gameObject : null;

		if (go == null) {
			go = new GameObject (name) { isStatic = true };
			go.transform.parent = parent.transform;
		}
		return go;
	}
}
