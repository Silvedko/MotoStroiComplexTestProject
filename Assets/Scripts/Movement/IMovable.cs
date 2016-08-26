using UnityEngine;

public interface IMovable 
{
	void Move(GameObject gO, float speed);
	void ChangeSpeed (float coeff);
}
