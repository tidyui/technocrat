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
using System.Collections;

namespace BlitCore
{
	[RequireComponent(typeof(Camera))]
	public class GameCamera : MonoBehaviour 
	{
		/// <summary>
		/// The camera this script is attached to.
		/// </summary>
		private Camera cam;

		/// <summary>
		/// Starts the component.
		/// </summary>
		protected virtual void Start() {
			cam = GetComponent<Camera> ();
		}

		/// <summary>
		/// Checks if any screen properties as been changed since the last update.
		/// </summary>
		protected virtual void FixedUpdate () {
			if (BlitEngine.Instance.screen != null) {
				cam.orthographicSize = BlitEngine.Instance.screen.zoomedCameraHeight;
			}
		}

		/// <summary>
		/// Adjusts the camera position to the closes pixel unit.
		/// </summary>
		protected virtual void LateUpdate () {
			transform.position = Utils.RoundToNearestPixel (transform.position);
		}
	}
}
