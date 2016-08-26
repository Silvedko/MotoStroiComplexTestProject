using UnityEngine;
using System.Collections;

public class FollowMonsterMovement : MonoBehaviour, IMovable 
{
	public float speed = 0.01f;
	public GameObject target = null;


	void Start ()
	{
		
	}

	void OnEnable ()
	{
		MainSceneManager.Instance.MainCharInit += delegate 
		{
			SetTarget ();
		};
	}

	void Update ()
	{
		if(target != null)
		{
			Move (target, speed);
		}
			
	}

	void SetTarget ()
	{
		target = MainSceneManager.Instance.mainCharacter.gameObject;
	}



	#region Implement interface methods

	public void Move (GameObject gO, float t)
	{
		transform.position = Vector3.Lerp(transform.position, target.transform.position, t);
	}
		
	public void ChangeSpeed (float coeff)
	{
		speed *= coeff;
	}

	#endregion

}
