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
	/// Script for randomizing the material from an array of materials.
	/// This is useful when wanting to acheive variety without putting
	/// this mundane task on the level designer.
	/// </summary>
	[ExecuteInEditMode]
	[RequireComponent(typeof(MeshRenderer))]
	public class MaterialRandomizer : MonoBehaviour 
	{
		/// <summary>
		/// The materials to randomize from;
		/// </summary>
		public Material[] materials;
		
		/// <summary>
		/// Starts the behaviour.
		/// </summary>
		void Start () {
			if (materials.Length > 0) {
				var renderer = GetComponent<MeshRenderer> ();
				
				if (renderer != null && materials.Length > 0)
					renderer.material = materials[Random.Range (0, materials.Length)];
			}
		}
	}
}
