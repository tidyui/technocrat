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
public class Keyboard : IInput 
{
	/// <summary>
	/// Gets the current value of the horizontal axis.
	/// </summary>
	public float GetHorizontal() {
		return (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A) ? -1 : 0) + (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D) ? 1 : 0);
	}

	/// <summary>
	/// Gets the current value of the vertical axis.
	/// </summary>
	public float GetVertical() {
		return (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S) ? -1 : 0) + (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W) ? 1 : 0);
	}

	/// <summary>
	/// Gets the current mouse position.
	/// </summary>
	public Vector2 GetMouse() {
		return Input.mousePosition;
	}

	/// <summary>
	/// Gets if the first mouse button is pressed.
	/// </summary>
	public bool GetMouseButton1() {
		return Input.GetMouseButtonUp (0);
	}
		
	/// <summary>
	/// Gets if the specified button is pressed.
	/// </summary>
	public bool GetButton(string button) {
		if (button.ToLower () == "fire")
			return Input.GetKeyDown (KeyCode.P);
			//return Input.GetMouseButtonUp (0);
		else if (button.ToLower () == "aim")
			return Input.GetKey (KeyCode.LeftAlt);
		else if (button.ToLower () == "dash")
			return Input.GetKey (KeyCode.Space);

		if (button == "A")
			return Input.GetKeyDown (KeyCode.W);
		else if (button == "B")
			return Input.GetKeyDown (KeyCode.R);
		else if (button == "X")
			return Input.GetKeyDown (KeyCode.Q);
		else if (button == "Y")
			return Input.GetKeyDown (KeyCode.E);
		return false;
	}
}
