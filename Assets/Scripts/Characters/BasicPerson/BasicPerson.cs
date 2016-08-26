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
		Debug.Log ("Reduce!");
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
