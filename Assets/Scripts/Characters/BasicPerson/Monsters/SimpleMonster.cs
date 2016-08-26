using UnityEngine;
using System.Collections;

public class SimpleMonster : BasicMonster 
{

	public override void InitMonster (Vector3 position, float hitPoints, IMovable moveStrategyArg = null)
	{
		Init (position, hitPoints);
		this.moveStrategy = moveStrategyArg;
	}
	

}
