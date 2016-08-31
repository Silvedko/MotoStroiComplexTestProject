using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FirstSceneControlelr : MonoBehaviour 
{
	public void LoadGameScene ()
	{
		SceneManager.LoadScene (1);
	}
}
