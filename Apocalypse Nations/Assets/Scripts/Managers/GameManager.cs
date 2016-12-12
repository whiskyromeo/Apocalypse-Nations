using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
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
    public List<Alliance> players;

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

        players = new List<Alliance>();
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);
    }

    void Update()
    {
        if (gameState == GameStates.InGame)
        {
            switch(gamePlayState)
            {
			case GameplayStates.FirstPlayerTurn:
                    if (player1Alive && turnStarted)
                    {
                        activeAlliance = player1;
                        activeAllianceText.text = activeAlliance.name;
                        activeAllianceText.color = Color.red;
                        EventPanelHandler();
                        turnStarted = false;
                    }
                    else if (!player1Alive && turnStarted)
                    {
                        PlayerEndedTurn();
                    }

                    // lose condition
                    if (player1.population <= 0 && player1Alive && !player1.shownDead)
                    {
                        foreach (Nation nation in player1.AlliedNations)
                        {
                            nation.inAlliance = false;
                            player1.SetNationColor(nation, Color.white);
                            player1.AlliedNations.Remove(nation);
                            int nationNumber = worldMap.NationNumbers[nation.name];
                            nation.Science = worldMap.NationSciences[nationNumber];
                            nation.Military = worldMap.NationMilitaries[nationNumber];
                            nation.Economy = worldMap.NationEconomies[nationNumber];
                            nation.Population = worldMap.NationPopulations[nationNumber];
                            nation.Religion = worldMap.NationReligions[nationNumber];
                        }
                        playerLoseText.text = "Player 1 You Lose!";
                        OpenLosePanel();
                        player1Alive = false;
                        player1.shownDead = true;
                        PlayerEndedTurn();

                    }

                    // win condition
                    if (player1Alive && !player2Alive && !player3Alive && !player4Alive)
                    {
                        playerWinText.text = "Player 1 You Win!";
                        OpenWinPanel();
                    }
                    break;
			case GameplayStates.SecondPlayerTurn:
                    if (player2Alive && turnStarted)
                    {
                        activeAlliance = player2;
                        activeAllianceText.text = activeAlliance.name;
                        activeAllianceText.color = Color.green;
                        EventPanelHandler();
                        turnStarted = false;
                    }
                    else if (!player2Alive && turnStarted)
                    {
                        PlayerEndedTurn();
                    }

                    // lose condition
                    if (player2.population <= 0 && player2Alive && !player2.shownDead)
                    {                        
                        foreach (Nation nation in player2.AlliedNations)
                        {
                            nation.inAlliance = false;
                            player2.SetNationColor(nation, Color.white);
                            player2.AlliedNations.Remove(nation);

                        }
                        playerLoseText.text = "Player 2 You Lose!";
                        OpenLosePanel();
                        player2Alive = false;
                        player2.shownDead = true;
                        PlayerEndedTurn();
                    }

                    // win condition
                    if (!player1Alive && player2Alive && !player3Alive && !player4Alive)
                    {
                        playerWinText.text = "Player 2 You Win!";
                        OpenWinPanel();
                        turnStarted = false;
                    }
                    break;
			case GameplayStates.ThirdPlayerTurn:
                    if (player3Alive && turnStarted)
                    {
                        activeAlliance = player3;
                        activeAllianceText.text = activeAlliance.name;
                        activeAllianceText.color = Color.yellow;
                        EventPanelHandler();
                        turnStarted = false;
                    }
                    else if (!player3Alive && turnStarted)
                    {
                        PlayerEndedTurn();
                    }

                    // lose condition
                    if (player3.population <= 0 && player3Alive && !player3.shownDead)
                    {

                        
                        foreach (Nation nation in player3.AlliedNations)
                        {
                            nation.inAlliance = false;
                            player3.SetNationColor(nation, Color.white);
                            player3.AlliedNations.Remove(nation);

                        }
                        playerLoseText.text = "Player 3 You Lose!";
                        OpenLosePanel();
                        player3Alive = false;
                        player3.shownDead = true;
                        PlayerEndedTurn();

                    }

                    // win condition
                    if (!player1Alive && !player2Alive && player3Alive && !player4Alive)
                    {
                        playerWinText.text = "Player 3 You Win!";
                        OpenWinPanel();
                        turnStarted = false;
                    }
                    break;
			case GameplayStates.FourthPlayerTurn:
                    if (player4Alive && turnStarted)
                    {
                        activeAlliance = player4;
                        activeAllianceText.text = activeAlliance.name;
                        activeAllianceText.color = Color.magenta;
                        EventPanelHandler();
                        turnStarted = false;
                    }
                    else if (!player4Alive && turnStarted)
                    {
                        PlayerEndedTurn();
                    }

                    // lose condition
                    if (player4.population <= 0 && player4Alive && !player4.shownDead)
                    {
                        
                        foreach (Nation nation in player4.AlliedNations)
                        {
                            nation.inAlliance = false;
                            player4.SetNationColor(nation, Color.white);
                            player4.AlliedNations.Remove(nation);
                        }
                        playerLoseText.text = "Player 4 You Lose!";
                        OpenLosePanel();
                        player4Alive = false;
                        player4.shownDead = true;
                        PlayerEndedTurn();

                    }

                    // win condition
                    if (!player1Alive && !player2Alive && !player3Alive && player4Alive)
                    {
                        playerWinText.text = "Player 4 You Win!";
                        OpenWinPanel();
                        turnStarted = false;
                    }
                    break;
                case GameplayStates.Apocolypse:
                    // this will be used for the apocolypse turn or refresher
                    totalTurns++;
                    if (eventPanelScript.apoclypseType != EventPanel.ApoclypseTypes.None)
                    {
                        int random = Random.Range(0, 10);
                        if (random >= 8)
                        {
                            eventPanelScript.StartEvent(eventPanelScript.apoclypseType);
                        }
                        eventPanelScript.EventEffect(eventPanelScript.eventType);
                        eventPanelScript.ApocolypseTurnEffect(eventPanelScript.apoclypseType);
                    }
                    else if (totalTurns <= 1 && eventPanelScript.apoclypseType == EventPanel.ApoclypseTypes.None)
                    {
                        float rand = Random.Range(0f, 10f);
                        if (rand >= 7)
                        {
                            eventPanelScript.StartApocolypse();
                        }
                        if (rand <= 4)
                        {
                            eventPanelScript.StartEvent(eventPanelScript.apoclypseType);
                        }

                    }
                    else if (totalTurns >= 2 && totalTurns < 3 && eventPanelScript.apoclypseType == EventPanel.ApoclypseTypes.None)
                    {
                        float rand = Random.Range(0f, 10f);
                        if (rand >= 2)
                        {
                            eventPanelScript.StartApocolypse();
                        }

                    }
                    else if (totalTurns >= 5 && eventPanelScript.apoclypseType == EventPanel.ApoclypseTypes.None)
                    {
                        float rand = Random.Range(0f, 20f);
                        if (rand >= 13)
                        {
                            eventPanelScript.StartApocolypse();
                        }
                        else if (rand <=5)
                        {
                            eventPanelScript.StartEvent(eventPanelScript.apoclypseType);
                        }

                    }
                    gamePlayState = GameplayStates.FirstPlayerTurn;
                    turnStarted = true;
                    break;
                default:
                    Debug.Log("switching nations is fucked up");
                    gamePlayState = GameplayStates.FirstPlayerTurn;
                    break;
            }

            if(activeAllianceActionCount >= maxActionCount)
            {
                PlayerEndedTurn();
            }
            
            //if (Input.GetKey(KeyCode.W)) {
            //    //go to win scene
            //    SceneManager.LoadScene("WinScene");
            //}
            //if (Input.GetKey(KeyCode.L)) {
            //    //go to lose scene
            //    SceneManager.LoadScene("LoseScene");
            //}
            if (Input.GetKeyUp(KeyCode.E))
            {
                PlayerEndedTurn();
            }
            Debug.Log(players.Count + "players");
        }
    }
    #endregion
    #region Public Methods
    public void PlayerEndedTurn()
    {
        if (gamePlayState == GameplayStates.FirstPlayerTurn)
        {
            gamePlayState = GameplayStates.SecondPlayerTurn;
        }
        else if (gamePlayState == GameplayStates.SecondPlayerTurn)
        {
            gamePlayState = GameplayStates.ThirdPlayerTurn;
        }
        else if (gamePlayState == GameplayStates.ThirdPlayerTurn)
        {
            gamePlayState = GameplayStates.FourthPlayerTurn;
        }
        else if (gamePlayState == GameplayStates.FourthPlayerTurn)
        {
            gamePlayState = GameplayStates.Apocolypse;
        }
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
        if (turnStarted && activeAlliance.currentApoclypseType != EventPanel.ApoclypseTypes.None)
        {
                switch (eventPanelScript.apoclypseType)
                { // add famine
                    case EventPanel.ApoclypseTypes.Angels:
                    if (activeAlliance.currentEventType == EventPanel.EventTypes.None)
                    {
                        if (activeAlliance.apocolypseDurration > 1)
                        {
                            int rand = Random.Range(0, 1);
                            if (rand == 0)
                            {
                               eventPanelScript.titleText.text = ApocalypseConstants.ANGELS_APOCALYPSE_STRING;
                               eventPanelScript.bodyText.text = ApocalypseConstants.ANGELS_MAIN_TEXT1;
                               eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_1_TEXT;
                            }
                            else if (rand == 1)
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.ANGELS_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.ANGELS_MAIN_TEXT0;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_1_TEXT;
                            }
                        }

                        else
                        {
                            int rand = Random.Range(0, 1);
                            if (rand == 0)
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.ANGELS_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.ANGELS_INTRO_TEXT0;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_1_TEXT;
                            }
                            else
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.ANGELS_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.ANGELS_INTRO_TEXT1;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_1_TEXT;
                            }
                        }
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.AngelsHellfire)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.ANGELS_HELLFIRE_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.ANGELS_HELLFIRE_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_HELLFIRE_SOLVE_TEXT;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = "";
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.AngelsMinions)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.ANGELS_MINIONS_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.ANGELS_MINIONS_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_MINIONS_SOLVE_TEXT;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = "";
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.AngelsPlague)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_PLAGUE_SOLVE_TEXT;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = "";
                    }
                        break;
                    case EventPanel.ApoclypseTypes.Famine:
                    if (activeAlliance.currentEventType == EventPanel.EventTypes.None)
                    {
                        if (activeAlliance.apocolypseDurration > 1)
                        {
                            int rand = Random.Range(0, 1);
                            if (rand == 0)
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.FAMINE_MAIN_TEXT1;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_1_TEXT;
                            }
                            else if (rand == 1)
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.FAMINE_MAIN_TEXT0;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                            }
                        }

                        else
                        {
                            int rand = Random.Range(0, 1);
                            if (rand == 0)
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.FAMINE_INTRO_TEXT0;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                            }
                            else
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.FAMINE_INTRO_TEXT1;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                            }
                        }
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.FamineBreakthrough)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_BREAKTHROUGH_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.FAMINE_BREAKTHROUGH_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_BREAKTHROUGH_SOLVE_TEXT;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = "";
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.FamineEvolution)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_EVOLUTION_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.FAMINE_EVOLUTION_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_EVOLUTION_SOLVE_TEXT0;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_EVOLUTION_SOLVE_TEXT1;
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.FamineMutation)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_MUTATION_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.FAMINE_MUTATION_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_MUTATION_SOLVE_TEXT1;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = "";
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.FaminePlague)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_PLAGUE_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.FAMINE_PLAGUE_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_PLAGUE_SOLVE_TEXT0;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_PLAGUE_SOLVE_TEXT1;
                    }

                    break;
                    case EventPanel.ApoclypseTypes.Zombies:
                    if (activeAlliance.currentEventType == EventPanel.EventTypes.None)
                    {
                        if (activeAlliance.apocolypseDurration > 1)
                        {
                            int rand = Random.Range(0, 1);
                            if (rand == 0)
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.ZOMBIES_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.ZOMBIES_INTRO_TEXT0;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_1_TEXT;
                            }
                            else if (rand == 1)
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.ZOMBIES_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.ZOMBIES_INTRO_TEXT0;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_1_TEXT;
                            }
                        }

                        else
                        {
                            int rand = Random.Range(0, 1);
                            if (rand == 0)
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.ZOMBIES_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.ZOMBIES_INTRO_TEXT0;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_1_TEXT;
                            }
                            else
                            {
                                eventPanelScript.titleText.text = ApocalypseConstants.ZOMBIES_APOCALYPSE_STRING;
                                eventPanelScript.bodyText.text = ApocalypseConstants.ZOMBIES_INTRO_TEXT1;
                                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_0_TEXT;
                                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_1_TEXT;
                            }
                        }
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.ZombiesEvolutioin)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.ZOMBIES_EVOLUTION_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.ZOMBIES_EVOLUTION_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_EVOLUTION_SOLVE_TEXT;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = "";
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.ZombiesHord)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT0;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT1;
                    }
                    else if (activeAlliance.currentEventType == EventPanel.EventTypes.ZombiesMutation)
                    {
                        eventPanelScript.titleText.text = ApocalypseConstants.ZOMBIES_MUTATION_EVENT_STRING;
                        eventPanelScript.bodyText.text = ApocalypseConstants.ZOMBIES_MUTATION_EVENT_TEXT;
                        eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_MUTATION_SOLVE_TEXT;
                        eventPanelScript.button1.GetComponentInChildren<Text>().text = "";
                    }
                    break;
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
