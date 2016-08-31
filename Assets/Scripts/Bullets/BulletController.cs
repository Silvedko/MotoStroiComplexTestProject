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
		bullet.transform.Rotate (Vector3.left * 90);

		bullet.GetComponent<Rigidbody> ().AddForce(transform.forward * bulletSpeed);

		Destroy (bullet, 5f);
	}



	
	// Update is called once per frame
	GameObject CreateBullet (GameObject bulletPrefab) 
	{
		return Instantiate (bulletPrefab, bulletSpawner.position, Quaternion.identity) as GameObject;
	}
}
