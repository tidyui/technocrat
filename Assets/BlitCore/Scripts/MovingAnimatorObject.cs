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
using System.Collections;
using System.Collections.Generic;

namespace BlitCore
{
	/// <summary>
	/// Moving animated object using the built in Unity animator.
	/// </summary>
	[RequireComponent(typeof(Animator))]
	public class MovingAnimatorObject : MovingObject
	{
		/// <summary>
		/// The animator.
		/// </summary>
		protected Animator animator;

		/// <summary>
		/// The animation triggers
		/// </summary>
		[Header ("Animation triggers")]
		public string idle;
		public string down;
		public string up;
		public string right;
		public string left;
		public string topRight;
		public string topLeft;

		/// <summary>
		/// Starts the behaviour.
		/// </summary>
		protected override void Start () {
			base.Start();

			animator = GetComponent <Animator> ();

			if (BlitEngine.Instance.movementStyle == MovementStyle.SixWay) {
				if (string.IsNullOrEmpty (topRight))
					topRight = right;
				if (string.IsNullOrEmpty (topLeft))
					topLeft = left;
			}
		}

		/// <summary>
		/// Triggers the correct animation given the current direction.
		/// </summary>
		protected override void TriggerAnimation (Direction dir) { 
			if (dir != Direction.None) {
				if (dir != direction || isIdle) {
					animator.ResetTrigger ("idle");

					if (dir == Direction.Down)
						animator.SetTrigger (down);
					else if (dir == Direction.Up)
						animator.SetTrigger (up);
					else if (dir == Direction.Right)
						animator.SetTrigger (right);
					else if (dir == Direction.Left)
						animator.SetTrigger (left);
					else if (dir == Direction.TopRight)
						animator.SetTrigger (topRight);
					else if (dir == Direction.TopLeft)
						animator.SetTrigger (topLeft);

					isIdle = false;
					direction = dir;
				}
			} else {
				if (!isIdle) {
					animator.SetTrigger (idle);
					isIdle = true;
				}
			}
		}
	}
}

