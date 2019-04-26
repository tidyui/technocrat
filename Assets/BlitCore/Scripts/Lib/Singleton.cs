/*
 * BlitCore 2D Framework
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * http://github.com/blitbusters
 * 
 */

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using System.Collections;

namespace BlitCore
{
	/// <summary>
	/// Base class for creating singleton game objects.
	/// </summary>
	public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
	{
		/// <summary>
		/// The private singleton instance.
		/// </summary>
		private static T instance;

		/// <summary>
		/// Mutex for initializing the mutex.
		/// </summary>
		private static object mutex = new object();

		/// <summary>
		/// Gets the singleton instance.
		/// </summary>
		/// <value>The instance.</value>
		public static T Instance {
			get {
				if (instance == null) {
					lock (mutex) {
						if (instance == null) {
							instance = GameObject.FindObjectOfType<T> ();

							#if UNITY_EDITOR
							if (!EditorApplication.isPlaying)
								return instance;
							#endif

							if (instance != null)
								DontDestroyOnLoad (instance);
						}
					}
				}
				return instance;
			}
		}
			
		/// <summary>
		/// Awakes the script.
		/// </summary>
		protected virtual void Awake () {
			#if UNITY_EDITOR
			if (!EditorApplication.isPlaying)
				return;
			#endif

			if (instance == null) {
				lock (mutex) {
					if (instance == null) {
						instance = (T)this;
						DontDestroyOnLoad (this);
					}
				}
			} else if (instance != null) {
				Destroy (this.gameObject);
			}
		}
	}
}
