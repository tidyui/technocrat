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
using BlitCore;

/// <summary>
/// Extensions for easy access to the core components.
/// </summary>
public static class GameExtensions
{
	/// <summary>
	/// Checks if the current gameobject is a container.
	/// </summary>
	public static bool IsContainer (this GameObject go) {
		return go.GetComponent<ContainerObject> () != null;
	}

	/// <summary>
	/// Checks if the current gameobject is a destructible.
	/// </summary>
	public static bool isDestructible (this GameObject go) {
		return go.GetComponent<DestructibleObject> () != null;
	}

	/// <summary>
	/// Checks if the current gameobject is a device.
	/// </summary>
	public static bool IsDevice (this GameObject go) {
		return go.GetComponent<IDevice> () != null;
	}

	/// <summary>
	/// Gets the container component.
	/// </summary>
	public static ContainerObject GetContainer(this GameObject go) {
		return go.GetComponent<ContainerObject> ();
	}

	/// <summary>
	/// Gets the destructible component.
	/// </summary>
	public static DestructibleObject GetDestructible(this GameObject go) {
		return go.GetComponent<DestructibleObject> ();
	}

	/// <summary>
	/// Gets the device component.
	/// </summary>
	public static IDevice GetDevice(this GameObject go) {
		return go.GetComponent<IDevice> ();
	}

	/// <summary>
	/// Gets the direction of the movement vector.
	/// </summary>
	public static BlitCore.Direction ToDirection(this Vector2 vector) {
		return Utils.ToDirection (vector);
	}

	/// <summary>
	/// Converts the direction to a Vector2 direction.
	/// </summary>
	public static Vector2 ToVector(this BlitCore.Direction direction) {
		return Utils.ToVector (direction);
	}

	/// <summary>
	/// Fades in the gameobject attached to the transform.
	/// </summary>
	public static void FadeIn(this Transform transform) {
		FadeIn (transform.gameObject);
	}

	/// <summary>
	/// Fades in the gameobject.
	/// </summary>
	public static void FadeIn(this GameObject go) {
		var fo = go.GetComponent<FadingObject> ();

		if (fo != null)
			fo.FadeIn ();
	}

	/// <summary>
	/// Fades out the gameobject attached to the transform.
	/// </summary>
	public static void FadeOut(this Transform transform) {
		FadeOut (transform.gameObject);
	}

	/// <summary>
	/// Fades out the gameobject.
	/// </summary>
	public static void FadeOut(this GameObject go) {
		var fo = go.GetComponent<FadingObject> ();

		if (fo != null)
			fo.FadeOut ();
	}
}
