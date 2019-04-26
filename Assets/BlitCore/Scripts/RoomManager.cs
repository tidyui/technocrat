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
	[DisallowMultipleComponent]
	public class RoomManager
	{
		/// <summary>
		/// The available rooms.
		/// </summary>
		public Room[] rooms;

		/// <summary>
		/// The currently active room.
		/// </summary>
		public int currentRoom;

		/// <summary>
		/// Delegate for room change events.
		/// </summary>
		public delegate void RoomChangedDelegate(Room room);

		/// <summary>
		/// The room change event.
		/// </summary>
		public RoomChangedDelegate OnRoomChanged;

		/// <summary>
		/// Gets the current room manager instance.
		/// </summary>
		/// <value>The current.</value>
		public static RoomManager Current { get; private set; }

		/// <summary>
		/// Starts the component.
		/// </summary>
		void Start() {
			Current = this;

			for (var n = 0; n < rooms.Length; n++) {
				if (rooms[n].blocker != null) {
					var sr = rooms[n].blocker.GetComponent<SpriteRenderer> ();
					if (n == currentRoom)
						Utils.SetOpacity (sr, 0f);
					sr.sortingOrder = 10;
				}
			}
		}

		/// <summary>
		/// Changes the currently active room
		/// </summary>
		public void Change(int index) {
			if (currentRoom != index && index < rooms.Length) {
				var fade = rooms [currentRoom].blocker != rooms [index].blocker;

				if (fade && rooms[currentRoom].blocker != null) {
					rooms [currentRoom].blocker.FadeIn ();
				}

				currentRoom = index;

				if (fade && rooms[index].blocker != null) {
					rooms [index].blocker.FadeOut ();
				}

				if (OnRoomChanged != null)
					OnRoomChanged (rooms [currentRoom]);
			}
		}
	}
}

