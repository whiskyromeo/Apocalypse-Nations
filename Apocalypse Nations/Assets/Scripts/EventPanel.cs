using UnityEngine;
using System.Collections;

public class EventPanel : MonoBehaviour 
{
	public GameManager gameManager;

	// Use this for initialization
	void Start () 
	{
		gameManager = FindObjectOfType<GameManager> ();
	}

	public void Close () 
	{
		gameManager.CloseEventPanel ();
		gameObject.SetActive (false);
	}
}
