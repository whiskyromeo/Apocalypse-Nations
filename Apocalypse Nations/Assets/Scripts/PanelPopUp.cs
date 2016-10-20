using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelPopUp : MonoBehaviour 
{
	public GameObject panel;
	public Text text;

	void Start ()
	{
		panel.SetActive (false);
		text.text = "Sample Text";
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
