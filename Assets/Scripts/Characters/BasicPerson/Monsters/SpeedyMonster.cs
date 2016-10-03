using UnityEngine;
using System.Collections;

public class SpeedyMonster : MonsterBase 
{

	public override void InitMonster (Vector3 position, float hitPoints, float damage, IMovable moveStrategyArg = null)
	{
		base.InitMonster (position, hitPoints, damage, moveStrategyArg);

	}

	protected override void OnCollisionEnter (Collision col)
	{
		base.OnCollisionEnter (col);
		if(col.gameObject.GetComponent<IDamageDealer> () != null)
			if (HitPoints < GameConstants.SPEEDY_MONSTER_HP / 2)
				moveStrategy.ChangeSpeed(1.5f);
	}
}
