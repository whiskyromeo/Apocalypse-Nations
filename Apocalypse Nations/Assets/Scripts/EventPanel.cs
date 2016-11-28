using UnityEngine;
using System.Collections;

public class EventPanel : MonoBehaviour 
{
	public GameManager gameManager;

	// Use this for initialization
	void Start () 
	{
		gameManager = FindObjectOfType<GameManager> ();
	}

	public void Close () 
	{
		gameManager.CloseEventPanel ();
		gameObject.SetActive (false);
	}

	public void StartApocalypse (string randomApocalypse, Random rand)
	{
		rand =  Random.Range(1.0, 3.0);

		if (rand >= 1.0 && rand < 2.0) 
		{
			randomApocalypse = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
		}

		if (rand >= 2.0 && rand < 3.0) 
		{
			randomApocalypse = ApocalypseConstants.WEATHER_EVENT_STRING;
		}

		if (rand == 3.0) 
		{
			randomApocalypse = ApocalypseConstants.DROUGHT_EVENT_STRING;
		}
	}

	public void ApocalypseEffect (int activePlayerAllianceEffected)
	{
		
	}
}
