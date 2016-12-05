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

	// Lose Panel
	public GameObject losePanelObject;
	public LosePanel losePanelScript;
	public Text playerLoseText;

	// Win Panel
	public GameObject winPanelObject;
	public WinPanel winPanelScript;
	public Text playerWinText;

	// player win/lose bools
	bool player1Alive = true;
	bool player2Alive = true;
	bool player3Alive = true;
	bool player4Alive = true;

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
    void Awake () 
	{
        gameState = GameStates.InGame;
        menuState = MenuStates.TitlePage;
        gamePlayState = GameplayStates.FirstPlayerTurn;
        activeAlliance = player1;
        totalTurns = 0;
        activeAllianceText.text = activeAlliance.name;
    }

    void Start() 
	{
        actionPanels = FindObjectsOfType<PlayerActionsPanel>();

		// instantiate and position the event panel
		eventPanelScript = eventPanelObject.GetComponent<EventPanel> ();
		eventPanelScript = EventPanel.Instantiate (eventPanelScript);
		eventPanelScript.transform.SetParent (canvas.transform);
		eventPanelScript.gameObject.SetActive (false);
		Vector3 eventPanelPosition = new Vector3 (800, 250, 10);
		eventPanelScript.GetComponent<RectTransform> ().position = eventPanelPosition;

		// instantiate and position the lose panel
		losePanelScript = losePanelObject.GetComponent<LosePanel> ();
		losePanelScript = LosePanel.Instantiate (losePanelScript);
		losePanelScript.transform.SetParent (canvas.transform);
		losePanelScript.gameObject.SetActive (false);
		Vector3 losePanelPosition = new Vector3 (800, 250, 10);
		losePanelScript.GetComponent<RectTransform> ().position = losePanelPosition;

		// instantiate and position the win panel
		winPanelScript = winPanelObject.GetComponent<WinPanel> ();
		winPanelScript = WinPanel.Instantiate (winPanelScript);
		winPanelScript.transform.SetParent (canvas.transform);
		winPanelScript.gameObject.SetActive (false);
		Vector3 winPanelPosition = new Vector3 (800, 250, 10);
		winPanelScript.GetComponent<RectTransform> ().position = winPanelPosition;

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
				if (player1Alive) 
				{
					activeAlliance = player1;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.red;
					EventPanelHandler ();
					turnStarted = false;
				}

				// lose condition
				if (player1.population <= 0 && player1Alive)
				{
					playerLoseText.text = "Player 1 You Lose!";
					OpenLosePanel ();
					player1Alive = false;
					PlayerEndedTurn ();
				}

				// win condition
				if (player1Alive && !player2Alive && !player3Alive && !player4Alive)
				{
					playerWinText.text = "Player 1 You Win!";
					OpenWinPanel ();
				}
                    break;
			case GameplayStates.SecondPlayerTurn:
				if (player2Alive) 
				{
					activeAlliance = player2;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.green;
					EventPanelHandler ();
					turnStarted = false;
				}

				// lose condition
				if (player2.population <= 0 && player2Alive)
				{
					playerLoseText.text = "Player 2 You Lose!";
					OpenLosePanel ();
					player2Alive = false;
					PlayerEndedTurn ();
				}

				// win condition
				if (!player1Alive && player2Alive && !player3Alive && !player4Alive)
				{
					playerWinText.text = "Player 2 You Win!";
					OpenWinPanel ();
				}
                    break;
			case GameplayStates.ThirdPlayerTurn:
				if (player3Alive) 
				{	
					activeAlliance = player3;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.yellow;
					EventPanelHandler ();
					turnStarted = false;
				}

				// lose condition
				if (player3.population <= 0 && player3Alive)
				{
					playerLoseText.text = "Player 3 You Lose!";
					OpenLosePanel ();
					player3Alive = false;
					PlayerEndedTurn ();
				}

				// win condition
				if (!player1Alive && !player2Alive && player3Alive && !player4Alive)
				{
					playerWinText.text = "Player 3 You Win!";
					OpenWinPanel ();
				}
                    break;
			case GameplayStates.FourthPlayerTurn:
				if (player4Alive) 
				{	
					activeAlliance = player4;
					activeAllianceText.text = activeAlliance.name;
					activeAllianceText.color = Color.magenta;
					EventPanelHandler ();
					turnStarted = false;
				}

				// lose condition
				if (player4.population <= 0 && player4Alive)
				{
					playerLoseText.text = "Player 4 You Lose!";
					OpenLosePanel ();
					player4Alive = false;
					PlayerEndedTurn ();
				}

				// win condition
				if (!player1Alive && !player2Alive && !player3Alive && player4Alive)
				{
					playerWinText.text = "Player 4 You Win!";
					OpenWinPanel ();
				}
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
            
        }
    }
    #endregion
    #region Public Methods
    public void PlayerEndedTurn()
    {
        gamePlayState++;
        activeAllianceText.text = activeAlliance.name;
        activeAllianceActionCount = 0;
        if (eventPanelScript.gameObject.activeSelf == true)
        {
            eventPanelScript.Close();
        }
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
                switch (eventPanelScript.apoclypseType)
                {
                    case EventPanel.ApoclypseTypes.Angels:
                        eventPanelScript.bodyText.text = ApocalypseConstants.ANGELS_MAIN_TEXT0;
                        break;
                    case EventPanel.ApoclypseTypes.Famine:
                        eventPanelScript.bodyText.text = ApocalypseConstants.FAMINE_MAIN_TEXT0;
                        break;
                    case EventPanel.ApoclypseTypes.Zombies:
                        eventPanelScript.bodyText.text = ApocalypseConstants.ZOMBIES_MAIN_TEXT0;
                        break;
                }
                eventPanelScript.bodyText.text = eventPanelScript.mainText;
            }
            eventPanelScript.gameObject.SetActive (true);

        }
    }

	public void CloseEventPanel ()
	{
		eventPanelScript.gameObject.SetActive (false);
	}

	public void OpenLosePanel ()
	{
		losePanelScript.gameObject.SetActive (true);
	}

	public void CloseLosePanel ()
	{
		losePanelScript.gameObject.SetActive (false);
	}

	public void OpenWinPanel ()
	{
		winPanelScript.gameObject.SetActive (true);
	}

	public void CloseWinPanel ()
	{
		winPanelScript.gameObject.SetActive (false);
	}

    #endregion
    #endregion

}
