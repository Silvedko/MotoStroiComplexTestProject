using UnityEngine;
using System.Collections;

/// <summary>
/// Monster type. Add if need new types of monsters. Needs for pool.
/// </summary>
public enum MonsterType : int
{
	SIMPLE = 0,
	FAT,
	SPEEDY
}

public abstract class BasicMonster : BasicPerson 
{
	
	protected IMovable moveStrategy;

	public override void Init (Vector3 position, float hitPoints)
	{
		base.Init (position, hitPoints);
	}

	public virtual void InitMonster (Vector3 position, float hitPoints, IMovable moveStrategyArg)
	{
		Init (position, hitPoints);
		this.moveStrategy = moveStrategyArg;
	}

	public override void ReduceHitPoints (float hp)
	{
		base.ReduceHitPoints (hp);
	}

	public void EnableMonster ()
	{
		gameObject.SetActive (true);
	}

	public override void OnDead ()
	{
		gameObject.SetActive(false);
		MainSceneManager.Instance.CurrentMonstersCount --;
	}
		
}
