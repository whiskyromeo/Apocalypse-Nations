using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R)) {
            SceneManager.LoadScene("UITestScene");
            Debug.Log("fuck");
        }
	}

    /// <summary>
    /// goes to the next scene in the array
    /// </summary>
    public void ContinueButton() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
