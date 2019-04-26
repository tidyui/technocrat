/*
 * BlitCore 2D Framework
 * 
 * Copyright (c) 2016-2017 Håkan Edling 
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
	/// Behaviour for an object that should support fading.
	/// </summary>
	[RequireComponent(typeof(SpriteRenderer))]
	public class FadingObject : MonoBehaviour
	{
		/// <summary>
		/// The sprite renderer.
		/// </summary>
		private SpriteRenderer sr;

		void Start() {
			sr = GetComponent<SpriteRenderer> ();	
		}

		/// <summary>
		/// Fades in the game object. This call assumes that the
		/// gamma value of the sprite renderer color is set to 0.
		/// </summary>
		public void FadeIn() {
			StartCoroutine ("FadeInRoutine");
		}

		/// <summary>
		/// Fades out the game object. This call assumes that the
		/// gamma value of the sprite renderer color is set to 1.
		/// </summary>
		public void FadeOut() {
			StartCoroutine ("FadeOutRoutine");
		}

		/// <summary>
		/// Co-routine for fade in.
		/// </summary>
		public IEnumerator FadeInRoutine() {
			for (var gamma = 0f; gamma <= 1f; gamma += 0.05f) {
				sr.color = new Color (sr.color.r, sr.color.g, sr.color.b, gamma);
				yield return null;
			}
			sr.color = new Color (sr.color.r, sr.color.g, sr.color.b, 1);
		}

		/// <summary>
		/// Co-routine for fade out.
		/// </summary>
		public IEnumerator FadeOutRoutine() {
			for (var gamma = 0f; gamma <= 1f; gamma += 0.05f) {
				sr.color = new Color (sr.color.r, sr.color.g, sr.color.b, 1 - gamma);
				yield return null;
			}
			sr.color = new Color (sr.color.r, sr.color.g, sr.color.b, 0);
		}
	}
}

