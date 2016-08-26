using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MonstersPool : MonoSingleton <MonstersPool> 
{
	public delegate void MonstersPoolDelegate ();
	public event MonstersPoolDelegate PoolIsFull;

	public List <GameObject> basicMonstersPrefabs;

	//[HideInInspector]
	public List <BasicMonster> monstersPool = null;

	public int maxCountOfMonstersInPool = 50;

	void Awake () 
	{
		monstersPool = new List<BasicMonster> (maxCountOfMonstersInPool);
		FillPool (ref this.monstersPool);
	}

	public BasicMonster GetMonsterFromPool ()
	{
		var randValue = UnityEngine.Random.Range (0, maxCountOfMonstersInPool - 1);

		if(monstersPool[randValue] != null && !monstersPool[randValue].enabled)
		{
			monstersPool[randValue].gameObject.SetActive(true);
			MainSceneManager.Instance.CurrentMonstersCount ++;
			return monstersPool[randValue];
		}
		else
			return GetMonsterFromPool (); //Can be looped if GameConstants.maxCountOfMonstersOnScene == maxCountOfMonstersInPool
	}
		
	private void FillPool (ref List <BasicMonster> monstersPool)
	{
		var enumValues = Enum.GetValues(typeof(MonsterType));

		for (int i = 0; i < maxCountOfMonstersInPool; i++)
		{
			CreateMonster ((MonsterType)UnityEngine.Random.Range(0, enumValues.Length));
			//CreateMonster (MonsterType.SIMPLE);
		}

		if(PoolIsFull != null)
			PoolIsFull();

	}

	private void CreateMonster (MonsterType typeOfMonster) 
	{
		GameObject monster = null;
		switch (typeOfMonster)
		{
			case MonsterType.SIMPLE:
				{
					monster = CreateSimpleMonster ();
					break;
				}
			case MonsterType.FAT:
				{
					CreateFatMonster();
					break;
				}
			case MonsterType.SPEEDY:
				{
					CreateSpeedyMonster ();
					break;
				}
			default:
			{
				Debug.LogWarning ("You doing something wrong");
				break;
			}
		}
		if(monster != null)
			monstersPool.Add (monster.GetComponent<BasicMonster> ());
	}

	private GameObject CreateSimpleMonster ()
	{
		GameObject m = null;

		foreach (GameObject monsterPrefab in basicMonstersPrefabs)
		{
			if(!monsterPrefab.GetComponent <SimpleMonster> ())
			{
				continue;
			}
			else
			{
				m = CreateMonsterGO (monsterPrefab);
				var sMonster = m.GetComponent<SimpleMonster> ();
				var iMoveStrategy = m.AddComponent<FollowMonsterMovement> ();
				sMonster.InitMonster(Vector3.zero, 50f, iMoveStrategy);
			}
		}
		return m;
	}

	private GameObject CreateFatMonster ()
	{
		GameObject m = null;

		foreach (GameObject monsterPrefab in basicMonstersPrefabs)
		{
			if(!monsterPrefab.GetComponent <FatMonster> ())
			{
				continue;
			}
			else
			{
				m = CreateMonsterGO (monsterPrefab);
				var sMonster = m.GetComponent<FatMonster> ();
				var iMoveStrategy = m.AddComponent<FollowMonsterMovement> ();
				sMonster.InitMonster(Vector3.zero, 50f, iMoveStrategy);
			}
		}
		return m;
	}

	private GameObject CreateSpeedyMonster ()
	{
		GameObject m = null;

		foreach (GameObject monsterPrefab in basicMonstersPrefabs)
		{
			if(!monsterPrefab.GetComponent <SpeedyMonster> ())
			{
				continue;
			}
			else
			{
				m = CreateMonsterGO (monsterPrefab);
				var sMonster = m.GetComponent<SpeedyMonster> ();
				var iMoveStrategy = m.AddComponent<FollowMonsterMovement> ();
				sMonster.InitMonster(Vector3.zero, 50f, iMoveStrategy);
			}
		}
		return m;
	}

	private GameObject CreateMonsterGO (GameObject go)
	{
		var m = Instantiate (go);
		m.transform.SetParent(this.transform);
		m.SetActive (false);
		return m;
	}
}
