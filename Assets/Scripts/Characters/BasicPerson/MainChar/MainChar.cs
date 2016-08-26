using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MainChar : BasicPerson 
{
	WearponController wpController = null;

	public override void Init (Vector3 position, float hitPoints)
	{
		this.gameObject.transform.localPosition = position;

		TouchController.OnSecondMouseButtonPressed += delegate {SwitchWearpon ();};

		if(hitPoints > 0)
			HitPoints = hitPoints;
		else 
			Debug.LogWarning ("HitPoints must be positive!");
	}
		

	void SwitchWearpon ()
	{
		wpController.SwitchWearpon();
	}

	void Start () 
	{
		wpController = FindObjectOfType <WearponController> ();
	}


	public override void ReduceHitPoints (float hp)
	{
		HitPoints -= hp;
	}

	protected override void OnCollisionEnter (Collision col)
	{
		try
		{
			BasicMonster monster = col.gameObject.GetComponent<BasicMonster> ();
			if(monster != null)
			{
				ReduceHitPoints (GameConstants.REDUCING_HP_FROM_MONSTERS);
			}
		}
		catch (NullReferenceException)
		{
			//It's not a monster
		}
	}
}
