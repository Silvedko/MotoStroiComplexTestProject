using UnityEngine;
using System.Collections;

public class PistolWearpon : WearponBase 
{

	void Start () 
	{
		//TouchController.OnNextWearponButtonPressed += OnFireButtonPressed;

		this.fireRate = GameConstants.pistolFireRate;
	}
		
	
//	public override void OnFireButtonPressed ()
//	{
//		base.OnFireButtonPressed();
//	}
}
