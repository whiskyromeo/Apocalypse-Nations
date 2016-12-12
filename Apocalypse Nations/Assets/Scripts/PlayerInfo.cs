using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour 
{
	public Text playerInfoText;
	public Text title;
    public Alliance alliance;

	// Update is called once per frame
	void Update () 
	{
		playerInfoText.text = "Pop: " + alliance.population + "\t\tRel: " + alliance.religion + "\nSci: " + alliance.science +
			"\t\tEcn: " + alliance.economy + "\nMil: " + alliance.military;

		title.text = alliance.name + " Stats";
	}
}
