using UnityEngine;
using System.Collections;
// initial author : Tyler
public class GameManager : MonoBehaviour {

    #region Fields
    static GameStates gameState;
    static MenuStates menuState;
    static GameplayStates gamePlayState;
    public enum GameStates {MainMenu, InGame, Pause };
    public enum MenuStates { TitlePage, MainMenu, OptionsMenu};
    public enum GameplayStates {FirstPlayerTurn, SecondPlayerTurn, ThirdPlayerTurn, FourthPlayerTurn, None};
    int totalTurns; // this will be used to track how many actions the players have commited

    public Alliance player1, player2, player3, player4, activeAlliance;

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

    }

    void Start() {
        

    }

    void Update()
    {
        if (gameState == GameStates.InGame)
        {
            switch(gamePlayState)
            {
                case GameplayStates.FirstPlayerTurn:
                    activeAlliance = player1;
                    break;
                case GameplayStates.SecondPlayerTurn:
                    activeAlliance = player2;
                    break;
                case GameplayStates.ThirdPlayerTurn:
                    activeAlliance = player3;
                    break;
                case GameplayStates.FourthPlayerTurn:
                    activeAlliance = player4;
                    break;
                case GameplayStates.None:
                    // this will be used for the apocolypse turn or refresher
                    totalTurns++;
                    // right now it will just go to the next state which is FirstPlayerTurn
                    gamePlayState++;
                    break;
                default:
                    Debug.Log("switching nations is fucked up");
                    activeAlliance = player1;
                    break;
            }
            if(Input.GetKeyDown(KeyCode.E))
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
    #endregion

}
