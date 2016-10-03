using UnityEngine;
using System.Collections;

public class SimpleMonster : MonsterBase 
{

	public override void InitMonster (Vector3 position, float hitPoints, float damage, IMovable moveStrategyArg = null)
	{
		base.InitMonster (position, hitPoints, damage, moveStrategyArg);
		//Init (position, hitPoints);
		//this.moveStrategy = moveStrategyArg;
	}
	

}
