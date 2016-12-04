using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour {

	public GameManager gameManager;

	// Use this for initialization
	void Start () 
	{
		gameManager = FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	public void GoToMainMenu () 
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void RestartGame ()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		gameManager.CloseWinPanel ();
	}
}
