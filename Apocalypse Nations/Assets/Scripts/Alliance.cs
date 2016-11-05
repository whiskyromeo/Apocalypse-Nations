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
    #endregion


    void Start()
    {
        AlliedNations = new List<Nation>();
        int rand = Random.Range(0, 22);
        Debug.Log(rand.ToString());
        addNationToAlliance(rand);
        updateAllianceStats();
    }

    #region Private Methods
    /// <summary>
    /// Adds a nation to the alliance
    /// </summary>
    /// <param name="nationname">string nation name</param>
    void addNationToAlliance(string nationname)
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
        }
        else
        {
            Debug.Log("this country can't be added");
        }
    }

    void addNationToAlliance(int nationnumber)
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
        }
        else
        {
            Debug.Log("this country can't be added");
        }
    }


    void AttackAlliance(int attackedNationNumber)
    {
        Nation attackedNation = worldMap.NationClasses[attackedNationNumber];
        int AttackDC = CalculateAttackDC(attackedNationNumber);
        int attack = Random.Range(1, 6);
        if (attack >= AttackDC)
        {
            /// attack hits
            Debug.Log("You Win the attack");
        }
        else
        {
            /// failed attack
            Debug.Log("the attack has failed");
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

    void updateAllianceStats()
    {
        population = 0;
        science = 0;
        military = 0;
        economy = 0;
        religion = 0;
        foreach (Nation nation in AlliedNations)
        {
            
            int nationNumber = worldMap.NationNumbers[nation.name];
            population += worldMap.GetNationPopulation(nationNumber);
            science += worldMap.GetNationScience(nationNumber);
            military += worldMap.GetNationMilitary(nationNumber);
            economy += worldMap.GetNationEconomy(nationNumber);
            religion += worldMap.GetNationReligion(nationNumber);

        }
    }
    #endregion
}
