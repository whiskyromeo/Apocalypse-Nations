using UnityEngine;
using System.Collections;

public class LosePanel : MonoBehaviour {

	public GameManager gameManager;

	// Use this for initialization
	void Start () 
	{
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	public void ClosePanel () 
	{
		gameManager.CloseLosePanel ();
	}
}
