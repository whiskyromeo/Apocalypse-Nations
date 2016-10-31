﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Initial Author: TylerD
/// </summary>
public class WorldMap : MonoBehaviour {

    #region Fields
    public Nation[] Nations;
    BoxCollider2D[] NationBoraders;

    // this dictionary is set to give each nation a unique number to then search the other dictionaries
    public Dictionary<string, int> NationNumbers;
    
    // these dictionaries are set up for the Key to be the nation number in the 
    // nation numbers dictionary and the value is the value of the pop/sci/mili....ect
    public Dictionary<int, int> NationPopulations;
    public Dictionary<int, int> NationSciences;
    public Dictionary<int, int> NationMilitaries;
    public Dictionary<int, int> NationReligions;
    public Dictionary<int, int> NationEconomies;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the nation's population Numbers from the dictionary
    /// </summary>
    /// <param name="nationname">string of nation name</param>
    /// <returns></returns>
    public int GetNationPopulation(string nationname)
    {
        int nationNumber = NationNumbers[nationname];
        return NationPopulations[nationNumber];
    }

    /// <summary>
    /// Gets the nation's population Numbers from the dictionary
    /// </summary>
    /// <param name="nationNumber">Nation Number</param>
    /// <returns></returns>
    public int GetNationPopulation(int nationNumber)
    {
        return NationPopulations[nationNumber];
    }

    /// <summary>
    /// Gets the nation's Science numbers from the dictionary
    /// </summary>
    /// <param name="nationname">string of nation name</param>
    /// <returns></returns>
    public int GetNationScience(string nationname)
    {
        int nationNumber = NationNumbers[nationname];
        return NationSciences[nationNumber];
    }

    /// <summary>
    /// Gets the nation's population Numbers from the dictionary
    /// </summary>
    /// <param name="nationNumber">Nation Number</param>
    /// <returns></returns>
    public int GetNationScience(int nationNumber)
    {
        return NationSciences[nationNumber];
    }

    /// <summary>
    /// Gets the nation's Military Numbers from the dictionary
    /// </summary>
    /// <param name="nationname">string of nation name</param>
    /// <returns></returns>
    public int GetNationMilitary(string nationname)
    {
        int nationNumber = NationNumbers[nationname];
        return NationMilitaries[nationNumber];
    }

    /// <summary>
    ///  Gets the nation's Military Numbers from the dictionary
    /// </summary>
    /// <param name="nationNumber">Nation Number</param>
    /// <returns></returns>
    public int GetNationMilitary(int nationNumber)
    {
        return NationMilitaries[nationNumber];
    }

    /// <summary>
    /// Gets the nation's Religion Numbers from the dictionary
    /// </summary>
    /// <param name="nationname">string of nation name</param>
    /// <returns></returns>
    public int GetNationReligion(string nationname)
    {
        int nationNumber = NationNumbers[nationname];
        return NationReligions[nationNumber];
    }

    /// <summary>
    ///  Gets the nation's Religion Numbers from the dictionary
    /// </summary>
    /// <param name="nationNumber">Nation Number</param>
    /// <returns></returns>
    public int GetNationReligion(int nationNumber)
    {
        return NationReligions[nationNumber];
    }

    /// <summary>
    /// Gets the nation's Economy Numbers from the dictionary
    /// </summary>
    /// <param name="nationname">string of nation name</param>
    /// <returns></returns>
    public int GetNationEconomy(string nationname)
    {
        int nationNumber = NationNumbers[nationname];
        return NationEconomies[nationNumber];
    }

    /// <summary>
    /// Gets the nation's Economy Numbers from the dictionary
    /// </summary>
    /// <param name="nationNumber">Nation Number</param>
    /// <returns></returns>
    public int GetNationEconomy(int nationNumber)
    {
        return NationEconomies[nationNumber];
    }
    #endregion
    // Use this for initialization
    void Awake ()
    {
        NationBoraders = GetComponents<BoxCollider2D>();
        Nations = GetComponents<Nation>();

        // initial set up for nations dictionary
        for(int i = 0; i < Nations.Length; i++)
        {
            NationNumbers.Add(Nations[i].name, i);
        }


	}



    // Update is called once per frame
    void Update () {
	
	}
}