using UnityEngine;
using System.Collections;

public class SimpleBullet : BasicBullet
{
	public float damage = 0;

	public SimpleBullet (float damage)
	{
		this.damage = damage;
	}

	protected override void OnCollisionEnter (Collision col)
	{
		base.OnCollisionEnter(col);
		//Do smth. Explode or particle amination.
	}
}
