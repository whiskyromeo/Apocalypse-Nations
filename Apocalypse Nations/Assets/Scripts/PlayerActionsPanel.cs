using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerActionsPanel : MonoBehaviour 
{
	public GameManager gameManager;

	// Use this for initialization
	public void Start () 
	{
		gameManager = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
    public void attackNation()
    {
        gameManager.AttackNation();
        gameObject.SetActive(false);
    }
    public void addNation()
    {
        gameManager.AddNation();
        gameObject.SetActive(false);
    }
    public void Close()
    {
        gameManager.ClosePanels();
        gameObject.SetActive(false);
    }
		
}
