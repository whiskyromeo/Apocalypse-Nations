using UnityEngine;
using System.Collections;

public class Nation : MonoBehaviour {

    #region fields
    public BoxCollider2D boundingArea;
    public string nationName;
    int population;
    int science;
    int military;
    int economy;
    int religion;
    public bool inAlliance;
    #endregion

    // Use this for initialization
    void Start () {
        inAlliance = false;

    }
    #region Private Methods
    // Update is called once per frame
    void OnMouseEnter () {
        Debug.Log("Welcome to the the Country!!!");
        // will actually pop up the country stats
	
	}


    void OnMouseExit()
    {
        Debug.Log("Leaving the country!");
        // will actually destroy the popu-up
    }
    #endregion
}
