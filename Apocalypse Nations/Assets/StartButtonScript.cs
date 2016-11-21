using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
		Debug.Log ("starting game...");

		//load the UI test scene
		Application.LoadLevel("UITestScene");
	}
}
