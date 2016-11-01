﻿using UnityEngine;
using System.Collections;
// initial author : Tyler
public class GameManager {

    #region Fields
    static GameManager instance;
    static GameStates gameState;
    static MenuStates menuState;
    static GameplayStates gamePlayState;
    public enum GameStates {MainMenu, InGame, Pause };
    public enum MenuStates { TitlePage, MainMenu, OptionsMenu};
    public enum GameplayStates {FirstPlayerTurn, SecondPlayerTurn, ThirdPlayerTurn, FourthPlayerTurn, None};

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

    #region Constructor
    private GameManager()
    {

    }
    #endregion

    #region Private Methods
    // Update is called once per frame
    void Awake () {
        gameState = GameStates.MainMenu;
        menuState = MenuStates.TitlePage;
        gamePlayState = GameplayStates.None;
        
	
	}

    void Update()
    {
        if (gameState == GameStates.InGame)
        {
            switch(gamePlayState)
            {
                case GameplayStates.FirstPlayerTurn:
                    // update HUD for this player's alliance stats
                    // highlight players allied countries to the players color
                    break;
                case GameplayStates.SecondPlayerTurn:
                    // update HUD for this player's alliance stats
                    // highlight players allied countries to the players color
                    break;
                case GameplayStates.ThirdPlayerTurn:
                    // update HUD for this player's alliance stats
                    // highlight players allied countries to the players color
                    break;
                case GameplayStates.FourthPlayerTurn:
                    // update HUD for this player's alliance stats
                    // highlight players allied countries to the players color
                    break;
                case GameplayStates.None:
                    // this will be used for the apocolypse turn or refresher
                    
                    // right now it will just go to the next state which is FirstPlayerTurn
                    gamePlayState++;
                    break;
            }
        }
    }
    #endregion
    #region Public Methods
    public void PlayerEndedTurn()
    {
        gamePlayState++;
    }
    #endregion

}