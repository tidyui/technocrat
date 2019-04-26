/*
 * BlitCore 2D Framework
 * 
 * Copyright (c) 2016-2017 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * http://github.com/blitbusters
 * 
 */

using UnityEngine;
using System;
using System.Collections;

namespace BlitCore
{
	/// <summary>
	/// The main singleton BlitCore engine object. This component is needed by
	/// all other components.
	/// </summary>
	public sealed class BlitEngine : Singleton<BlitEngine>
	{
		/// <summary>
		/// The private zoom level.
		/// </summary>
		private int zoom = 1;

		/// <summary>
		/// The previous screen height.
		/// </summary>
		private float height = 0f;

		/// <summary>
		/// The pixel per unit resolution for the game.
		/// </summary>
		public int pixelsPerUnit;

		/// <summary>
		/// The target height in pixels.
		/// </summary>
		public int targetHeight;

		/// <summary>
		/// The aspect style.
		/// </summary>
		public AspectStyle aspectStyle;

		/// <summary>
		/// The current screen setup.
		/// </summary>
		public ScreenSetup screen;

		/// <summary>
		/// The movement style
		/// </summary>
		public MovementStyle movementStyle = MovementStyle.FourWay;

		/// <summary>
		/// The search style.
		/// </summary>
		public SearchStyle searchStyle;

		/// <summary>
		/// The pickup style.
		/// </summary>
		public PickupStyle pickupStyle;

		/// <summary>
		/// The currently active input controller.
		/// </summary>
		public IInput Input { get; set; }

		/// <summary>
		/// Gets/sets the currently calculated zoom level.
		/// </summary>
		public int Zoom { 
			get {
				return zoom;
			}
			set {
				zoom = Math.Max (value, 1);
			}
		}

		/// <summary>
		/// Gets the current pixel per unit.
		/// </summary>
		public int PixelsPerUnit { 
			get { return pixelsPerUnit; }
		}

		/// <summary>
		/// Gets/sets the current game state.
		/// </summary>
		public GameState State { get; set; }

		/// <summary>
		/// Starts the game manager.
		/// </summary>
		void Start () {
			if (aspectStyle == AspectStyle.TopDown) {
				// This is top down aspect, make sure that 
				// y-scale gravity is disabled
				Physics2D.gravity = new Vector2(0, 0);
			}

			// Check for startup component
			var startup = GetComponent<IStartup> ();
			if (startup != null)
				startup.Init ();
		}

		/// <summary>
		/// Checks if any screen properties as been changed since the last update.
		/// </summary>
		void Update () {
			if (Screen.height != height) {
				var mgr = BlitEngine.Instance;
				var pix = pixelsPerUnit > 0 ? pixelsPerUnit : mgr.pixelsPerUnit;

				if (targetHeight != 0 && mgr.pixelsPerUnit != 0) {
					height = Screen.height;
					screen = ScreenSetup.Get (Screen.width, Screen.height, targetHeight, pix);

					mgr.Zoom = screen.zoom;
				}                  
			}
		}
	}
}
