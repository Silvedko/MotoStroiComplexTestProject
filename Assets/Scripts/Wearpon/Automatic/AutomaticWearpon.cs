using UnityEngine;
using System.Collections;

public class AutomaticWearpon : WearponBase 
{
	public override void Fire ()
	{
		
	}

	void Start () 
	{
		this.fireRate = GameConstants.automaticFiraRate;
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
