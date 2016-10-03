using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour 
{
	public BulletBase bulletPrefab;
	public Transform bulletSpawner;

	private float bulletSpeed = 1000;

	public void MakeShot (float damage) 
	{
		var bullet = CreateBullet (bulletPrefab);
		bullet.transform.Rotate (Vector3.left * 90);
		bullet.transform.position = bulletSpawner.position;
		bullet.GetComponent<Rigidbody> ().AddForce(transform.forward * bulletSpeed);
		bullet.Damage = damage;

		bullet.DestroyBullet (5);
	}


	BulletBase CreateBullet (BulletBase bulletPrefab) 
	{
		BulletBase bul = Instantiate (bulletPrefab);
		return bul;
	}


		
}
