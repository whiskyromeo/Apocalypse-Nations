using UnityEngine;
using System.Collections;
// initial author : Tyler
public class GameManager {

    #region Fields
    static GameManager instance;
    #endregion

    #region Properties
    /// <summary>
    /// Gets the singleton instance of the game manager
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }
    #endregion

    #region Constructor
    private GameManager()
    {

    }
    #endregion


    // Update is called once per frame
    void Update () {
	
	}
}
