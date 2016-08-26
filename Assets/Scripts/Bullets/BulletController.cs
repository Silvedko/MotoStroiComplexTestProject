using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour 
{
	public GameObject bulletPrefab;
	public Transform bulletSpawner;

	private float bulletSpeed = 1000;

	public void MakeShot () 
	{
		var bullet = CreateBullet (bulletPrefab);

		bullet.GetComponent<Rigidbody> ().AddForce(transform.forward * bulletSpeed);
	}



	
	// Update is called once per frame
	GameObject CreateBullet (GameObject bulletPrefab) 
	{
		return Instantiate (bulletPrefab, bulletSpawner.position, Quaternion.identity) as GameObject;
	}
}
