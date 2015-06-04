using UnityEngine;
using System.Collections;

public class Common{
	private static float lastTouchTime = 0.0f;
	private static float touchInterval = 0.1f;

	public static bool isTouched()
	{
		if ((lastTouchTime + touchInterval) > Time.time) {
			return false;
		}

		lastTouchTime = Time.time;

		bool touched = Input.GetButton ("Fire1");
		if(touched == false)
			touched = Input.GetKey (KeyCode.Space);

		return touched;
	}



}
