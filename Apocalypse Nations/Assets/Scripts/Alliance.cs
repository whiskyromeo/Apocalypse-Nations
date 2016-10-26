using UnityEngine;
using System.Collections;

public class Alliance : MonoBehaviour {

    public Nation[] AlliedNations;
    public WorldMap worldMap;
    public string AllianceName;
    int population;
    int military;
    int science;
    int religion;
    int economy;

    /// <summary>
    /// Adds a nation to the alliance
    /// </summary>
    /// <param name="nationname">string nation name</param>
    void addNationToAlliance(string nationname)
    {
        int nationNumber = worldMap.NationNumbers[nationname];
        if (!worldMap.Nations[nationNumber].inAlliance)
        {
            population += worldMap.NationPopulations[nationNumber];
            military += worldMap.NationMilitaries[nationNumber];
            science += worldMap.NationSciences[nationNumber];
            religion += worldMap.NationReligions[nationNumber];
            economy += worldMap.NationEconomies[nationNumber];
            worldMap.Nations[nationNumber].inAlliance = true;
        }
    }

    void AttackAlliance(string allianceName)
    {

    }
        // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
