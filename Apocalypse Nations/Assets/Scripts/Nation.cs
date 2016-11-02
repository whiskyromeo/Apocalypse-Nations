using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// initial author TylerD
/// </summary>
public class Nation : MonoBehaviour {

    #region fields
    public PolygonCollider2D boundingArea;
    //public enum NationStats { Population, Science, Military, Economy, Religion};
    public string nationName;
    int population;
    int science;
    int military;
    int economy;
    int religion;
    public bool inAlliance;
    public GameObject pannel;
    #endregion

    #region Properties
    /// <summary>
    /// Gets and set the population Value
    /// </summary>
    public int Population
    {  get
        {
            return population;
        }

        set
        {
            population = value;
        }
    }
    /// <summary>
    /// Gets and set the Science Value
    /// </summary>
    public int Science
    {
        get
        {
            return science;
        }

        set
        {
            science = value;
        }
    }
    /// <summary>
    /// Gets and set the Military Value
    /// </summary>
    public int Military
    {
        get
        {
            return military;
        }

        set
        {
            military = value;
        }
    }
    /// <summary>
    /// Gets and set the Economy Value
    /// </summary>
    public int Economy
    {
        get
        {
            return economy;
        }

        set
        {
            economy = value;
        }
    }
    /// <summary>
    /// Gets and set the Religion Value
    /// </summary>
    public int Religion
    {
        get
        {
            return religion;
        }

        set
        {
            religion = value;
        }
    }
    #endregion



    #region Private Methods
    // Use this for initialization
    void Start () {
        inAlliance = false;
        //panel.SetActive (false);
        WorldMap worldMap = GetComponentInParent<WorldMap>();
        int nationNumber = worldMap.NationNumbers[nationName];
        Economy = worldMap.NationEconomies[nationNumber];
        Military = worldMap.NationMilitaries[nationNumber];
        Science = worldMap.NationSciences[nationNumber];
        Religion = worldMap.NationReligions[nationNumber];
        Population = worldMap.NationPopulations[nationNumber];

        Debug.Log(nationName + ": Economy: " + economy + "  Military: " + military + "  Science: " + science + "  Religion: " + religion + "  Population: " + population);


    }


    void OnMouseEnter ()
    {
        Debug.Log("Welcome to " + nationName + "!!!");
        Debug.Log(nationName + ": Economy: " + economy + "  Military: " + military + "  Science: " + science + "  Religion: " + religion + "  Population: " + population);
        // will actually pop up the country stats
        //panel.SetActive(true);

    }

    void OnMouseExit()
    {
        Debug.Log("Leaving " + nationName + "!");
        // will actually destroy the popu-up
		//panel.SetActive (false);
    }
    #endregion
}
