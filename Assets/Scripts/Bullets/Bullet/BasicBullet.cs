using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public abstract class BasicBullet : MonoBehaviour, IDamageDealer 
{
	public delegate void BulletDelegate(GameObject obj);
	public event BulletDelegate OnBulletCollide;

	protected virtual void OnCollisionEnter (Collision col)
	{
		if(OnBulletCollide != null)
		{
			OnBulletCollide (col.gameObject);
			Hit();
		}
	}

	public virtual void Hit ()
	{

	}

}
