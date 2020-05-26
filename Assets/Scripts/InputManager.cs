using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This static provides the game with the correct input method, depending on the platform for which the game was built.
/// </summary>
public static class InputManager {

	static IInputSystem instance;
	static IInputSystem Instance{
		get {
			if ( instance == null ) { instance = CreateInstance(); }
			return instance;
		}
	}
	
	public static Vector3 GetCursorPosition(){
		return Instance.GetCursorPosition();
	}

	public static Vector3 GetCursorScreenPosition(float depth = 0){
		return Instance.GetCursorScreenPosition(depth);
	}

	public static bool GetClick(){
		return Instance.GetClick();
	}

	public static bool MouseDown(){
		return Instance.MouseDown();
	}

	// Create platform specific input system.
	static IInputSystem CreateInstance() {
#if UNITY_ANDROID
		return new AndroidInputSystem();
#elif UNITY_STANDALONE
		return new UnityInputSystem();
#endif
	}
}

/// <summary>
/// An interface for all the methods an input system needs to provide.
/// </summary>
public interface IInputSystem {
	Vector3 GetCursorPosition();
	Vector3 GetCursorScreenPosition(float depth = 0);
	bool GetClick();
	bool MouseDown();
}

/// <summary>
/// The input system used for windows builds.
/// </summary>
public class UnityInputSystem : IInputSystem {

    /// <returns>Whether the first mouse button was pushed down.</returns>
    public bool GetClick() {
		return Input.GetMouseButtonDown(0);
	}	
	
    /// <returns>Whether the first mouse button is down.</returns>
    public bool MouseDown() {
		return Input.GetMouseButton(0);
	}
	
	/// <returns>The mouse cursor position</returns>
	public Vector3 GetCursorPosition() {
		return Input.mousePosition;
	}

	/// <summary>
	/// Get the cursor position in world coordinates.
	/// </summary>
	/// <param name="depth">The distance from the camera.</param>
	/// <returns>The world position of the cursor.</returns>
	public Vector3 GetCursorScreenPosition(float depth = 0) {
		Vector3 cursorPos = GetCursorPosition();
		return GameManager.camera.ScreenToWorldPoint(new Vector3(cursorPos.x, cursorPos.y, depth));
	}

}

/// <summary>
/// The input system used for android builds.
/// </summary>
public class AndroidInputSystem : IInputSystem {

	// Since we won't always be touching the screen we need to store the cursor position.
	Vector3 cursorPosition;


	/// <returns>Whether the user started or stopped touching the screen this frame.</returns>
	public bool GetClick() {
		if (Input.touchCount < 1)
			return false;
		Touch touch = Input.GetTouch(0);
		return touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Ended;
	}

	/// <returns>Whether the user is touching the screen.</returns>
    public bool MouseDown() {
		if(Input.touchCount < 1)
			return false;		
		Touch touch = Input.GetTouch(0);
		return touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved;
	}

	/// <returns>The last position at which the user touched the screen.</returns>
	public Vector3 GetCursorPosition() {
		Touch[] touches = Input.touches;
		if ( touches.Length > 0 ) {
			cursorPosition = Input.touches[0].position;
		}
		return cursorPosition;
	}

	/// <summary>
	/// Get the cursor position in world coordinates.
	/// </summary>
	/// <param name="depth">The distance from the camera.</param>
	/// <returns>The world position of the cursor.</returns>
	public Vector3 GetCursorScreenPosition(float depth = 0) {
		Vector3 cursorPos = GetCursorPosition();
		return GameManager.camera.ScreenToWorldPoint(new Vector3(cursorPos.x, cursorPos.y, depth));
	}
}