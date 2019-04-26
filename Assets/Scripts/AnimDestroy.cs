/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimDestroy : MonoBehaviour 
{
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		Destroy (gameObject, anim.GetCurrentAnimatorStateInfo(0).length); 
	}
}
