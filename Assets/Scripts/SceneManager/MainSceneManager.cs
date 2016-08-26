using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoSingleton <MainSceneManager> 
{
	public GameObject prefabWithMainChar;
	public MainChar mainCharacter;

	public delegate void MainCharDelegate ();
	public event MainCharDelegate MainCharInit;

	void Awake ()
	{
		InitMainChar ();
	}

	void Start ()
	{
		MonstersPool.Instance.PoolIsFull += delegate 
		{
			InitMonsters ();
		};
	}

	public int CurrentMonstersCount 
	{
		get{ return currMonstersCount; }
		set {
			if (currMonstersCount <= GameConstants.maxCountOfMonstersOnScene)
				{
					MonstersPool.Instance.GetMonsterFromPool();
				}
			currMonstersCount = value;				
			}
	}
	private int currMonstersCount = 0;

	public void InitGame ()
	{
		SceneManager.LoadScene("MainScene"); //Hardcode init/reload scene
	}

	public void InitMonsters ()
	{
		for (int i = 0; i < GameConstants.maxCountOfMonstersOnScene; i++)
		{
			MonstersPool.Instance.GetMonsterFromPool();
		}
	}

	public void InitMainChar ()
	{
		var mainCharObj = Instantiate (prefabWithMainChar);
		mainCharacter = mainCharObj.GetComponentInChildren<MainChar>();

		mainCharacter.Init(Vector3.zero, GameConstants.START_MAIN_CHAR_HP);

		if(MainCharInit != null)
			MainCharInit ();
	}

}
