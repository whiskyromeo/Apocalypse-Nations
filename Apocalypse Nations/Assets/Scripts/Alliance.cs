using UnityEngine;
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
    public EventPanel.ApoclypseTypes currentApoclypseType;
    public EventPanel.EventTypes currentEventType;
    public int apocolypseDurration = 0;
    public int eventDurration = 0;
    public bool shownDead;
    #endregion


    void Start()
    {
        AlliedNations = new List<Nation>();
        AddStartingNation();
        updateAllianceStats();
        SetColors();
        currentApoclypseType = EventPanel.ApoclypseTypes.None;
        currentEventType = EventPanel.EventTypes.None;
        shownDead = false;
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
            GameManager game = FindObjectOfType<GameManager>();
            if (game.player1.AlliedNations.Contains(attackedNation))
            {
                game.eventPanelScript.SubtractFromAllianceStat(game.player1, EventPanel.AllianceStats.Population, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player1, EventPanel.AllianceStats.Military, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player1, EventPanel.AllianceStats.Religion, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player1, EventPanel.AllianceStats.Science, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player1, EventPanel.AllianceStats.Economy, Constants.ATTACK_DAMAGE);
                game.player1.updateAllianceStats();
            }
            else if ((game.player2.AlliedNations.Contains(attackedNation)))
            {
                game.eventPanelScript.SubtractFromAllianceStat(game.player2, EventPanel.AllianceStats.Population, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player2, EventPanel.AllianceStats.Military, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player2, EventPanel.AllianceStats.Religion, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player2, EventPanel.AllianceStats.Science, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player2, EventPanel.AllianceStats.Economy, Constants.ATTACK_DAMAGE);
                game.player2.updateAllianceStats();
            }
            else if ((game.player3.AlliedNations.Contains(attackedNation)))
            {
                game.eventPanelScript.SubtractFromAllianceStat(game.player3, EventPanel.AllianceStats.Population, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player3, EventPanel.AllianceStats.Military, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player3, EventPanel.AllianceStats.Religion, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player3, EventPanel.AllianceStats.Science, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player3, EventPanel.AllianceStats.Economy, Constants.ATTACK_DAMAGE);
                game.player3.updateAllianceStats();
            }
            else if ((game.player4.AlliedNations.Contains(attackedNation)))
            {
                game.eventPanelScript.SubtractFromAllianceStat(game.player4, EventPanel.AllianceStats.Population, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player4, EventPanel.AllianceStats.Military, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player4, EventPanel.AllianceStats.Religion, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player4, EventPanel.AllianceStats.Science, Constants.ATTACK_DAMAGE);
                game.eventPanelScript.SubtractFromAllianceStat(game.player4, EventPanel.AllianceStats.Economy, Constants.ATTACK_DAMAGE);
                game.player4.updateAllianceStats();
            }

            int splitWinBonus = Constants.ATTACK_WIN_BONUS / AlliedNations.Count;
            foreach (Nation nation in AlliedNations)
            {
                nation.Population = (int)(nation.Population + (splitWinBonus));
                nation.Military = (int)(nation.Military + (splitWinBonus));
                nation.Religion = (int)(nation.Religion + (splitWinBonus));
                nation.Science = (int)(nation.Science + (splitWinBonus));
                nation.Economy = (int)(nation.Economy + (splitWinBonus));
                nation.updateInfoPanel();
            }
            updateAllianceStats();


        }
        else
        {
            /// failed attack
            Debug.Log("the attack has failed");
            GameManager game = FindObjectOfType<GameManager>();
            //GameObject.Find("GameManager").GetComponent<GameManager>().activeAllianceActionCount++; //this counts as an action
            if (game.player1.AlliedNations.Contains(attackedNation))
            {                
                int splitWinBonus = Constants.ATTACK_WIN_BONUS / game.player1.AlliedNations.Count;
                foreach (Nation nation in game.player1.AlliedNations)
                {
                    nation.Population =nation.Population + (splitWinBonus);
                    nation.Military = nation.Military + (splitWinBonus);
                    nation.Religion = nation.Religion + (splitWinBonus);
                    nation.Science = nation.Science + (splitWinBonus);
                    nation.Economy = nation.Economy + (splitWinBonus);
                    nation.updateInfoPanel();
                }
                game.player1.updateAllianceStats();
            }
            else if ((game.player2.AlliedNations.Contains(attackedNation)))
            {
                int splitWinBonus = Constants.ATTACK_WIN_BONUS / game.player2.AlliedNations.Count;
                foreach (Nation nation in game.player2.AlliedNations)
                {
                    nation.Population = nation.Population + (splitWinBonus);
                    nation.Military = nation.Military + (splitWinBonus);
                    nation.Religion = nation.Religion + (splitWinBonus);
                    nation.Science = nation.Science + (splitWinBonus);
                    nation.Economy = nation.Economy + (splitWinBonus);
                    nation.updateInfoPanel();
                }
                game.player2.updateAllianceStats();
            }
            else if ((game.player3.AlliedNations.Contains(attackedNation)))
            {
                int splitWinBonus = Constants.ATTACK_WIN_BONUS / game.player3.AlliedNations.Count;
                foreach (Nation nation in game.player3.AlliedNations)
                {
                    nation.Population = nation.Population + (splitWinBonus);
                    nation.Military = nation.Military + (splitWinBonus);
                    nation.Religion = nation.Religion + (splitWinBonus);
                    nation.Science = nation.Science + (splitWinBonus);
                    nation.Economy = nation.Economy + (splitWinBonus);
                    nation.updateInfoPanel();
                }
                game.player3.updateAllianceStats();
            }
            else if ((game.player4.AlliedNations.Contains(attackedNation)))
            {
                int splitWinBonus = Constants.ATTACK_WIN_BONUS / game.player4.AlliedNations.Count;
                foreach (Nation nation in game.player4.AlliedNations)
                {
                    nation.Population = nation.Population + (splitWinBonus);
                    nation.Military = nation.Military + (splitWinBonus);
                    nation.Religion = nation.Religion + (splitWinBonus);
                    nation.Science = nation.Science + (splitWinBonus);
                    nation.Economy = nation.Economy + (splitWinBonus);
                    nation.updateInfoPanel();
                }
                game.player4.updateAllianceStats();
            }

            int splitDamage = Constants.ATTACK_LOSS_DAMAGE / AlliedNations.Count;
            foreach (Nation nation in AlliedNations)
            {

                nation.Population = (int)(nation.Population - (splitDamage));
                nation.Military = (int)(nation.Military - (splitDamage));
                nation.Religion = (int)(nation.Religion - (splitDamage));
                nation.Science = (int)(nation.Science - (splitDamage));
                nation.Economy = (int)(nation.Economy - (splitDamage));
                nation.updateInfoPanel();
            }
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
            else
            {
                nation.GetComponent<SpriteRenderer>().color = Color.white;
            }

        }

    }

    public void SetNationColor(Nation nation, Color color)
    {
        nation.GetComponent<SpriteRenderer>().color = color;
    }

    #endregion
}

