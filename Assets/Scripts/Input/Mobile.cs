/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

using BlitCore;
using UnityEngine;

/// <summary>
/// Basic keyboard + mouse input
/// </summary>
public class Mobile : IInput 
{
	private Vector2 touchOrigin = -Vector2.one;
	private Vector2 movement = Vector2.zero;

	/// <summary>
	/// Gets the current value of the horizontal axis.
	/// </summary>
	public float GetHorizontal() {
		return movement.x;
	}

	/// <summary>
	/// Gets the current value of the vertical axis.
	/// </summary>
	public float GetVertical() {
		return movement.y;
	}

	/// <summary>
	/// Gets the current mouse position.
	/// </summary>
	public Vector2 GetMouse() {
		return Vector2.zero;
	}

	/// <summary>
	/// Gets if the first mouse button is pressed.
	/// </summary>
	public bool GetMouseButton1() {
		return Input.GetMouseButton (1);
	}

	/// <summary>
	/// Gets if the specified button is pressed.
	/// </summary>
	public bool GetButton(string button) {
		return false;
	}
}
