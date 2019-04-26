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

/// <summary>
/// The main player component.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class PlayerObject : MovingAnimatorObject 
{
	struct PlayerInput {
		public float x;
		public float y;
		public bool action;
		public bool slash;
		public bool fire;
		public bool aim;
		public bool dash;
	}

	enum PlayerAction
	{
		None,
		Dash
		//Shoot,
		//Slash,
		//Aim
	}

	private PlayerInput playerInput = new PlayerInput();
	private Collider2D coll;
	private IInput input = null;
	private PlayerAction action = PlayerAction.None;
	private int dashPos = 0;
	private int dashPausePos = 0;
	private float dustPause = 0f;

	//
	// The player setup
	//
	[Header("Setup")]
	public float walkSpeed = 4;
	public float dashSpeed = 8;
	public int dashLength = 10;
	public int dashPause = 10;

	[Header("Prefabs")]
	public GameObject dust;

	/// <summary>
	/// Starts the behaviour.
	/// </summary>
	protected override void Start() {
		base.Start ();

		coll = gameObject.GetComponent<Collider2D> ();
		direction = Direction.Down;
		isIdle = false;
	}
		
	/// <summary>
	/// Updates the player input.
	/// </summary>
	void Update() {
		if (input == null)
			input = BlitEngine.Instance != null ? BlitEngine.Instance.Input : null;

		if (input != null) {
			// Get all player input
			#if UNITY_EDITOR || UNITY_STANDALONE
			playerInput.x = input.GetHorizontal ();
			playerInput.y = input.GetVertical ();
			#else
			((Mobile)input).ReadMovement ();
			playerInput.x = input.GetHorizontal ();
			playerInput.y = input.GetVertical ();
			#endif
			playerInput.action = input.GetButton ("Y");
			playerInput.slash = input.GetButton ("X");
			playerInput.aim = input.GetButton ("Aim");
			playerInput.dash = input.GetButton ("Dash");
			playerInput.fire = input.GetButton ("Fire");
		}
	}

	/// <summary>
	/// Updates the players behaviour.
	/// </summary>
	protected override void FixedUpdate() {
		var pos = (Vector2)transform.position + coll.offset;

		if (action == PlayerAction.None) {
			if (playerInput.dash && dashPausePos == 0) {
				dashPos = 0;
				action = PlayerAction.Dash;
			}
		} 

		if (action == PlayerAction.None || action == PlayerAction.Dash) {
			// Handle dash
			if (action == PlayerAction.Dash) {
				if (dashPos < dashLength) {
					speed = dashSpeed;
					dashPos++;
				} else {
					dashPausePos = dashPause;
					speed = walkSpeed;
					action = PlayerAction.None;
				}
			}

			if (dashPausePos > 0)
				dashPausePos--;

			// Check so we're not moving against a collider on the x axis
			if (playerInput.x != 0) {
				coll.enabled = false;
				var xHits = Physics2D.RaycastAll (pos, new Vector2 (playerInput.x, 0), 0.47f);
				coll.enabled = true;

				foreach (var hit in xHits) {
					if (hit.collider != null && !hit.collider.isTrigger) {
						playerInput.x = 0;
						break;
					}
				}
			}
			// Check so we're not moving against a collider on the y axis
			if (playerInput.y != 0) {
				coll.enabled = false;
				var yHits = Physics2D.RaycastAll (pos, new Vector2 (0, playerInput.y), 0.47f);
				coll.enabled = true;

				foreach (var hit in yHits) {
					if (hit.collider != null && !hit.collider.isTrigger) {
						playerInput.y = 0;
						break;
					}
				}
			}
				
			// Make sure we normalize movement
			var move = new Vector2 (playerInput.x, playerInput.y);
			if (move.magnitude > 1)
				move.Normalize ();

			// Make some dust
			if (move != Vector2.zero) {
				if (dustPause <= 0) {
					Instantiate (dust, new Vector3 (transform.position.x, transform.position.y - 0.4375f, 0), Quaternion.identity);
					dustPause = 1.5f;
				} else {
					dustPause -= 4 * Time.fixedDeltaTime;
				}
			} else {
				dustPause = 0;
			}

			Move (move);
		}

		base.FixedUpdate ();
	}
}
