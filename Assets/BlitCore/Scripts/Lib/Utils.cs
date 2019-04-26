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
using System;

namespace BlitCore
{
	/// <summary>
	/// Utility methods.
	/// </summary>
	public static class Utils 
	{
		/// <summary>
		/// Rounds the given float to nearest pixel value to avoid texels.
		/// </summary>
		/// <returns>The nearest pixel value</returns>
		/// <param name="unityUnits">Unity units</param>
		public static float RoundToNearestPixel (float unityUnits) {
			var mgr = BlitEngine.Instance;
			var precision = mgr.PixelsPerUnit * mgr.Zoom;

			float valueInPixels = unityUnits * precision;
			valueInPixels = Mathf.Round(valueInPixels);

			return valueInPixels * (1 / (float)precision);
		}

		/// <summary>
		/// Rounds the given position to nearest real pixel value.
		/// </summary>
		/// <returns>The nearest pixel value</returns>
		/// <param name="pos">The position vector</param>
		public static Vector2 RoundToNearestPixel (Vector2 pos) {
			pos.x = RoundToNearestPixel (pos.x);
			pos.y = RoundToNearestPixel (pos.y);
			
			return pos;
		}

		/// <summary>
		/// Rounds the given position to nearest real pixel value.
		/// </summary>
		/// <returns>The nearest pixel value</returns>
		/// <param name="pos">The position vector</param>
		public static Vector3 RoundToNearestPixel (Vector3 pos) {
			pos.x = RoundToNearestPixel (pos.x);
			pos.y = RoundToNearestPixel (pos.y);
			
			return pos;
		}

		/// <summary>
		/// Sets the opacity for the given Sprite Renderer.
		/// </summary>
		/// <param name="r">The rendered</param>
		/// <param name="opacity">The alpha opacity between 0 and 1</param>
		public static void SetOpacity (SpriteRenderer r, float opacity) {
			var color = r.color;
			r.color = new Color (color.r, color.g, color.b, opacity);
		}

		/// <summary>
		/// Converts the vector into a direction.
		/// </summary>
		public static Direction ToDirection(Vector2 vector) {
			if (vector.y == 0) {
				if (vector.x > 0)
					return Direction.Right;
				else if (vector.x < 0)
					return Direction.Left;
				return Direction.None;
			} else {
				if (vector.y < 0.2 || BlitEngine.Instance.movementStyle == MovementStyle.FourWay) {
					if (vector.x > 0.2)
						return Direction.Right;
					else if (vector.x < -0.2)
						return Direction.Left;
					else if (vector.y > 0)
						return Direction.Up;
					return Direction.Down;
				} else {
					if (vector.x > 0.2)
						return Direction.TopRight;
					else if (vector.x < -0.2)
						return Direction.TopLeft;
					return Direction.Up;
				}
			}			
		}

		/// <summary>
		/// Converts the direction into a vector.
		/// </summary>
		public static Vector2 ToVector(Direction direction) {
			if (direction == Direction.Down)
				return Vector2.down;
			else if (direction == Direction.Left)
				return Vector2.left;
			else if (direction == Direction.Right)
				return Vector2.right;
			else if (direction == Direction.TopLeft)
				return Vector2.left + Vector2.up;
			else if (direction == Direction.TopRight)
				return Vector2.right + Vector2.up;
			else
				return Vector2.up;			
		}
	}
}
