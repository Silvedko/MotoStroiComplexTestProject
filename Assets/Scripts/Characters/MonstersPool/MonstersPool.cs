using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MonstersPool : MonoSingleton <MonstersPool> 
{
	public delegate void MonstersPoolDelegate ();
	public event MonstersPoolDelegate PoolIsFull;

	public MonsterRespawnsData respawnData;
	[HideInInspector]

	private int respCount = 0;

	public List <GameObject> basicMonstersPrefabs;

	//[HideInInspector]
	public List <MonsterBase> monstersPool = null;

	static int monsterIndex = 0;

	public int maxCountOfMonstersInPool = 50;

	void Start () 
	{
		monstersPool = new List<MonsterBase> (maxCountOfMonstersInPool);
		FillPool (ref this.monstersPool);
	}

	public MonsterBase GetMonsterFromPool ()
	{
		var monster = monstersPool[monsterIndex];
		monsterIndex ++;
		//monstersPool.RemoveAt(0);
		//queue.Enqueue (monster);
		MainSceneManager.Instance.CurrentMonstersCount ++;
		return monster;
	}
		
	private void FillPool (ref List <MonsterBase> monstersPool)
	{
		var enumValues = Enum.GetValues(typeof(MonsterType));

		for (int i = 0; i < maxCountOfMonstersInPool; i++)
		{
			CreateMonster ((MonsterType)UnityEngine.Random.Range(0, enumValues.Length));
			//CreateMonster (MonsterType.SIMPLE);
		}
		//queue = new Queue<BasicMonster>(monstersPool);

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
					monster = CreateFatMonster();
					break;
				}
			case MonsterType.SPEEDY:
				{
					monster = CreateSpeedyMonster ();
					break;
				}
			default:
			{
				Debug.LogWarning ("You doing something wrong");
				break;
			}
		}
		if(monster != null)
			monstersPool.Add (monster.GetComponent<MonsterBase> ());
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

				sMonster.InitMonster(Vector3.zero, 10f, GameConstants.REDUCING_HP_FROM_MONSTERS, iMoveStrategy);
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
				sMonster.InitMonster(Vector3.zero, 15f, GameConstants.REDUCING_HP_FROM_MONSTERS, iMoveStrategy);
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
				sMonster.InitMonster(m.transform.position, 10f, GameConstants.REDUCING_HP_FROM_MONSTERS, iMoveStrategy);
			}
		}
		return m;
	}

	private GameObject CreateMonsterGO (GameObject go)
	{
		var m = Instantiate (go);

		if (respCount >= respawnData.respawns.Count-1)
			respCount = 0;

		m.transform.position = respawnData.respawns [++respCount].position;
		m.transform.SetParent(this.transform);
		m.SetActive (false);
		return m;
	}
}
