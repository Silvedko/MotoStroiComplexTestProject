using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3 (0, 6, -8);

	Vector3 destination = Vector3.zero;
	CharController characterController;
	float rotateVelocity = 0;

	// Use this for initialization
	void Start () 
	{
		SetCameraTarget (target);
	}
	
	void LateUpdate () 
	{
		MoveToTarget ();
		LookAtTarget ();
	}

	void SetCameraTarget (Transform t)
	{
		target = t;

		if(target != null)
		{
			if(target.GetComponent<CharController> ())
			{
				characterController = target.GetComponent<CharController> ();
			}
			else 
				Debug.LogError ("Camera's target needs to CharController");
		}
		else
			Debug.LogError ("Need to set target");
	}

	void MoveToTarget ()
	{
		destination = characterController.TargerRotation * offsetFromTarget;
		destination += target.position;
		transform.position = destination;
	}

	void LookAtTarget ()
	{
		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.transform.eulerAngles.y, ref rotateVelocity, lookSmooth);
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, eulerYAngle, 0);
	}
}
