/*
 * Technocrat
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * 
 */

using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class RoomManager : MonoBehaviour 
{
    [Header("Meta data")]
	public string mapPath;

	[Header("Room layout")]
	public ExitHorizontalType topExit;
	public ExitHorizontalType bottomExit;
	public ExitVerticalType leftExit;
	public ExitVerticalType rightExit;

	//
	// The different layouts groups
    //
	private GameObject topNone;
	private GameObject topCenter;
    private GameObject topFull;
	private GameObject topLeft;
	private GameObject topRight;
    
	private GameObject bottomNone;
	private GameObject bottomCenter;
	private GameObject bottomFull;
	private GameObject bottomLeft;
	private GameObject bottomRight;

	private GameObject leftNone;
	private GameObject leftCenter;
	private GameObject leftFull;
	private GameObject leftBottom;
	private GameObject leftTop;

	private GameObject rightNone;
	private GameObject rightCenter;
	private GameObject rightFull;
	private GameObject rightBottom;
	private GameObject rightTop;

    void Start() {
		//
		// Get the layout groups.
		//
		topNone = transform.Find (RoomConstants.TOP_NONE).gameObject;
		topCenter = transform.Find (RoomConstants.TOP_CENTER).gameObject;
		topFull = transform.Find (RoomConstants.TOP_FULL).gameObject;
		topLeft = transform.Find (RoomConstants.TOP_LEFT).gameObject;
		topRight = transform.Find (RoomConstants.TOP_RIGHT).gameObject;

		bottomNone = transform.Find (RoomConstants.BOTTOM_NONE).gameObject;
		bottomCenter = transform.Find (RoomConstants.BOTTOM_CENTER).gameObject;
		bottomFull = transform.Find (RoomConstants.BOTTOM_FULL).gameObject;
		bottomLeft = transform.Find (RoomConstants.BOTTOM_LEFT).gameObject;
		bottomRight = transform.Find (RoomConstants.BOTTOM_RIGHT).gameObject;

		leftNone = transform.Find (RoomConstants.LEFT_NONE).gameObject;
		leftCenter = transform.Find (RoomConstants.LEFT_CENTER).gameObject;
		leftFull = transform.Find (RoomConstants.LEFT_FULL).gameObject;
		leftBottom = transform.Find (RoomConstants.LEFT_BOTTOM).gameObject;
		leftTop = transform.Find (RoomConstants.LEFT_TOP).gameObject;

		rightNone = transform.Find (RoomConstants.RIGHT_NONE).gameObject;
		rightCenter = transform.Find (RoomConstants.RIGHT_CENTER).gameObject;
		rightFull = transform.Find (RoomConstants.RIGHT_FULL).gameObject;
		rightBottom = transform.Find (RoomConstants.RIGHT_BOTTOM).gameObject;
		rightTop = transform.Find (RoomConstants.RIGHT_TOP).gameObject;

		Setup ();
    }

	#if UNITY_EDITOR
	/// <summary>
	/// Only change the layout in runtime if we're using
	/// the editor window.
	/// </summary>
	void Update() {
		if (EditorApplication.isPlaying ) 
			return;
		Setup ();		
	}
	#endif

	/// <summary>
	/// Activates the correct child objects given the
	/// currently selected room layout.
	/// </summary>
	void Setup() {
		// Check so we're initialized
		if (topNone == null)
			return;

		topNone.SetActive (topExit == ExitHorizontalType.None);
		topCenter.SetActive (topExit == ExitHorizontalType.Center);
		topFull.SetActive (topExit == ExitHorizontalType.Full);
		topLeft.SetActive (topExit == ExitHorizontalType.Left);
		topRight.SetActive (topExit == ExitHorizontalType.Right);

		bottomNone.SetActive (bottomExit == ExitHorizontalType.None);
		bottomCenter.SetActive (bottomExit == ExitHorizontalType.Center);
		bottomFull.SetActive (bottomExit == ExitHorizontalType.Full);
		bottomLeft.SetActive (bottomExit == ExitHorizontalType.Left);
		bottomRight.SetActive (bottomExit == ExitHorizontalType.Right);

		leftNone.SetActive (leftExit == ExitVerticalType.None);
		leftCenter.SetActive (leftExit == ExitVerticalType.Center);
		leftFull.SetActive (leftExit == ExitVerticalType.Full);
		leftBottom.SetActive (leftExit == ExitVerticalType.Bottom);
		leftTop.SetActive (leftExit == ExitVerticalType.Top);

		rightNone.SetActive (rightExit == ExitVerticalType.None);
		rightCenter.SetActive (rightExit == ExitVerticalType.Center);
		rightFull.SetActive (rightExit == ExitVerticalType.Full);
		rightBottom.SetActive (rightExit == ExitVerticalType.Bottom);
		rightTop.SetActive (rightExit == ExitVerticalType.Top);
	}
}