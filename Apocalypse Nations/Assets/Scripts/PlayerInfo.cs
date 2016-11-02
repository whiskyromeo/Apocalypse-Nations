using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour 
{
	//public Alliance alliance;
	public Nation nation;
	public Text playerInfoText;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerInfoText.text = "Population: " + nation.Population + "\nMilitary: " + nation.Military +
			"\nScience: " + nation.Science + "\nReligion: " + nation.Religion + "\nEconomy: " + nation.Economy;
	}
}
