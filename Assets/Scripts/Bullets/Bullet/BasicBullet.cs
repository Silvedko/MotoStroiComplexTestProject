using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public abstract class BasicBullet : MonoBehaviour 
{
	public delegate void BulletDelegate(GameObject obj);
	public event BulletDelegate OnBulletCollide;

	protected virtual void OnCollisionEnter (Collision col)
	{
		if(OnBulletCollide != null)
			OnBulletCollide (col.gameObject);
	}

}
