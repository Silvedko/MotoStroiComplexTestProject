using UnityEngine;
using System.Collections;

public class FollowMonsterMovement : MonoBehaviour, IMovable 
{
	public float speed = 10000f;
	public GameObject target = null;


	void Start ()
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
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.3f);
	}
		
	public void ChangeSpeed (float coeff)
	{
		speed *= coeff;
	}

	#endregion

}
