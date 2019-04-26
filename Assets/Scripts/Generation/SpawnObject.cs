/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

using UnityEngine;

public class SpawnObject : MonoBehaviour 
{
	[Range(0f, 1f)]
	public float threshold = 0.5f;
	public GameObject[] objects;


	// Use this for initialization
	void Start () {
		if (Random.Range (0f, 1f) < threshold) {
			var rand = Random.Range (0, objects.Length);

			var go = Instantiate (objects [rand], new Vector3 (transform.position.x, transform.position.y), Quaternion.identity);
			go.transform.parent = transform.parent;
		}
		Destroy (gameObject);
	}
}
