using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WearponBase : MonoBehaviour
{
	public BulletController bulletController = null;

	public float damage;

	protected float fireRate = 0;
	protected bool canFire = true;

	public virtual void Fire ()
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
