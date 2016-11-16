using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelPopUp : MonoBehaviour 
{
	public GameObject panel;

	void Start ()
	{
		panel.SetActive (false);
	}

	public void OpenPanel ()
	{
		panel.SetActive (true);
	}

	public void ClosePanel ()
	{
		panel.SetActive (false);
	}
}
