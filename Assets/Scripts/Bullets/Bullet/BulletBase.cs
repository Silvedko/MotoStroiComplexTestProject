using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
[RequireComponent (typeof (Rigidbody))]
public class BulletBase : MonoBehaviour, IDamageDealer 
{
	public float Damage { get{ return m_damage;} set{ m_damage = value;}}
	private float m_damage;


	void OnCollisionEnter (Collision col)
	{
		IHittable hit = col.gameObject.GetComponent <IHittable> ();

		if (hit != null) 
		{
			hit.ReceiveDamage (this);
			DestroyBullet ();
		}
		
	}

	/// <summary>
	/// Destroies the bullet.
	/// </summary>
	public void DestroyBullet ()
	{
		if (this) 
		{
			Destroy (this.gameObject);
		}
	}

	public void DestroyBullet (float delay)
	{
		StartCoroutine (DestroyBulletWithDelay(delay));
	}

	/// <summary>
	/// Destroies the bullet with delay if bullet not hit any obstacle.
	/// </summary>
	/// <returns>The bullet with delay.</returns>
	/// <param name="delay">Delay.</param>
	IEnumerator DestroyBulletWithDelay (float delay)
	{
		yield return new WaitForSeconds (delay);

		if (this)
			DestroyBullet ();
	}


}
