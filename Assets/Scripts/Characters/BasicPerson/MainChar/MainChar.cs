using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MainChar : PersonBase 
{
	WearponController wpController = null;

	public override void Init (Vector3 position, float hitPoints)
	{
		this.gameObject.transform.localPosition = position;

		//TouchController.OnPrevWearponButtonPressed += SwitchWearpon;
		TouchController.OnFireButtonDown += OnFireButtonDown;

		if(hitPoints > 0)
			HitPoints = hitPoints;
		else 
			Debug.LogWarning ("HitPoints must be positive!");
	}

	void OnFireButtonDown ()
	{
		wpController.Fire (); 
	}
		

	void SwitchWearpon ()
	{
		wpController.SwitchWearpon();
	}

	void Start () 
	{
		wpController = FindObjectOfType <WearponController> ();
	}


	public override void ReceiveDamage (IDamageDealer damageDealer)
	{
		HitPoints -= damageDealer.Damage;
	}

	protected override void OnCollisionEnter (Collision col)
	{
		try
		{
			MonsterBase monster = col.gameObject.GetComponent<MonsterBase> ();
			if(monster != null)
			{
				ReceiveDamage (monster);
			}
		}
		catch (NullReferenceException)
		{
			//It's not a monster
		}
	}
}
