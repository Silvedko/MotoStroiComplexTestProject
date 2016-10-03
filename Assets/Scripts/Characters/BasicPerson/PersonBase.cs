using UnityEngine;
using System.Collections;

/// <summary>
/// Basic person class
/// </summary>

[RequireComponent (typeof (Collider))]
public class PersonBase : MonoBehaviour, IHittable 
{
	public delegate void BasicPersonDelegate();
	public event BasicPersonDelegate OnZeroHitPointsEvent;

	public float Armor { get { return m_armor; } set { m_armor = value; }}
	private float m_armor;

	public bool IsDead { get { return m_IsDead; } set { m_IsDead = value; }}
	private bool m_IsDead;

	public float HitPoints
	{
		get
		{
			return hitPoints;
		}
		set 
		{
			hitPoints = value;
			if(hitPoints <= 0)
			{
				hitPoints = 0;
				if(OnZeroHitPointsEvent != null)
				{
					OnZeroHitPointsEvent();
				}
				OnDead ();
			}
		}
	}
	private float hitPoints;

	public virtual void Init (Vector3 position, float hitPoints)
	{
		this.gameObject.transform.localPosition = position;
		if(hitPoints > 0)
			HitPoints = hitPoints;
		else 
			Debug.LogWarning ("HitPoints must be positive!");
	}

	#region IHittabble Interface implementation

	/// <summary>
	/// Reduces the hit points. Implementation of IHittable interface.
	/// </summary>
	/// <param name="hp">Hp.</param>
	public virtual void ReceiveDamage (IDamageDealer damageDealer)
	{
		HitPoints -= damageDealer.Damage;
	}

	public virtual void OnDead ()
	{
		Debug.Log ("On Dead!");
	}

	#endregion

	protected virtual void OnCollisionEnter (Collision col)
	{
		
	}


}
