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

public class XBoxMac : IInput 
{
	/// <summary>
	/// Gets the current value of the horizontal axis.
	/// </summary>
	public float GetHorizontal() {
		return Input.GetAxisRaw ("Horizontal");
	}

	/// <summary>
	/// Gets the current value of the vertical axis.
	/// </summary>
	public float GetVertical() {
		return Input.GetAxisRaw ("Vertical");
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
		if (button.ToLower () == "fire")
			return Input.GetKeyDown ("joystick button 14");
		else if (button.ToLower () == "aim")
			return Input.GetKey ("joystick button 13");
		else if (button.ToLower () == "dash")
			return Input.GetKeyDown ("joystick button 18");


		if (button == "A")
			return Input.GetKeyDown ("joystick button 16");
		else if (button == "B")
			return Input.GetKeyDown ("joystick button 17");
		else if (button == "X")
			return Input.GetKeyDown ("joystick button 18");
		else if (button == "Y")
			return Input.GetKeyDown ("joystick button 19") || Input.GetKeyDown(KeyCode.E);
		return false;
	}
}
