using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WearponController : MonoBehaviour 
{
	public List <WearponBase> wearpons;
	public WearponBase currentWearpon;

	public int WearponID 
	{
		get{ return wearponCounter; }
		set 
		{
			if(wearponCounter >= wearpons.Count - 1)
				wearponCounter = 0;
			else  
				wearponCounter = value;
		}
	}
	private int wearponCounter = 0;

	public void SwitchWearpon ()
	{
		wearpons[WearponID].gameObject.SetActive(false);
		WearponID ++;
		wearpons [WearponID].gameObject.SetActive (true);

		currentWearpon = wearpons [WearponID];
	}

	public void Fire ()
	{
		currentWearpon.Fire ();
	}
		

	void Start ()
	{
		if(wearpons != null)
		{
			HideWearpons();
			currentWearpon = wearpons[0];
			currentWearpon.gameObject.SetActive (true);
		}
		else 
		{
			Debug.LogError ("Need to add wearpons!!");
		}
	}



	private void HideWearpons ()
	{
		foreach (var wp in wearpons)
			wp.gameObject.SetActive(false);
	}


}
