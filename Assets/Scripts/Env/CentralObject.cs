/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[ExecuteInEditMode]
public class CentralObject : BlitCore.SpriteRandomizer 
{
	private GameObject overlap;
	private Animator anim;
	private Sprite[] original;
	private string state = "central-lights";

	public Sprite[] leftSprites;
	public Sprite[] rightSprites;

	protected override void Start () {
		overlap = transform.Find ("overlap").gameObject;
		anim = transform.Find ("light-anim").gameObject.GetComponent<Animator> ();
		original = sprites;

		if (isLeft ()) {
			sprites = leftSprites;
			state = "central-lights-left";
		} else if (isRight ()) {
			sprites = rightSprites;
			state = "central-lights-right";
		}

		base.Start ();

		overlap.SetActive (HasNeighbour());	

		// Start animation at random position
		var rndStart = Random.Range(0, anim.GetCurrentAnimatorStateInfo(0).length);
		anim.Play (state, 0, rndStart);
	}

#if UNITY_EDITOR
	void Update() {
		if (EditorApplication.isPlaying ) 
			return;

		Setup ();

		overlap.SetActive (HasNeighbour());
	}
#endif

	/// <summary>
	/// Check if the central is next to another central.
	/// </summary>
	bool HasNeighbour() {
		var col = Physics2D.OverlapBox (new Vector2 (transform.position.x - 1, transform.position.y), new Vector2 (0.1f, 0.1f), 0);
		return col != null && col.gameObject.GetComponent<CentralObject> () != null;
	}

	/// <summary>
	/// Checks if there's another central to the left.
	/// </summary>
	bool isLeft() {
		var col = Physics2D.OverlapBox (new Vector2 (transform.position.x - 1, transform.position.y), new Vector2 (0.1f, 0.1f), 0);
		return col != null && col.gameObject.tag == "Walls";
	}

	/// <summary>
	/// Checks if there's another central to the right.
	/// </summary>
	bool isRight() {
		var col = Physics2D.OverlapBox (new Vector2 (transform.position.x + 1, transform.position.y), new Vector2 (0.1f, 0.1f), 0);
		return col != null && col.gameObject.tag == "Walls";
	}

	/// <summary>
	/// Sets up the prefab.
	/// </summary>
	void Setup () {
		if (isLeft ()) {
			if (sprites != leftSprites) {
				sprites = leftSprites;
				base.Start ();
			}
		} else if (isRight ()) {
			if (sprites != rightSprites) {
				sprites = rightSprites;
				base.Start ();
			}
		} else if (sprites != original) {
			sprites = original;
			base.Start ();
		}
	}
}
