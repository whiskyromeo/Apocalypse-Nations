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
		playerInfoText.text = "Pop:\t" + alliance.population + "\t\tRel:\t" + alliance.religion + "\nSci:\t" + alliance.science +
			"\t\tEcn:\t" + alliance.economy + "\nMil:\t" + alliance.military;

		title.text = alliance.name + " Stats";
	}
}
