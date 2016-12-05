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
    public enum GameplayStates {FirstPlayerTurn, SecondPlayerTurn, ThirdPlayerTurn, FourthPlayerTurn, Apocolypse};
    public int totalTurns; // this will be used to track how many actions the players have commited

    public Alliance player1, player2, player3, player4, activeAlliance;
    public Alliance[] players;

    public Text activeAllianceText;

    public PlayerActionsPanel[] actionPanels;


    public int activeAllianceActionCount = 0;

    public int maxActionCount = 1;

	public int CurrentNationNumber { get; set; }

    public WorldMap worldMap;

	// bool for the event panel
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
		Vector3 eventPanelPosition = new Vector3(800, 250, 10);
		eventPanelScript.GetComponent<RectTransform>().position = eventPanelPosition;
        players = new Alliance[4];
        players[0] = player1;
        players[1] = player2;
        players[2] = player3;
        players[3] = player4;
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
                    turnStarted = false;
                    break;
				case GameplayStates.SecondPlayerTurn:
					activeAlliance = player2;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.green;
					EventPanelHandler ();
                    turnStarted = false;
                    break;
				case GameplayStates.ThirdPlayerTurn:
					activeAlliance = player3;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.yellow;
					EventPanelHandler ();
                    turnStarted = false;
                    break;
				case GameplayStates.FourthPlayerTurn:
					activeAlliance = player4;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.magenta;
					EventPanelHandler ();
                    turnStarted = false;
                    break;
                case GameplayStates.Apocolypse:
                    // this will be used for the apocolypse turn or refresher
                    totalTurns++;
                    if (activeAlliance.apocolypseActive)
                    {
                        eventPanelScript.ApocolypseTurnEffect(EventPanel.ApoclypseTypes.Famine);
                    }
                    else if (totalTurns <= 1 && eventPanelScript.apocAffectedAlliances.Count == 0)
                    {
                        float rand = Random.Range(0f, 10f);
                        if (rand >= 7)
                        {
                            eventPanelScript.StartApocolypse();
                            foreach (Alliance player in players)
                            {
                                player.apocolypseActive = true;
                            }
                        }

                    }
                    else if (totalTurns >= 2 && totalTurns < 3 && eventPanelScript.apocAffectedAlliances.Count == 0)
                    {
                        float rand = Random.Range(0f, 10f);
                        if (rand >= 4)
                        {
                            eventPanelScript.StartApocolypse();
                            foreach (Alliance player in players)
                            {
                                player.apocolypseActive = true;
                            }
                        }

                    }
                    else if (totalTurns >= 5 && eventPanelScript.apocAffectedAlliances.Count == 0)
                    {
                        float rand = Random.Range(0f, 10f);
                        if (rand >= 5)
                        {
                            eventPanelScript.StartApocolypse();
                            foreach (Alliance player in players)
                            {
                                player.apocolypseActive = true;
                            }
                        }

                    }
                    gamePlayState = GameplayStates.FirstPlayerTurn;
                    break;
                default:
                    Debug.Log("switching nations is fucked up");
                    gamePlayState = GameplayStates.FirstPlayerTurn;
                    break;
            }

            eventPanelScript.Update();
            if(activeAllianceActionCount >= maxActionCount)
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
            if (Input.GetKeyUp(KeyCode.E))
            {
                PlayerEndedTurn();
            }
            Debug.Log(activeAllianceActionCount);
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


    #region Player Action Panel Methods
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
    #endregion

    #region Event Panel Methods
   

    public void EventPanelHandler()
    {
        if (turnStarted && activeAlliance.apocolypseActive)
        {
            if (activeAlliance.apocolypseDurration >=1)
            {
                eventPanelScript.bodyText.text = eventPanelScript.mainText;
            }
            if (activeAlliance.apocolypseDurration == 1)
            {
                eventPanelScript.bodyText.text = eventPanelScript.introText;
            }
            eventPanelScript.gameObject.SetActive(true);

        }
    }

	public void CloseEventPanel ()
	{
		eventPanelScript.gameObject.SetActive(false);
	}
    #endregion
    #endregion

}
