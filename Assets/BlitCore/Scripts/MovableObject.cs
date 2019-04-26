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
	/// <summary>
	/// Base class for all movable objects.
	/// </summary>
	[ExecuteInEditMode]
	[RequireComponent(typeof(SpriteRenderer))]
	public class MovableObject : MonoBehaviour 
	{
		public bool simulateZAxis = true;

		public int zAxisOffset = 0;

		/// <summary>
		/// The sprite renderer.
		/// </summary>
		protected SpriteRenderer spriteRenderer;

		/// <summary>
		/// Starts the behaviour.
		/// </summary>
		protected virtual void Start () {
			spriteRenderer = GetComponent <SpriteRenderer> ();
		}

		/// <summary>
		/// Make sure the object stays within the pixel boundaries
		/// to prevent subpixel rendering.
		/// </summary>
		protected virtual void LateUpdate () { 
			if (simulateZAxis && spriteRenderer != null)
				spriteRenderer.sortingOrder = 1000 - (int)Mathf.Round (transform.position.y * 10) + zAxisOffset;
		}
	}
}
