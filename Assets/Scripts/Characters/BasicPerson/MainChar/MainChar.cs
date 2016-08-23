using UnityEngine;
using System.Collections;
using System;

public class MainChar : BasicPerson 
{
	public MainChar (float startHP)
	{
		HitPoints = startHP;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void ReduceHitPoints (float hp)
	{
		HitPoints -= hp;
	}

	protected override void OnCollisionEnter (Collision col)
	{
		try
		{
			BasicBullet bullet = col.gameObject.GetComponent<BasicBullet> ();
			if(bullet != null)
			{
				//ReduceHitPoints (bullet);
			}
		}
		catch (NullReferenceException)
		{
			//It's not a bullet
		}
	}
}
