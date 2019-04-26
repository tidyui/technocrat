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

[ExecuteInEditMode]
public class Startup : MonoBehaviour, IStartup 
{
	#if UNITY_EDITOR
	/// <summary>
	/// For the editor.
	/// </summary>
	void Start() {
		BlitEngine.Instance.Input = new Keyboard ();
		//BlitEngine.Instance.Input = new XBoxMac ();
	}
	#endif

	/// <summary>
	/// Initializes the game.
	/// </summary>
	public void Init() {
		Cursor.visible = false;

		// Default input should be keyboard
		BlitEngine.Instance.Input = new Keyboard ();

		#if UNITY_EDITOR || UNITY_STANDALONE
		//
		// Standard keyboard + mouse setup for computers
		//
		BlitEngine.Instance.Input = new Keyboard ();
		//BlitEngine.Instance.Input = new XBoxMac ();
		#else
		//
		// Touch controls for mobile devices
		//
		BlitEngine.Instance.Input = new Mobile ();
		#endif
	}
}
