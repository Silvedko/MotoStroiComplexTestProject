using UnityEngine;
using System.Collections;

public class TouchController : MonoSingleton <TouchController> 
{
	public delegate void TouchControllerDelegate();
	public static event TouchControllerDelegate OnFireButtonDown;
	public static event TouchControllerDelegate OnNextWearponButtonPressed; 
	public static event TouchControllerDelegate OnPrevWearponButtonPressed;

	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && OnFireButtonDown != null)
			OnFireButtonDown ();

		if(Input.GetKeyDown(KeyCode.W) && OnNextWearponButtonPressed != null)
			OnNextWearponButtonPressed ();
		
		if(Input.GetKeyDown(KeyCode.Q) && OnPrevWearponButtonPressed != null)
			OnPrevWearponButtonPressed ();

	}
}
