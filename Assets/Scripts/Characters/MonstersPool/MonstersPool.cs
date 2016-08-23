using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MonstersPool : MonoSingleton <MonstersPool> 
{
	public List <BasicMonster> basicMonstersPrefabs;

	[HideInInspector]
	public List <BasicMonster> monstersPool = null;

	public int maxCountOfMonstersOnScene = 10;
	public int maxCountOfMonstersInPool = 50;
	public int currentMonstersCount = 0;

	void Awake () 
	{
		monstersPool = new List<BasicMonster> (maxCountOfMonstersInPool);
		FillPool (ref this.monstersPool);

	}

	void FillPool (ref List <BasicMonster> monstersPool)
	{
		var enumValues = Enum.GetValues(typeof(MonsterType));

		for (int i = 0; i < maxCountOfMonstersInPool; i++)
		{
			CreateMonster ((MonsterType)UnityEngine.Random.Range(0, enumValues.Length));
		}

	}

	void CreateMonster (MonsterType typeOfMonster) 
	{
		switch (typeOfMonster)
		{
			case MonsterType.BASIC:
				{
					Debug.Log("Basic");
					break;
				}
			case MonsterType.FAT:
				{
					Debug.Log("Fat");
					break;
				}
			case MonsterType.SPEEDY:
				{
					Debug.Log("Speedy");
					break;
				}
			default:
			{
				Debug.LogWarning ("You doing something wrong");
				break;
			}
		}
	}
}
