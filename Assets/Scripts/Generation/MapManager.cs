/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour 
{
	//
	// Private members
	//
	private Room[,] layout;

   	//
	// Map dimensions
	//
	[Header ("Dimensions")]
	public int width;
	public int height;
	public int segmentWidth;
	public int segmentHeight;

	//
	// The different prefabs available
	//
	[Header ("Prefabs")]
	public GameObject[] rooms;

	/// <summary>
	/// Starts the component and creates the map.
	/// </summary>
	void Start () {
		layout = new Room[width, height];
		int xpos = -1, ypos = -1;

		// Create the random layout
		while (xpos < width - 1 || ypos < height - 1) {
			xpos = Mathf.Min (width - 1, xpos + 1);
			ypos = Mathf.Min (height - 1, ypos + 1);

			// Randomize which order we move in
			if (Random.Range (0, 2) == 0) {
				for (var x = 0; x <= xpos; x++) {
					if (layout [x, ypos] == null) {
						layout [x, ypos] = CreateRoom (x, ypos);
					}
				}
			} else {
				for (var x = xpos - 1; x >= 0; x--) {
					if (layout [x, ypos] == null) {
						layout [x, ypos] = CreateRoom (x, ypos);
					}
				}
			}
			// Randomize which order we move in
			if (Random.Range (0, 2) == 0) {
				for (var y = 0; y <= ypos; y++) {
					if (layout [xpos, y] == null) {
						layout [xpos, y] = CreateRoom (xpos, y);
					}
				}
			} else {
				for (var y = ypos; y >= 0; y--) {
					if (layout [xpos, y] == null) {
						layout [xpos, y] = CreateRoom (xpos, y);
					}
				}
			}
		} 

		for (var x = 0; x < width; x++) {
			for (var y = 0; y < height; y++) {
				// Instantiate random room segment
				var go = GameObject.Instantiate (rooms [Random.Range(0, rooms.Length)], new Vector3 (x * segmentWidth, y * segmentHeight), Quaternion.identity);
				var rm = go.GetComponent<RoomManager> ();

				go.transform.parent = transform;

				// Setup room exits
				foreach (var exit in layout [x, y].Exits) {
					if (exit.Direction == ExitDirectionType.Top) {
						rm.topExit = ((ExitHorizontal)exit).Type;
					} else if (exit.Direction == ExitDirectionType.Bottom) {
						rm.bottomExit = ((ExitHorizontal)exit).Type;
					} else if (exit.Direction == ExitDirectionType.Left) {
						rm.leftExit = ((ExitVertical)exit).Type;
					} else {
						rm.rightExit = ((ExitVertical)exit).Type;
					}
				}
			}
		}
	}

	/// <summary>
	/// Creates a room at the given position in the layout.
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="y">The y coordinate.</param>
	/// <returns>The created room.</returns>
	private Room CreateRoom (int x, int y) {
		var room = new Room ();

		if (x > 0 || y > 0) {
			var exits = new List<ExitDirectionType> ();

			if (x > 0) {
				if (layout [x - 1, y] != null) {
					exits.Add (ExitDirectionType.Left);
				}
			}
			if (x < width - 1) {
				if (layout [x + 1, y] != null) {
					exits.Add (ExitDirectionType.Right);
				}
			}
			if (y > 0) {
				if (layout [x, y - 1] != null) {
					exits.Add (ExitDirectionType.Bottom);
				}
			}
			if (y < height - 1) {
				if (layout [x, y + 1] != null) {
					exits.Add (ExitDirectionType.Top);
				}
			}

			var direction = exits [Random.Range (0, exits.Count)];
			Exit exit = null;

			if (direction == ExitDirectionType.Bottom || direction == ExitDirectionType.Top) {
				exit = new ExitHorizontal () { 
					Direction = direction,
					Type = (ExitHorizontalType)Random.Range (1, 4)
				};
			} else {
				exit = new ExitVertical () { 
					Direction = direction,
					Type = (ExitVerticalType)Random.Range (1, 4)
				};
			}
			room.Exits.Add (exit);

			if (exit.Direction == ExitDirectionType.Bottom)
				layout [x, y - 1].Exits.Add (new ExitHorizontal () {
					Direction = ExitDirectionType.Top,
					Type = ((ExitHorizontal)exit).Type
				});
			else if (exit.Direction == ExitDirectionType.Left)
				layout [x - 1, y].Exits.Add (new ExitVertical () {
					Direction = ExitDirectionType.Right,
					Type = ((ExitVertical)exit).Type
				});
			else if (exit.Direction == ExitDirectionType.Right)
				layout [x + 1, y].Exits.Add (new ExitVertical () {
					Direction = ExitDirectionType.Left,
					Type = ((ExitVertical)exit).Type
				});
			else 
				layout [x, y + 1].Exits.Add (new ExitHorizontal () {
					Direction = ExitDirectionType.Bottom,
					Type = ((ExitHorizontal)exit).Type
				});
		}
		return room;
	}
}
