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
	/// Base class for moving game objects.
	/// </summary>
	[RequireComponent(typeof(Rigidbody2D))]
	public class MovingObject : MovableObject 
	{
		/// <summary>
		/// The rigid body.
		/// </summary>
		protected Rigidbody2D rigidBody;

		/// <summary>
		/// The current movement.
		/// </summary>
		protected Vector2 movement;

		/// <summary>
		/// The current direction.
		/// </summary>
		protected Direction direction = Direction.None;

		/// <summary>
		/// If the object is idle.
		/// </summary>
		protected bool isIdle = true;

		[Header ("Movement")]
		/// <summary>
		/// The movement speed.
		/// </summary>
		public float speed = 5f;
		public bool externalMovement = false;

		/// <summary>
		/// Starts the behaviour.
		/// </summary>
		protected override void Start () {
			base.Start ();

			rigidBody = GetComponent <Rigidbody2D> ();
		}

		/// <summary>
		/// Moves the object.
		/// </summary>
		protected void Move (Vector2 move) {
			movement = move;
		}
						
		/// <summary>
		/// Executed every fixed update cycle.
		/// </summary>
		protected virtual void FixedUpdate () {
			if (BlitEngine.Instance.State == GameState.Running) {
				var move = movement.normalized;
				var dir = movement.ToDirection ();

				if (move != Vector2.zero && !externalMovement) {
					rigidBody.MovePosition (rigidBody.position + move * Time.fixedDeltaTime * speed);
				}
				TriggerAnimation (dir);
			} else {
				TriggerAnimation (Direction.None);
			}

		}

		/// <summary>
		/// Virtual method for subclasses to override,
		/// </summary>
		protected virtual void TriggerAnimation (Direction dir) { }
	}
}
