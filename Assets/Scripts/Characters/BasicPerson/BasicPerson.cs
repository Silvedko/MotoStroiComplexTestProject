using UnityEngine;
using System.Collections;

/// <summary>
/// Basic person class
/// </summary>

[RequireComponent (typeof (Collider))]
public abstract class BasicPerson : MonoBehaviour, IHittable 
{
	public delegate void BasicPersonDelegate();
	public event BasicPersonDelegate OnZeroHitPointsEvent;

	public float HitPoints
	{
		get
		{
			return hitPoints;
		}
		protected set 
		{
			hitPoints = value;
			if(hitPoints <= 0)
			{
				hitPoints = 0;
				if(OnZeroHitPointsEvent != null)
				{
					OnZeroHitPointsEvent();
				}
				OnDead();
			}
		}
	}
	private float hitPoints;

	#region IHittabble Interface implementation

	public float GetHitPoints ()
	{
		return HitPoints;
	}

	/// <summary>
	/// Reduces the hit points. Implementation of IHittable interface.
	/// </summary>
	/// <param name="hp">Hp.</param>
	public virtual void ReduceHitPoints (float hp)
	{
		Debug.Log ("REduce!");
	}

	public virtual void OnDead ()
	{
		Debug.Log ("OnDead!");
	}

	#endregion

	protected virtual void OnCollisionEnter (Collision col)
	{
		
	}


}
