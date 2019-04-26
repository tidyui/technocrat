/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

using System.Collections.Generic;

/// <summary>
/// Class for a randomized room.
/// </summary>
public class Room 
{
	/// <summary>
	/// Gets/sets the available exits.
	/// </summary>
	/// <value>The exits.</value>
	public List<Exit> Exits { get; set; }

	/// <summary>
	/// Default constructor.
	/// </summary>
	public Room() {
		Exits = new List<Exit>();
	}
}
