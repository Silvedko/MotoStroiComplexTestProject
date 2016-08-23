using UnityEngine;
using System.Collections;

/// <summary>
/// Monster type. Add if need new types of monsters. Needs for pool.
/// </summary>
public enum MonsterType : int
{
	BASIC = 0,
	FAT,
	SPEEDY
}

public abstract class BasicMonster : BasicPerson 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
