using UnityEngine;
using System.Collections;

public class FatMonster : BasicMonster 
{
	public float armor = 0.7f;

	public override void InitMonster (Vector3 position, float hitPoints, IMovable moveStrategyArg = null)
	{
		base.InitMonster (position, hitPoints, moveStrategyArg);

	}

	public override void ReduceHitPoints (float hp)
	{
		HitPoints -= hp * armor;
	}
}
