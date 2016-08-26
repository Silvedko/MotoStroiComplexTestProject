using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoSingleton <MainSceneManager> 
{
	public GameObject prefabWithMainChar;

	[HideInInspector]
	public MainChar mainCharacter;

	public delegate void MainCharDelegate ();
	public event MainCharDelegate MainCharInit;


	public int CurrentMonstersCount 
	{
		get{ return currMonstersCount; }
		set {
			
			currMonstersCount = value;				
			}
	}
	private int currMonstersCount = 0;

	void Awake ()
	{
		MonstersPool.Instance.PoolIsFull += delegate { 
			InitMonsters ()
			;};
		

	}

	void Start ()
	{
		InitMainChar ();
		mainCharacter.OnZeroHitPointsEvent += delegate { RestartGame ();};
	}


	public void RestartGame ()
	{
		InitGame ();
	}

	public void InitGame ()
	{
		SceneManager.LoadScene("MainScene"); //Hardcode init/reload scene
	}

	private void GetMonsterFromPool ()
	{
		var monster = MonstersPool.Instance.GetMonsterFromPool();
		monster.EnableMonster ();
	}

	public void InitMonsters ()
	{
		for (int i = 0; i < GameConstants.maxCountOfMonstersOnScene; i++)
		{
			GetMonsterFromPool ();
		}
	}

	public void InitMainChar ()
	{
		if(prefabWithMainChar)
		{
			var mainCharObj = Instantiate (prefabWithMainChar);
			mainCharacter = mainCharObj.GetComponentInChildren<MainChar>();

			mainCharacter.Init(Vector3.zero, GameConstants.START_MAIN_CHAR_HP);
		}

		if(MainCharInit != null)
			MainCharInit ();
	}

}
