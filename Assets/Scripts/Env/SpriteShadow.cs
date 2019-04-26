/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

using UnityEngine;

[ExecuteInEditMode]
public class SpriteShadow : MonoBehaviour {
	public Color color = Color.black;

	private SpriteRenderer spriteRenderer;

	void OnEnable() {
		spriteRenderer = GetComponent<SpriteRenderer>();

		UpdateOutline(true);
	}

	void UpdateOutline(bool outline) {
		MaterialPropertyBlock mpb = new MaterialPropertyBlock();
		spriteRenderer.GetPropertyBlock(mpb);
		mpb.SetColor("_Color", color);
		spriteRenderer.SetPropertyBlock(mpb);
	}
}
