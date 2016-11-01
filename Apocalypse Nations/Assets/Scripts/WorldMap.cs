using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Initial Author: TylerD
/// </summary>
public class WorldMap : MonoBehaviour {

    #region Fields
    public Nation[] Nations;

    // this dictionary is set to give each nation a unique number to then search the other dictionaries
    public Dictionary<string, int> NationNumbers;
    public Dictionary<int, Nation> NationClasses;
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
    /// Gets the nation Class from dictionary
    /// </summary>
    /// <param name="NationNumber">number from dictionary</param>
    /// <returns></returns>
    public Nation GetNation(int nationnumber)
    {
        return NationClasses[nationnumber];
    }

    /// <summary>
    /// Gets the NationClass from dictioinary
    /// </summary>
    /// <param name="nationname">string of nation name in constants folder</param>
    /// <returns></returns>
    public Nation GetNation(string nationname)
    {
        int nationNumber = NationNumbers[nationname];
        return NationClasses[nationNumber];
    }
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

    #region PrivateMethods
    // Use this for initialization
    void Awake ()
    {
        Nations = new Nation[22];
        NationNumbers = new Dictionary<string, int>();
        NationClasses = new Dictionary<int, Nation>();
        NationPopulations = new Dictionary<int, int>();
        NationSciences = new Dictionary<int, int>();
        NationMilitaries = new Dictionary<int, int>();
        NationReligions = new Dictionary<int, int>();
        NationEconomies = new Dictionary<int, int>();
        Nations = GetComponentsInChildren<Nation>();

        //Debug.Log(Nations.Length);
        #region Dictionary Set UP
        // initial set up for nation numbers dictionary
        for(int i = 0; i < Nations.Length; i++)
        {
            NationNumbers.Add(Nations[i].nationName, i);
            NationClasses.Add(i, Nations[i]);
        }

        //Debug.Log("usa nation number: " + NationNumbers["USA"]);

        // initial set up of populations dictionary
        NationPopulations.Add(0, Constants.AGRENTINA_POPULATION_VALUE);
        NationPopulations.Add(1, Constants.BALTIC_NATIONS_POPULATION_VALUE);
        NationPopulations.Add(2, Constants.BRAZIL_POPULATION_VALUE);
        NationPopulations.Add(3, Constants.CANADA_POPULATION_VALUE);
        NationPopulations.Add(4, Constants.CENTRAL_AFRICA_POPULATION_VALUE);
        NationPopulations.Add(5, Constants.CHINA_POPULATION_VALUE);
        NationPopulations.Add(6, Constants.EGYPT_POPULATION_VALUE);
        NationPopulations.Add(7, Constants.FRANCE_POPULATION_VALUE);
        NationPopulations.Add(8, Constants.GERMANY_POPULATION_VALUE);
        NationPopulations.Add(9, Constants.INDIA_POPULATION_VALUE);
        NationPopulations.Add(10, Constants.INDONESIA_POPULATION_VALUE);
        NationPopulations.Add(11, Constants.ITALY_POPULATION_VALUE);
        NationPopulations.Add(12, Constants.JAPAN_POPULATION_VALUE);
        NationPopulations.Add(13, Constants.MIDDLE_EAST_POPULATION_VALUE);
        NationPopulations.Add(14, Constants.MEXICO_POPULATION_VALUE);
        NationPopulations.Add(15, Constants.NORTH_KOREA_POPULATION_VALUE);
        NationPopulations.Add(16, Constants.POLAND_POPULATION_VALUE);
        NationPopulations.Add(17, Constants.RUSSIA_POPULATION_VALUE);
        NationPopulations.Add(18, Constants.SOUTH_AFRICA_POPULATION_VALUE);
        NationPopulations.Add(19, Constants.SOUTH_KOREA_POPULATION_VALUE);
        NationPopulations.Add(20, Constants.UNITED_KINGDOM_POPULATION_VALUE);
        NationPopulations.Add(21, Constants.USA_POPULATION_VALUE);

        // initial set up of Science dictionary
        NationSciences.Add(0, Constants.AGRENTINA_SCIENCE_VALUE);
        NationSciences.Add(1, Constants.BALTIC_NATIONS_SCIENCE_VALUE);
        NationSciences.Add(2, Constants.BRAZIL_SCIENCE_VALUE);
        NationSciences.Add(3, Constants.CANADA_SCIENCE_VALUE);
        NationSciences.Add(4, Constants.CENTRAL_AFRICA_SCIENCE_VALUE);
        NationSciences.Add(5, Constants.CHINA_SCIENCE_VALUE);
        NationSciences.Add(6, Constants.EGYPT_SCIENCE_VALUE);
        NationSciences.Add(7, Constants.FRANCE_SCIENCE_VALUE);
        NationSciences.Add(8, Constants.GERMANY_SCIENCE_VALUE);
        NationSciences.Add(9, Constants.INDIA_SCIENCE_VALUE);
        NationSciences.Add(10, Constants.INDONESIA_SCIENCE_VALUE);
        NationSciences.Add(11, Constants.ITALY_SCIENCE_VALUE);
        NationSciences.Add(12, Constants.JAPAN_SCIENCE_VALUE);
        NationSciences.Add(13, Constants.MIDDLE_EAST_SCIENCE_VALUE);
        NationSciences.Add(14, Constants.MEXICO_SCIENCE_VALUE);
        NationSciences.Add(15, Constants.NORTH_KOREA_SCIENCE_VALUE);
        NationSciences.Add(16, Constants.POLAND_SCIENCE_VALUE);
        NationSciences.Add(17, Constants.RUSSIA_SCIENCE_VALUE);
        NationSciences.Add(18, Constants.SOUTH_AFRICA_SCIENCE_VALUE);
        NationSciences.Add(19, Constants.SOUTH_KOREA_SCIENCE_VALUE);
        NationSciences.Add(20, Constants.UNITED_KINGDOM_SCIENCE_VALUE);
        NationSciences.Add(21, Constants.USA_SCIENCE_VALUE);

        // initial set up of military dictionary
        NationMilitaries.Add(0, Constants.AGRENTINA_MILITARY_VALUE);
        NationMilitaries.Add(1, Constants.BALTIC_NATIONS_MILITARY_VALUE);
        NationMilitaries.Add(2, Constants.BRAZIL_MILITARY_VALUE);
        NationMilitaries.Add(3, Constants.CANADA_MILITARY_VALUE);
        NationMilitaries.Add(4, Constants.CENTRAL_AFRICA_MILITARY_VALUE);
        NationMilitaries.Add(5, Constants.CHINA_MILITARY_VALUE);
        NationMilitaries.Add(6, Constants.EGYPT_MILITARY_VALUE);
        NationMilitaries.Add(7, Constants.FRANCE_MILITARY_VALUE);
        NationMilitaries.Add(8, Constants.GERMANY_MILITARY_VALUE);
        NationMilitaries.Add(9, Constants.INDIA_MILITARY_VALUE);
        NationMilitaries.Add(10, Constants.INDONESIA_MILITARY_VALUE);
        NationMilitaries.Add(11, Constants.ITALY_MILITARY_VALUE);
        NationMilitaries.Add(12, Constants.JAPAN_MILITARY_VALUE);
        NationMilitaries.Add(13, Constants.MIDDLE_EAST_MILITARY_VALUE);
        NationMilitaries.Add(14, Constants.MEXICO_MILITARY_VALUE);
        NationMilitaries.Add(15, Constants.NORTH_KOREA_MILITARY_VALUE);
        NationMilitaries.Add(16, Constants.POLAND_MILITARY_VALUE);
        NationMilitaries.Add(17, Constants.RUSSIA_MILITARY_VALUE);
        NationMilitaries.Add(18, Constants.SOUTH_AFRICA_MILITARY_VALUE);
        NationMilitaries.Add(19, Constants.SOUTH_KOREA_MILITARY_VALUE);
        NationMilitaries.Add(20, Constants.UNITED_KINGDOM_MILITARY_VALUE);
        NationMilitaries.Add(21, Constants.USA_MILITARY_VALUE);


        // initial set up of Religion dictionary
        NationReligions.Add(0, Constants.AGRENTINA_RELIGION_VALUE);
        NationReligions.Add(1, Constants.BALTIC_NATIONS_RELIGION_VALUE);
        NationReligions.Add(2, Constants.BRAZIL_RELIGION_VALUE);
        NationReligions.Add(3, Constants.CANADA_RELIGION_VALUE);
        NationReligions.Add(4, Constants.CENTRAL_AFRICA_RELIGION_VALUE);
        NationReligions.Add(5, Constants.CHINA_RELIGION_VALUE);
        NationReligions.Add(6, Constants.EGYPT_RELIGION_VALUE);
        NationReligions.Add(7, Constants.FRANCE_RELIGION_VALUE);
        NationReligions.Add(8, Constants.GERMANY_RELIGION_VALUE);
        NationReligions.Add(9, Constants.INDIA_RELIGION_VALUE);
        NationReligions.Add(10, Constants.INDONESIA_RELIGION_VALUE);
        NationReligions.Add(11, Constants.ITALY_RELIGION_VALUE);
        NationReligions.Add(12, Constants.JAPAN_RELIGION_VALUE);
        NationReligions.Add(13, Constants.MIDDLE_EAST_RELIGION_VALUE);
        NationReligions.Add(14, Constants.MEXICO_RELIGION_VALUE);
        NationReligions.Add(15, Constants.NORTH_KOREA_RELIGION_VALUE);
        NationReligions.Add(16, Constants.POLAND_RELIGION_VALUE);
        NationReligions.Add(17, Constants.RUSSIA_RELIGION_VALUE);
        NationReligions.Add(18, Constants.SOUTH_AFRICA_RELIGION_VALUE);
        NationReligions.Add(19, Constants.SOUTH_KOREA_RELIGION_VALUE);
        NationReligions.Add(20, Constants.UNITED_KINGDOM_RELIGION_VALUE);
        NationReligions.Add(21, Constants.USA_RELIGION_VALUE);


        // initial set up of Economy dictionary
        NationEconomies.Add(0, Constants.AGRENTINA_ECONOMY_VALUE);
        NationEconomies.Add(1, Constants.BALTIC_NATIONS_ECONOMY_VALUE);
        NationEconomies.Add(2, Constants.BRAZIL_ECONOMY_VALUE);
        NationEconomies.Add(3, Constants.CANADA_ECONOMY_VALUE);
        NationEconomies.Add(4, Constants.CENTRAL_AFRICA_ECONOMY_VALUE);
        NationEconomies.Add(5, Constants.CHINA_ECONOMY_VALUE);
        NationEconomies.Add(6, Constants.EGYPT_ECONOMY_VALUE);
        NationEconomies.Add(7, Constants.FRANCE_ECONOMY_VALUE);
        NationEconomies.Add(8, Constants.GERMANY_ECONOMY_VALUE);
        NationEconomies.Add(9, Constants.INDIA_ECONOMY_VALUE);
        NationEconomies.Add(10, Constants.INDONESIA_ECONOMY_VALUE);
        NationEconomies.Add(11, Constants.ITALY_ECONOMY_VALUE);
        NationEconomies.Add(12, Constants.JAPAN_ECONOMY_VALUE);
        NationEconomies.Add(13, Constants.MIDDLE_EAST_ECONOMY_VALUE);
        NationEconomies.Add(14, Constants.MEXICO_ECONOMY_VALUE);
        NationEconomies.Add(15, Constants.NORTH_KOREA_ECONOMY_VALUE);
        NationEconomies.Add(16, Constants.POLAND_ECONOMY_VALUE);
        NationEconomies.Add(17, Constants.RUSSIA_ECONOMY_VALUE);
        NationEconomies.Add(18, Constants.SOUTH_AFRICA_ECONOMY_VALUE);
        NationEconomies.Add(19, Constants.SOUTH_KOREA_ECONOMY_VALUE);
        NationEconomies.Add(20, Constants.UNITED_KINGDOM_ECONOMY_VALUE);
        NationEconomies.Add(21, Constants.USA_ECONOMY_VALUE);

        #endregion
    }



    // Update is called once per frame
    void Update () {
	
	}
    #endregion
}
