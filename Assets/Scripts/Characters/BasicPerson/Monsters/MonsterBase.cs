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

public class MonsterBase : PersonBase, IDamageDealer
{
	public float Damage { get{ return m_Damage; } set{ m_Damage = value; }}
	private float m_Damage;

	protected IMovable moveStrategy;

	public override void Init (Vector3 position, float hitPoints)
	{
		base.Init (position, hitPoints);
	}

	public virtual void InitMonster (Vector3 position, float hitPoints, float damage, IMovable moveStrategyArg)
	{
		Init (position, hitPoints);
		this.Damage = damage;
		this.moveStrategy = moveStrategyArg;
	}

	public override void ReceiveDamage (IDamageDealer damageDealer)
	{
		Debug.Log (damageDealer);
		base.ReceiveDamage (damageDealer);
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
