using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

	public void OnMouseDown()
	{
		Application.LoadLevel (1);
	}

	public void QuitButton()
	{
		Application.Quit ();
	}

}
