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
/// Script for the main camera.
/// </summary>
[RequireComponent(typeof(Camera))]
public class MainCamera : GameCamera 
{
	private Camera lightCamera;
	private Material material;

	//
	// Setup for the lighting
	//
	[Header("Light setup")]
	public LayerMask lightLayer;
	public Shader shader;
	[Range(0.0f, 2.0f)]
	public float intensity = 1.0f;

	/// <summary>
	/// Starts the component.
	/// </summary>
	protected override void Start() {
		base.Start ();

		lightCamera = transform.Find ("Light Camera").GetComponent<Camera> ();
		if (lightCamera != null) {
			lightCamera.cullingMask = lightLayer;
		} else {
			Debug.LogError ("Couldn't find light camera");
		}
	}

	/// <summary>
	/// Updates the camera.
	/// </summary>
	protected override void FixedUpdate() {
		base.FixedUpdate();

		EnsureTexture(false);
	}

	/// <summary>
	/// Renders the camera texture.
	/// </summary>
	/// <param name="source">The source texture.</param>
	/// <param name="destination">The destination texture.</param>
	void OnRenderImage( RenderTexture source, RenderTexture destination ) {
		if (material != null) {
			Graphics.Blit (source, destination, material);
		}
	}

	/// <summary>
	/// Ensures that we have a texture for our lighting processing.
	/// </summary>
	/// <param name="forceRefresh">If an existing texture should be recreated</param>
	private void EnsureTexture(bool forceRefresh = false) {
		if (forceRefresh && lightCamera.targetTexture != null)
			lightCamera.targetTexture.Release ();

		if (lightCamera.targetTexture == null) {
			var texture = new RenderTexture (Screen.width, Screen.height, 24);
			texture.name = "Light texture";
			texture.filterMode = FilterMode.Point;
			lightCamera.targetTexture = texture;

			if (material == null) {
				material = new Material( shader );
				material.hideFlags = HideFlags.HideAndDontSave;
			}
			material.SetTexture( "_LightsTex", lightCamera.targetTexture );
			material.SetFloat( "_MultiplicativeFactor", intensity );
		}
	}
}
