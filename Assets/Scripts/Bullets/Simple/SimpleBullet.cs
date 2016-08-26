using UnityEngine;
using System.Collections;

public class SimpleBullet : BasicBullet
{
	public float damage = 5;

	public SimpleBullet (float damage)
	{
		this.damage = damage;
	}

	protected override void OnCollisionEnter (Collision col)
	{
		base.OnCollisionEnter(col);

		if(col.gameObject.GetComponent <IHittable> () != null)
			col.gameObject.GetComponent <IHittable> ().ReduceHitPoints (damage);
	}

	public override void Hit ()
	{
		//Do smth. Explode or particle amination.
	}
}
