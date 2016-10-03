using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WearponBase : MonoBehaviour
{
	public BulletController bulletController = null;

	public float damage;

	protected float fireRate = 0;
	protected bool canFire = true;

	public void Fire ()
	{
		if(canFire)
			Shot ();
	}


//	void Update ()
//	{
//		timeAfterShot += Time.time;
//		Debug.Log (timeAfterShot);
//		if(timeAfterShot >= fireRate)
//		{
//			canFire = true;
//			timeAfterShot = 0;
//		}
//	}

	void Shot ()
	{
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
