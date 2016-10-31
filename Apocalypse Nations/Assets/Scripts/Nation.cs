using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// initial author TylerD
/// </summary>
public class Nation : MonoBehaviour {

    #region fields
    public BoxCollider2D boundingArea;
    public enum NationStats { Population, Science, Military, Economy, Religion};
    public string nationName;
    int population;
    int science;
    int military;
    int economy;
    int religion;
    public bool inAlliance;
	public GameObject panel;
    #endregion

    #region Public Methods
    /// <summary>
    /// Sets the population of the Nation
    /// </summary>
    /// <param name="populationNumber"></param>
    public void SetNationPopulation(int populationNumber)
    {
        population = populationNumber;
    }

    /// <summary>
    /// Sets the Military of the nation
    /// </summary>
    /// <param name="militaryNumber"></param>
    public void SetNationMilitary(int militaryNumber)
    {
        military = militaryNumber;
    }

    /// <summary>
    /// Sets the Science of the nation
    /// </summary>
    /// <param name="scienceNumber"></param>
    public void SetNationScience(int scienceNumber)
    {
        science = scienceNumber;
    }

    /// <summary>
    /// Sets the Economy of the nation
    /// </summary>
    /// <param name="economyNumber"></param>
    public void SetNationEconomy(int economyNumber)
    {
        economy = economyNumber;
    }

    /// <summary>
    /// Sets the Military of the nation
    /// </summary>
    /// <param name="ReligionNumber"></param>
    public void SetNationReligion(int ReligionNumber)
    {
        religion = ReligionNumber;
    }



    #endregion
    #region Private Methods
    // Use this for initialization
    void Start () {
        inAlliance = false;
		panel.SetActive (false);

    }


    void OnMouseEnter ()
    {
        Debug.Log("Welcome to the the Country!!!");

        // will actually pop up the country stats
		panel.SetActive(true);

	}

    void OnMouseExit()
    {
        Debug.Log("Leaving the country!");
        // will actually destroy the popu-up
		panel.SetActive (false);
    }
    #endregion
}
