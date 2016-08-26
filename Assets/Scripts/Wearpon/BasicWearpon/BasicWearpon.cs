using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class BasicWearpon : MonoBehaviour
{
	public BulletController bulletController = null;

	protected float fireRate = 0;
	protected float timeAfterShot = 0;
	protected bool canFire = true;

	protected virtual void Update ()
	{
		timeAfterShot += Time.deltaTime;

		if(timeAfterShot >= 1/fireRate)
		{
			canFire = true;
			timeAfterShot = 0;
		}

	}

	public virtual void OnFireButtonPressed ()
	{
		if(bulletController && canFire)
		{
			bulletController.MakeShot();
			canFire = false;
		}
	}
		
}
