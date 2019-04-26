/*
 * BlitCore 2D Framework
 * 
 * Copyright (c) 2016 Håkan Edling 
 * hakan@tidyui.com
 * @tidyui
 * http://github.com/blitbusters
 * 
 */

using System.Collections;

namespace BlitCore
{
	/// <summary>
	/// Game startup.
	/// </summary>
	public interface IStartup
	{
		/// <summary>
		/// Initializes the game.
		/// </summary>
		void Init();
	}
}
