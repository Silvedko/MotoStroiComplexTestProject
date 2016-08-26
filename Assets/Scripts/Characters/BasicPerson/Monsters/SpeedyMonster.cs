using UnityEngine;
using System.Collections;

public class SpeedyMonster : BasicMonster 
{

	public override void InitMonster (Vector3 position, float hitPoints, IMovable moveStrategyArg = null)
	{
		Init (position, hitPoints);
		this.moveStrategy = moveStrategyArg;
	}

	protected override void OnCollisionEnter (Collision col)
	{
		base.OnCollisionEnter (col);
		if(col.gameObject.GetComponent<IDamageDealer> () != null)
			if (HitPoints < GameConstants.SPEEDY_MONSTER_HP / 2)
				moveStrategy.ChangeSpeed(1.5f);
	}
}
