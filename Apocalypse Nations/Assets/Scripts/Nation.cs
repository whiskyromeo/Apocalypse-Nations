using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public GameObject panel;
    #endregion

    // Use this for initialization
    void Start () {
        inAlliance = false;
<<<<<<< HEAD
=======
		panel.SetActive (false);
>>>>>>> d0b9b232e10ddc23e7800ebd0588c62d614c0b07
    }

    #region Private Methods
    void OnMouseEnter ()
    {
        Debug.Log("Welcome to the the Country!!!");
<<<<<<< HEAD
        // will actually pop up the country stats	
=======
        // will actually pop up the country stats
		panel.SetActive(true);
>>>>>>> d0b9b232e10ddc23e7800ebd0588c62d614c0b07
	}

    void OnMouseExit()
    {
        Debug.Log("Leaving the country!");
        // will actually destroy the popu-up
		panel.SetActive (false);
    }
    #endregion
}
