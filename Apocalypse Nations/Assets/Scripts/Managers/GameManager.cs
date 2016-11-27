using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// initial author : Tyler
public class GameManager : MonoBehaviour {

    #region Fields
    static GameStates gameState;
    static MenuStates menuState;
    static GameplayStates gamePlayState;

    public enum AllianceStats { Population, Military, Science, Religion, Economy };
    public enum GameStates {MainMenu, InGame, Pause };
    public enum MenuStates { TitlePage, MainMenu, OptionsMenu};
    public enum GameplayStates {FirstPlayerTurn, SecondPlayerTurn, ThirdPlayerTurn, FourthPlayerTurn, None};
    int totalTurns; // this will be used to track how many actions the players have commited

    public Alliance player1, player2, player3, player4, activeAlliance;

    public Text activeAllianceText;

    public PlayerActionsPanel[] actionPanels;


    public int activeAllianceActionCount = 0;
    [SerializeField]
    public int maxActionCount = 2;

	public int CurrentNationNumber { get; set; }

    public WorldMap worldMap;

	// bool for the event panel
	bool isOpen = true;
	bool turnStarted = true;
	public GameObject eventPanelObject;
	public EventPanel eventPanelScript;
	public Canvas canvas;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the CurrentMenuState
    /// </summary>
    /// <returns></returns>
    public MenuStates GetCurrentMenuState()
    { return menuState; }

    /// <summary>
    /// sets the menu state to a new state
    /// </summary>
    /// <param name="newMenuState"></param>
    public void SetMenuState(MenuStates newMenuState)
    {
        menuState = newMenuState;
    }

    /// <summary>
    /// gets the current game state
    /// </summary>
    /// <returns></returns>
    public GameStates GetCurrentGameState()
    { return gameState; }

    /// <summary>
    /// sets the game state to a new game state
    /// </summary>
    /// <param name="newGameState"></param>
    public void SetGameState(GameStates newGameState)
    {
        gameState = newGameState;
    }
    #endregion

    #region Private Methods
    // Update is called once per frame
    void Awake () {
        gameState = GameStates.InGame;
        menuState = MenuStates.TitlePage;
        gamePlayState = GameplayStates.FirstPlayerTurn;
        activeAlliance = player1;
        totalTurns = 0;
        activeAllianceText.text = activeAlliance.name;


    }

    void Start() {

        actionPanels = FindObjectsOfType<PlayerActionsPanel>();

		// instantiate and position the event panel
		eventPanelScript = eventPanelObject.GetComponent<EventPanel> ();
		eventPanelScript = EventPanel.Instantiate (eventPanelScript);
		eventPanelScript.transform.SetParent (canvas.transform);
		eventPanelScript.gameObject.SetActive (false);
		Vector3 eventPanelPosition = new Vector3(800, 150, 10);
		eventPanelScript.GetComponent<RectTransform>().position = eventPanelPosition;
    }

    void Update()
    {
        if (gameState == GameStates.InGame)
        {
            switch(gamePlayState)
            {
				case GameplayStates.FirstPlayerTurn:
					activeAlliance = player1;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.red;
					EventPanelHandler ();
                    break;
				case GameplayStates.SecondPlayerTurn:
					activeAlliance = player2;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.green;
					EventPanelHandler ();
                    break;
				case GameplayStates.ThirdPlayerTurn:
					activeAlliance = player3;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.yellow;
					EventPanelHandler ();
                    break;
				case GameplayStates.FourthPlayerTurn:
					activeAlliance = player4;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.magenta;
					EventPanelHandler ();
                    break;
                case GameplayStates.None:
                    // this will be used for the apocolypse turn or refresher
                    totalTurns++;
                    // right now it will just go to the next state which is FirstPlayerTurn
                    gamePlayState = GameplayStates.FirstPlayerTurn;
                    break;
                default:
                    Debug.Log("switching nations is fucked up");
                    activeAlliance = player1;
                    break;
            }
            if(activeAllianceActionCount>= maxActionCount)
            {
                PlayerEndedTurn();
            }


            if (Input.GetKey(KeyCode.W)) {
                //go to win scene
                SceneManager.LoadScene("WinScene");
            }
            if (Input.GetKey(KeyCode.L)) {
                //go to lose scene
                SceneManager.LoadScene("LoseScene");
            }
        }
    }
    #endregion
    #region Public Methods
    public void PlayerEndedTurn()
    {
        gamePlayState++;
        activeAllianceText.text = activeAlliance.name;
        activeAllianceActionCount = 0;
		turnStarted = true;
    }

    /// <summary>
    /// this is the method that would be called in order to trigger an apocalypse
    /// </summary>
    /// <param name="timeTilApoc"></param>
    public void ApocalypseCheck(int timeTilApoc) {
        if (totalTurns / 4 == timeTilApoc) {
            //trigger apocalpyse
        }
    }

	public void AttackNation()
	{
		activeAlliance.AttackAlliance (CurrentNationNumber);
        activeAllianceActionCount++;
        worldMap.NationClasses[CurrentNationNumber].playerActionsPanel.gameObject.SetActive(false);
        worldMap.NationClasses[CurrentNationNumber].LeaveOpen = false;
        worldMap.NationClasses[CurrentNationNumber].nationInfoPanel.gameObject.SetActive(false);
    }

	public void AddNation ()
	{
		activeAlliance.addNationToAlliance (CurrentNationNumber);
        activeAllianceActionCount++;
        worldMap.NationClasses[CurrentNationNumber].playerActionsPanel.gameObject.SetActive(false);
        worldMap.NationClasses[CurrentNationNumber].LeaveOpen = false;
        worldMap.NationClasses[CurrentNationNumber].nationInfoPanel.gameObject.SetActive(false);
    }

    public void ClosePanels()
    {
        worldMap.NationClasses[CurrentNationNumber].playerActionsPanel.gameObject.SetActive(false);
        worldMap.NationClasses[CurrentNationNumber].LeaveOpen = false;
        worldMap.NationClasses[CurrentNationNumber].nationInfoPanel.gameObject.SetActive(false);
    }

    // A method to subtract a value from a given stat in a given alliance
    public void SubtractFromAllianceStat(Alliance alliance, AllianceStats stat, int value)
    {
        switch (stat)
        {
            case AllianceStats.Economy:
                alliance.economy -= value;
                break;
            case AllianceStats.Military:
                alliance.military -= value;
                break;
            case AllianceStats.Population:
                alliance.population -= value;
                break;
            case AllianceStats.Religion:
                alliance.religion -= value;
                break;
            case AllianceStats.Science:
                alliance.science -= value;
                break;
        }
    }

	public void EventPanelHandler()
	{
		if (turnStarted)
		{
			eventPanelScript.gameObject.SetActive(true);
		}
	}

	public void CloseEventPanel ()
	{
		turnStarted = false;
		eventPanelScript.gameObject.SetActive(false);
	}

    #endregion

}
