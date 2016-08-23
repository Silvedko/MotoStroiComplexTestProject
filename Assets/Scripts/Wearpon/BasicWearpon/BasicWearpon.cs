using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class BasicWearpon : MonoBehaviour
{
	protected float fireRate = 0;

	void Start ()
	{

	}

	protected virtual void OnFireButtonPressed ()
	{
		Debug.Log ("Fire!!");
	}
		
}
