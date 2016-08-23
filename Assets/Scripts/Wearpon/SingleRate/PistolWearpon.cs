using UnityEngine;
using System.Collections;

public class PistolWearpon : BasicWearpon 
{
	float pistolFireRate = 1f;

	void Start () 
	{
		TouchController.OnFirstMouseButtonPressed += delegate() { OnFireButtonPressed (); };

		this.fireRate = pistolFireRate;
	}
	
	protected override void OnFireButtonPressed ()
	{
		
	}
}
