using UnityEngine;
using System.Collections;

public class TouchController : MonoSingleton <TouchController> 
{
	public delegate void TouchControllerDelegate();
	public static event TouchControllerDelegate OnFirstMouseButtonPressed; 
	public static event TouchControllerDelegate OnSecondMouseButtonPressed;

	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
			if(OnFirstMouseButtonPressed != null)
				OnFirstMouseButtonPressed ();
		
		if(Input.GetMouseButtonDown(1))
			if(OnSecondMouseButtonPressed != null)
				OnSecondMouseButtonPressed();

	}
}
