﻿using UnityEngine;
using System.Collections;

public class AutomaticWearpon : BasicWearpon 
{
	float automaticFireRate = 3f;

	void Start () 
	{
		TouchController.OnFirstMouseButtonPressed += delegate() { OnFireButtonPressed (); };

		this.fireRate = automaticFireRate;
	}

	protected override void Update ()
	{
		base.Update();
	}

	public override void OnFireButtonPressed ()
	{
		base.OnFireButtonPressed();
	}
}
