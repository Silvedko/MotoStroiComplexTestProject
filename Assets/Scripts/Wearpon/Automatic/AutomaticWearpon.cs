using UnityEngine;
using System.Collections;

public class AutomaticWearpon : WearponBase 
{

	void Start () 
	{
		this.fireRate = GameConstants.automaticFiraRate;
	}
		

//	public override void OnFireButtonPressed ()
//	{
//		base.OnFireButtonPressed();
//	}
}
