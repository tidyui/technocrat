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
	[RequireComponent(typeof(Collider2D))]
	public abstract class EnemyAnimatorObject<TPlayer> : MovingAnimatorObject where TPlayer : MonoBehaviour
	{
		//
		// Members
		//
		protected GameObject player;
		protected Collider2D enemyCollider;

		//
		// Params for how the enemy can spot the player.
		//
		[Header ("Behaviour")]
		public LayerMask collisionLayer;
		public float castDistance;
		public float closeDistance;
		public float attackDistance;

		/// <summary>
		/// Starts the behaviour.
		/// </summary>
		protected override void Start () {
			enemyCollider = GetComponent<Collider2D> ();

			base.Start ();
		}

		/// <summary>
		/// Executed when the enemy spots the player.
		/// </summary>
		/// <param name="position">The current player position</param>
		protected abstract void OnPlayerFound(Vector2 position);

		/// <summary>
		/// Executed when the enemy can attach the player.
		/// </summary>
		/// <param name="position">The current player position</param>
		protected abstract void OnAttack(Vector2 position);

		/// <summary>
		/// Executed at frame update.
		/// </summary>
		protected override void FixedUpdate() {
			var playerPosition = FindPlayer ();

			if (playerPosition.HasValue) {
				// Call OnPlayerFound
				OnPlayerFound (playerPosition.Value);

				// Check if we can attack
				var distance = Vector2.Distance (transform.position, playerPosition.Value);
				if (distance <= attackDistance) {
					// Call OnAttack
					OnAttack (playerPosition.Value);
				}
			}
			base.FixedUpdate ();
		}

		/// <summary>
		/// Checks if the player is close enough and in the line of sight.
		/// </summary>
		/// <returns>The player position if found</returns>
		protected virtual Vector2? FindPlayer() {
			var position = player.transform.position + (Vector3)player.GetComponent<Collider2D> ().offset;

			if (Vector2.Distance (transform.position, position) <= castDistance) {
				var cast = ShouldCast ();

				if (cast) {
					enemyCollider.enabled = false;
					var hit = Physics2D.Raycast (transform.position, (position - transform.position).normalized, castDistance, collisionLayer);
					enemyCollider.enabled = true;

					if (hit.collider != null) {
						if (hit.collider.gameObject.GetComponent<TPlayer> () != null)
							return hit.collider.gameObject.transform.position;
					}
				}
			}
			return null;
		}

		/// <summary>
		/// Checks if a raycast should be done to see if the player
		/// is in the line of sight.
		/// </summary>
		private bool ShouldCast () {
			var playerPos = player.transform.position;

			if (Vector2.Distance (playerPos, transform.position) > closeDistance) {
				if (direction == Direction.Down)
					return playerPos.y <= transform.position.y;
				else if (direction == Direction.Up)
					return playerPos.y >= transform.position.y;
				else if (direction == Direction.Left)
					return playerPos.x <= transform.position.x;
				else if (direction == Direction.Right)
					return playerPos.x >= transform.position.x;
				return false;
			}
			return true;
		}
	}
}
