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

public class FOW : MonoBehaviour 
{
	private GameObject player;
	private bool isInitialized = false;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");

	}
	
	// Update is called once per frame
	void Update () {
		if (!isInitialized && BlitEngine.Instance.screen.width > 0) {
			var fowX = (BlitEngine.Instance.screen.width * 1.5f) / 480;
			var fowY = (BlitEngine.Instance.screen.height * 1.5f) / 288;

			transform.localScale = new Vector2 () { 
				x = fowX,
				y = fowY
			};
			isInitialized = true;
		}

		var playerX = player.transform.position.x;
		var playerY = player.transform.position.y;

		var x = (playerX - transform.position.x) / 2;
		var y = (playerY - transform.position.y) / 2;

		var target = new Vector3 (transform.parent.position.x + x, transform.parent.position.y + y, 0);

		var factor = 1 / Vector3.Distance (target, transform.position);
		transform.position = Vector3.Lerp(this.transform.position, target, 16f * factor * Time.deltaTime);
	}
}
