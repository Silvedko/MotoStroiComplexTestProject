using UnityEngine;
using System.Collections;

public class SimpleMonster : BasicMonster 
{

	public override void InitMonster (Vector3 position, float hitPoints, IMovable moveStrategyArg = null)
	{
		base.InitMonster (position, hitPoints, moveStrategyArg);
		//Init (position, hitPoints);
		//this.moveStrategy = moveStrategyArg;
	}
	

}
