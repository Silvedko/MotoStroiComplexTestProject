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
	public event MainCharDelegate MainCharWinGame;

	private int monsterWaitCount = GameConstants.maxCountOfMonstersOnScene;

	public int CurrentMonstersCount 
	{
		get{ return currMonstersCount; }
		set {
				currMonstersCount = value;
			if (currMonstersCount == 0 && monsterWaitCount == 0) 
			{
				FinishGame ();

				if (MainCharWinGame != null) 
				{
					MainCharWinGame ();
				}
			}
			}
	}
	private int currMonstersCount = 0;

	void Awake ()
	{
		if(MonstersPool.Instance)
			MonstersPool.Instance.PoolIsFull += delegate { 
				InitMonsters ()
				;};
		
		CurrentMonstersCount = 0;
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

	public void FinishGame ()
	{
		SceneManager.LoadScene(2);
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
		StartCoroutine (InitMonstersWithDelay(GameConstants.DELAY_TO_INIT_MONSTERS));
	}
		
	IEnumerator InitMonstersWithDelay (float delay)
	{
		for (int i = 0; i < GameConstants.maxCountOfMonstersOnScene; i++) 
		{
			yield return new WaitForSeconds (delay);
			GetMonsterFromPool ();
			monsterWaitCount--;
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
