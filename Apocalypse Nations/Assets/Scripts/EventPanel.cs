﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EventPanel : MonoBehaviour 
{
	public GameManager gameManager;
    public Text titleText, bodyText;
    public string mainText, introText;
    public Button button0, button1, button2;
    public enum AllianceStats { Population, Military, Science, Religion, Economy };
    public enum ApoclypseTypes { Famine};
    public ApoclypseTypes apoclypseType;
    public List<Alliance> affectedAlliances = new List<Alliance>();

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void StartApocolypse()
    {
        Start();
        int rand = Random.Range(0, 1);  
        switch (rand)
        {
            case 0:

                titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.FAMINE_INTRO_TEXT0;
                introText = ApocalypseConstants.FAMINE_INTRO_TEXT0;
                mainText = ApocalypseConstants.FAMINE_MAIN_TEXT0;
                button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
                button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                apoclypseType = ApoclypseTypes.Famine;
                break;
            case 1:
                titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.FAMINE_INTRO_TEXT1;
                introText = ApocalypseConstants.FAMINE_INTRO_TEXT1;
                mainText = ApocalypseConstants.FAMINE_MAIN_TEXT1;
                button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
                button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                apoclypseType = ApoclypseTypes.Famine;
                break;
        }
        button2.GetComponentInChildren<Text>().text = "Ignore";
        affectedAlliances.Add(gameManager.player1);
        affectedAlliances.Add(gameManager.player2);
        affectedAlliances.Add(gameManager.player3);
        affectedAlliances.Add(gameManager.player4);
    }
    public void ApocolypseTurnEffect(ApoclypseTypes apoclypsetype)
    {
        foreach (Alliance alliance in affectedAlliances)
        {

            if (apoclypsetype == ApoclypseTypes.Famine)
            {
                SubtractFromAllianceStat(alliance, AllianceStats.Population, ApocalypseConstants.FAMINE_POPULATION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^2));
                SubtractFromAllianceStat(alliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_ECONOMY_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                SubtractFromAllianceStat(alliance, AllianceStats.Science, ApocalypseConstants.FAMINE_SCIENCE_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                alliance.updateAllianceStats();
            }
            alliance.apocolypseDurration++;
        }
    }
    public void ApocolypseSolution1()
    {
        if (apoclypseType == ApoclypseTypes.Famine)
        {
            if (gameManager.activeAlliance.economy >= ApocalypseConstants.FAMINE_ECONOMY_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.FAMINE_SCIENCE_SOLVE)
            {
                SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_ECONOMY_SOLVE);
                SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.FAMINE_SCIENCE_SOLVE);
                gameManager.activeAlliance.updateAllianceStats();
                gameManager.activeAlliance.activeApoclypse = null;
                gameManager.activeAllianceActionCount++;
                CureApoclypse();
                Close();

            }
            else
            {
                bodyText.text = "You do not have the Resources";
            }
        }
    }
    public void ApocolypseSolution2()
    {
        if (apoclypseType == ApoclypseTypes.Famine)
        {
            if (gameManager.activeAlliance.military >= ApocalypseConstants.FAMINE_MILITARY_SOLVE)
            {
                SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.FAMINE_MILITARY_SOLVE);
                gameManager.activeAlliance.updateAllianceStats();
                gameManager.activeAllianceActionCount++;
                CureApoclypse();
                Close();

            }
            else
            {
                bodyText.text = "You do not have the Resources";
            }
        }
    }

    public void CureApoclypse()
    {
        if (gameManager.activeAlliance == gameManager.player1)
        {
            affectedAlliances.Remove(gameManager.player1);
        }
        else if (gameManager.activeAlliance == gameManager.player2)
        {
            affectedAlliances.Remove(gameManager.player2);
        }
        else if (gameManager.activeAlliance == gameManager.player3)
        {
            affectedAlliances.Remove(gameManager.player3);
        }
        else if (gameManager.activeAlliance == gameManager.player4)
        {
            affectedAlliances.Remove(gameManager.player4);
        }
        gameManager.activeAlliance.activeApoclypse = null;
        gameManager.activeAlliance.apocolypseActive = false;
        gameManager.activeAlliance.apocolypseDurration = 0;
    }
    // A method to subtract a value from a given stat in a given alliance
    public void SubtractFromAllianceStat(Alliance alliance, AllianceStats stat, int value)
    {
        switch (stat)
        {
            case AllianceStats.Economy:
                alliance.economy -= value;
                break;
            case AllianceStats.Military:
                alliance.military -= value;
                break;
            case AllianceStats.Population:
                alliance.population -= value;
                break;
            case AllianceStats.Religion:
                alliance.religion -= value;
                break;
            case AllianceStats.Science:
                alliance.science -= value;
                break;
        }
    }

    public void Close()
    {
        gameManager.CloseEventPanel();
    }

<<<<<<< HEAD
=======
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
>>>>>>> 355ea5ad4432d525216c8be7334d71d7db7dacb2
}