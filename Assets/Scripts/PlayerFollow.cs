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
/// Simple script for making the camera follow the player.
/// </summary>
[RequireComponent (typeof (Camera))]
public class PlayerFollow : MonoBehaviour 
{
	private GameObject player;
	private ScreenSetup screen = null;
	private float minX,minY,maxX,maxY;

	void Update() {
		if (player == null)
			player = GameObject.Find ("Player");

		var target = Utils.RoundToNearestPixel(new Vector3 () {
			x = Mathf.Max (Mathf.Min (player.transform.position.x, maxX), minX),
			y = Mathf.Max (Mathf.Min (player.transform.position.y, maxY), minY),
			z = Camera.main.transform.position.z
		});
		var factor = 1 / Vector3.Distance (target, transform.position);
		transform.position = Vector3.Lerp(this.transform.position, target, 16f * factor * Time.deltaTime);
	}

	void LateUpdate() {
		if (screen == null)
			Setup ();
	}

	void Setup() {
		var mm = GameObject.Find ("Map").GetComponent<MapManager> ();

		screen = BlitEngine.Instance.screen;

		var width = mm.width * mm.segmentWidth;
		var height = mm.height * mm.segmentHeight;

		if (width <= screen.unitWidth) {
			minX = maxX = Utils.RoundToNearestPixel((width / 2) + 0.5f);
		} else {
			minX = Utils.RoundToNearestPixel (screen.unitWidth / 2);
			maxX = Utils.RoundToNearestPixel (width - (screen.unitWidth / 2) - 1);
		}
		minY = Utils.RoundToNearestPixel((screen.unitHeight / 2));
		maxY = Utils.RoundToNearestPixel(height - (screen.unitHeight / 2));

		// Move to initial position
		var target = Utils.RoundToNearestPixel(new Vector3 () {
			x = Mathf.Max (Mathf.Min (player.transform.position.x, maxX), minX),
			y = Mathf.Max (Mathf.Min (player.transform.position.y, maxY), minY),
			z = Camera.main.transform.position.z
		});
		transform.position = target;
	}
}
