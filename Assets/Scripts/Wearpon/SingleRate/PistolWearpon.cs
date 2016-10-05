using UnityEngine;
using System.Collections;

public class PistolWearpon : WearponBase 
{

	void Start () 
	{
		//TouchController.OnNextWearponButtonPressed += OnFireButtonPressed;

		this.fireRate = GameConstants.pistolFireRate;
	}

	public override void Fire ()
	{
		Shot ();
	}
		
	void Shot ()
	{
		if(canFire)
			StartCoroutine (FireWithDelay (fireRate));
	}

	IEnumerator FireWithDelay (float delay)
	{
		if (bulletController) 
			bulletController.MakeShot (damage);

		canFire = false;
		yield return new WaitForSeconds (delay);
		canFire = true;
	}

}
