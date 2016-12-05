﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Original Author TylerD
/// </summary>
public class Alliance : MonoBehaviour
{

    #region Fields
    public List<Nation> AlliedNations;
    public WorldMap worldMap;
    public string AllianceName;
    public int population;
    public int military;
    public int science;
    public int religion;
    public int economy;
    int balancingScale = 3;
    public Apoclypse activeApoclypse;
    public bool apocolypseActive = false;
    public int apocolypseDurration = 0;
    #endregion


    void Start()
    {
        AlliedNations = new List<Nation>();
        AddStartingNation();
        updateAllianceStats();
        SetColors();
    }

    #region Private Methods


    void AddStartingNation()
    {
        int rand = Random.Range(0, 22);
        bool test = addNationToAlliance(rand);
        if (!test)
        {
            AddStartingNation();
        }
    }
    /// <summary>
    /// only called by AttackAlliance() to balance the success rate of  attacking a nation
    /// </summary>
    /// <param name="attackedNationNumber">the nation number of the country being attacked</param>
    /// <returns></returns>
    int CalculateAttackDC(int attackedNationNumber)
    {
        // starts out with 50/50 shot of winning
        int standardAdvantage = 4;
        int militaryDifference = military - worldMap.GetNationMilitary(attackedNationNumber);
        int advantage = militaryDifference / balancingScale;

        // if advantage is a positive number it makes it easier to win the attack
        // if advantage is a negative number it makes it harder to win the attack
        int attackDC = standardAdvantage - advantage;

        // clamp attackCD into usable values
        if (attackDC > 6)
        {
            attackDC = 6;
        }
        if (attackDC < 0)
        {
            attackDC = 0;
        }
        return attackDC;
    }

    public void updateAllianceStats()
    {
        population = 0;
        science = 0;
        military = 0;
        economy = 0;
        religion = 0;
        foreach (Nation nation in AlliedNations)
        {
            
            int nationNumber = worldMap.NationNumbers[nation.nationName];
            population += worldMap.GetNation(nationNumber).Population;
            science += worldMap.GetNation(nationNumber).Science;
            military += worldMap.GetNation(nationNumber).Military;
            economy += worldMap.GetNation(nationNumber).Economy;
            religion += worldMap.GetNation(nationNumber).Religion;

        }
    }
    #endregion


    #region Public Methods
    /// <summary>
    /// Adds a nation to the alliance
    /// </summary>
    /// <param name="nationname">string nation name</param>
    public bool addNationToAlliance(string nationname)
    {
        // get the nation number of the nation you are adding
        int nationNumber = worldMap.NationNumbers[nationname];
        // check to see if this nation is in an alliance
        if (!worldMap.Nations[nationNumber].inAlliance)
        {
            // add new nation stats to your alliance
            population += worldMap.GetNationPopulation(nationNumber);
            military += worldMap.GetNationMilitary(nationNumber);
            science += worldMap.GetNationScience(nationNumber);
            religion += worldMap.GetNationReligion(nationNumber);
            economy += worldMap.GetNationEconomy(nationNumber);
            worldMap.Nations[nationNumber].inAlliance = true;
            AlliedNations.Add(worldMap.GetNation(nationNumber));
            SetColors();
            //GameObject.Find("GameManager").GetComponent<GameManager>().activeAllianceActionCount++; //this counts as an action
            return true;
        }
        else
        {
            Debug.Log("this country can't be added");
            return false;
        }
    }

    public bool addNationToAlliance(int nationnumber)
    {
        // check to see if this nation is in an alliance
        if (!worldMap.Nations[nationnumber].inAlliance)
        {
            // add new nation stats to your alliance
            population += worldMap.GetNationPopulation(nationnumber);
            military += worldMap.GetNationMilitary(nationnumber);
            science += worldMap.GetNationScience(nationnumber);
            religion += worldMap.GetNationReligion(nationnumber);
            economy += worldMap.GetNationEconomy(nationnumber);
            worldMap.Nations[nationnumber].inAlliance = true;
            AlliedNations.Add(worldMap.GetNation(nationnumber));
			SetColors ();
            //GameObject.Find("GameManager").GetComponent<GameManager>().activeAllianceActionCount++; //this counts as an action
            return true;
        }
        else
        {
            Debug.Log("this country can't be added");
            return false;
        }
    }


    public void AttackAlliance(int attackedNationNumber)
    {
        Nation attackedNation = worldMap.NationClasses[attackedNationNumber];
        int AttackDC = CalculateAttackDC(attackedNationNumber);
        int attack = Random.Range(1, 6);
        if (attack >= AttackDC)
        {
            /// attack hits
            Debug.Log("You Win the attack");
            attackedNation.Population = (int)(attackedNation.Population - (attackedNation.Population * .2));
            attackedNation.Military = (int)(attackedNation.Military - (attackedNation.Military * .2));
            attackedNation.Religion = (int)(attackedNation.Religion - (attackedNation.Religion * .2));
            attackedNation.Science = (int)(attackedNation.Science - (attackedNation.Science * .2));
            attackedNation.Economy = (int)(attackedNation.Economy - (attackedNation.Economy * .2));
            attackedNation.updateInfoPanel();
            GameManager game = FindObjectOfType<GameManager>();
            //GameObject.Find("GameManager").GetComponent<GameManager>().activeAllianceActionCount++; //this counts as an action
            if (game.player1.AlliedNations.Contains(attackedNation))
            {
                game.player1.updateAllianceStats();
            }
            else if ((game.player2.AlliedNations.Contains(attackedNation)))
            {
                game.player2.updateAllianceStats();
            }
            else if ((game.player3.AlliedNations.Contains(attackedNation)))
            {
                game.player3.updateAllianceStats();
            }
            else if ((game.player4.AlliedNations.Contains(attackedNation)))
            {
                game.player4.updateAllianceStats();
            }

            
            AlliedNations[0].Population = (int)(AlliedNations[0].Population + (AlliedNations[0].Population * .2));
            AlliedNations[0].Military = (int)(AlliedNations[0].Military + (AlliedNations[0].Military * .2));
            AlliedNations[0].Religion = (int)(AlliedNations[0].Religion + (AlliedNations[0].Religion * .2));
            AlliedNations[0].Science = (int)(AlliedNations[0].Science + (AlliedNations[0].Science * .2));
            AlliedNations[0].Economy = (int)(AlliedNations[0].Economy + (AlliedNations[0].Economy * .2));
            AlliedNations[0].updateInfoPanel();
            updateAllianceStats();


        }
        else
        {
            /// failed attack
            Debug.Log("the attack has failed");
            attackedNation.Population = (int)(attackedNation.Population + (attackedNation.Population * .2));
            attackedNation.Military = (int)(attackedNation.Military + (attackedNation.Military * .2));
            attackedNation.Religion = (int)(attackedNation.Religion + (attackedNation.Religion * .2));
            attackedNation.Science = (int)(attackedNation.Science + (attackedNation.Science * .2));
            attackedNation.Economy = (int)(attackedNation.Economy + (attackedNation.Economy * .2));
            attackedNation.updateInfoPanel();
            GameManager game = FindObjectOfType<GameManager>();
            //GameObject.Find("GameManager").GetComponent<GameManager>().activeAllianceActionCount++; //this counts as an action
            if (game.player1.AlliedNations.Contains(attackedNation))
            {
                game.player1.updateAllianceStats();
            }
            else if ((game.player2.AlliedNations.Contains(attackedNation)))
            {
                game.player2.updateAllianceStats();
            }
            else if ((game.player3.AlliedNations.Contains(attackedNation)))
            {
                game.player3.updateAllianceStats();
            }
            else if ((game.player4.AlliedNations.Contains(attackedNation)))
            {
                game.player4.updateAllianceStats();
            }
            AlliedNations[0].Population = (int)(AlliedNations[0].Population - (AlliedNations[0].Population * .2));
            AlliedNations[0].Military = (int)(AlliedNations[0].Military - (AlliedNations[0].Military * .2));
            AlliedNations[0].Religion = (int)(AlliedNations[0].Religion - (AlliedNations[0].Religion * .2));
            AlliedNations[0].Science = (int)(AlliedNations[0].Science - (AlliedNations[0].Science * .2));
            AlliedNations[0].Economy = (int)(AlliedNations[0].Economy - (AlliedNations[0].Economy * .2));
            AlliedNations[0].updateInfoPanel();
            updateAllianceStats();

        }
        

    }

    public void SetColors() {

        foreach (Nation nation in AlliedNations) {
            if (gameObject.name == "Player 1")
            {
                nation.GetComponent<SpriteRenderer>().color = Color.red;
            }  else if (gameObject.name == "Player 2")
            {
                nation.GetComponent<SpriteRenderer>().color = Color.green;
            } else if (gameObject.name == "Player 3")
            {
                nation.GetComponent<SpriteRenderer>().color = Color.yellow;
            } else if (gameObject.name == "Player 4")
                {
                    nation.GetComponent<SpriteRenderer>().color = Color.magenta;
                }

        }

    }

    #endregion
}

