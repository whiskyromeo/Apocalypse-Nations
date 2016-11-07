﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour 
{
	//public Alliance alliance;
	public Nation nation;
	public Text playerInfoText;
    public GameObject allianceObj;
    Alliance alliance;
	// Use this for initialization
	void Start () 
	{
        SetPanelInfo();	
	}
	
	// Update is called once per frame
	void Update () 
	{
        SetPanelInfo();
        playerInfoText.text = "Population: " + alliance.population + "\nMilitary: " + alliance.military +
			"\nScience: " + alliance.science + "\nReligion: " + alliance.religion + "\nEconomy: " + alliance.economy;
	}

    void SetPanelInfo() {
        alliance = GameObject.FindObjectOfType<GameManager>().activeAlliance.GetComponent<Alliance>();

    }
}
