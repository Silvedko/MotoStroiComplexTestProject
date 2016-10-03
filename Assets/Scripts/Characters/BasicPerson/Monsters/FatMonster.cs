using UnityEngine;
using System.Collections;

public class FatMonster : MonsterBase 
{
	public float armor = 0.7f;

	public override void InitMonster (Vector3 position, float hitPoints, float damage, IMovable moveStrategyArg = null)
	{
		base.InitMonster (position, hitPoints, damage, moveStrategyArg);

	}

	public override void ReceiveDamage (IDamageDealer damageDealer)
	{
		HitPoints -= damageDealer.Damage * armor;
	}
}
