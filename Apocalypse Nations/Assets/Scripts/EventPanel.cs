using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EventPanel : MonoBehaviour
{
    public GameManager gameManager;
    public Text titleText, bodyText;
    public string mainText, introText;
    public Button button0, button1, button2;
    public enum AllianceStats { Population, Military, Science, Religion, Economy };
    public enum ApoclypseTypes { Famine, Angels, Zombies, None };
    public enum EventTypes { FamineMutation, FaminePlague, FamineEvolution, FamineBreakthrough, ZombiesEvolutioin, ZombiesHord, ZombiesMutation, AngelsMinions, AngelsHellfire, AngelsPlague, AdverseWeather, Drought, None}
    public ApoclypseTypes apoclypseType = ApoclypseTypes.None;
    public EventTypes eventType = EventTypes.None;

    void Awake()
    {
        apoclypseType = ApoclypseTypes.None;
        eventType = EventTypes.None;
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

}

    #region Apocolypses
    public void StartApocolypse()
    {
        Start();
        int rand = Random.Range(0, 5);
        switch (rand)
        {
            case 0:

                titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.FAMINE_INTRO_TEXT0;
                introText = ApocalypseConstants.FAMINE_INTRO_TEXT0;
                mainText = ApocalypseConstants.FAMINE_MAIN_TEXT0;
				button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
				button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                foreach (Alliance player in gameManager.players)
                {
                    player.currentApoclypseType = ApoclypseTypes.Famine;
                }
                apoclypseType = ApoclypseTypes.Famine;
                break;
            case 1:
                titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.FAMINE_INTRO_TEXT1;
                introText = ApocalypseConstants.FAMINE_INTRO_TEXT1;
                mainText = ApocalypseConstants.FAMINE_MAIN_TEXT1;
				button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
				button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                foreach (Alliance player in gameManager.players)
                {
                    player.currentApoclypseType = ApoclypseTypes.Famine;
                }
                apoclypseType = ApoclypseTypes.Famine;
                break;
            case 2:
                titleText.text = ApocalypseConstants.ANGELS_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.ANGELS_INTRO_TEXT1;
                introText = ApocalypseConstants.ANGELS_INTRO_TEXT1;
                mainText = ApocalypseConstants.ANGELS_MAIN_TEXT1;
				button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_0_TEXT;
				button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_1_TEXT;
                foreach (Alliance player in gameManager.players)
                {
                    player.currentApoclypseType = ApoclypseTypes.Angels;
                }
                apoclypseType = ApoclypseTypes.Angels;
                break;
            case 3:
                titleText.text = ApocalypseConstants.ANGELS_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.ANGELS_INTRO_TEXT0;
                introText = ApocalypseConstants.ANGELS_INTRO_TEXT0;
                mainText = ApocalypseConstants.ANGELS_MAIN_TEXT0;
				button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_0_TEXT;
				button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_1_TEXT;
                foreach (Alliance player in gameManager.players)
                {
                    player.currentApoclypseType = ApoclypseTypes.Angels;
                }
                apoclypseType = ApoclypseTypes.Angels;
                break;
            case 4:
                titleText.text = ApocalypseConstants.ZOMBIES_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.ZOMBIES_INTRO_TEXT0;
                introText = ApocalypseConstants.ZOMBIES_INTRO_TEXT0;
                mainText = ApocalypseConstants.ZOMBIES_MAIN_TEXT0;
				button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_0_TEXT;
				button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_1_TEXT;
                foreach (Alliance player in gameManager.players)
                {
                    player.currentApoclypseType = ApoclypseTypes.Zombies;
                }
                apoclypseType = ApoclypseTypes.Zombies;
                break;
            case 5:
                titleText.text = ApocalypseConstants.ZOMBIES_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.ZOMBIES_INTRO_TEXT1;
                introText = ApocalypseConstants.ZOMBIES_INTRO_TEXT1;
                mainText = ApocalypseConstants.ZOMBIES_MAIN_TEXT1;
				button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_0_TEXT;
				button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_1_TEXT;
                foreach (Alliance player in gameManager.players)
                {
                    player.currentApoclypseType = ApoclypseTypes.Zombies;
                }
                apoclypseType = ApoclypseTypes.Zombies;
                break;
        }
        button2.GetComponentInChildren<Text>().text = "Ignore";
    }
    public void ApocolypseTurnEffect(ApoclypseTypes apoclypsetype)
    {
        foreach (Alliance alliance in gameManager.players)
        {
            if (alliance.currentApoclypseType != ApoclypseTypes.None)
            {

                if (apoclypsetype == ApoclypseTypes.Famine)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.FAMINE_POPULATION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Economy, (int)(ApocalypseConstants.FAMINE_ECONOMY_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 2)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Science, (int)(ApocalypseConstants.FAMINE_SCIENCE_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 2)));
                    alliance.updateAllianceStats();
                }
                else if (apoclypsetype == ApoclypseTypes.Angels)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.ANGELS_POPULATION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Military, (int)(ApocalypseConstants.ANGELS_MILITARY_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Religion, (int)(ApocalypseConstants.ANGELS_RELIGION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (apoclypsetype == ApoclypseTypes.Zombies)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.ZOMBIES_POPULATION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Military, (int)(ApocalypseConstants.ZOMBIES_MILITARY_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Religion, (int)(ApocalypseConstants.ZOMBIES_RELIGION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Economy, (int)(ApocalypseConstants.ZOMBIES_ECONOMY_REDUCTION * (gameManager.activeAlliance.apocolypseDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                alliance.apocolypseDurration++;
            }
        }
    }
    public void ApocolypseSolution1()
    {
        if (gameManager.activeAlliance.currentApoclypseType == ApoclypseTypes.None)
        {
            if (gameManager.activeAlliance.currentEventType == EventTypes.Drought)
            {
                if (gameManager.activeAlliance.economy >= ApocalypseConstants.DROUGHT_ECONOMY_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.DROUGHT_ECONOMY_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.AdverseWeather)
            {
                if (gameManager.activeAlliance.economy >= ApocalypseConstants.WEATHER_ECONOMY_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.WEATHER_ECONOMY_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
        }
        else if (gameManager.activeAlliance.currentApoclypseType == ApoclypseTypes.Famine)
        {
            if (gameManager.activeAlliance.currentEventType == EventTypes.None)
            {
                if (gameManager.activeAlliance.economy >= ApocalypseConstants.FAMINE_ECONOMY_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.FAMINE_SCIENCE_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_ECONOMY_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.FAMINE_SCIENCE_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureApoclypse();
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.FamineBreakthrough)
            {
                if (gameManager.activeAlliance.science >= ApocalypseConstants.FAMINE_BREAKTHROUGH_SCIENCE_INCREASE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_BREAKTHROUGH_SCIENCE_INCREASE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.FamineEvolution)
            {
                if (gameManager.activeAlliance.science >= ApocalypseConstants.FAMINE_EVOLUTION_SCIENCE_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.FAMINE_EVOLUTION_SCIENCE_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.FamineMutation)
            {
                if (gameManager.activeAlliance.science >= ApocalypseConstants.FAMINE_MUTATION_SCIENCE_SOLVE && gameManager.activeAlliance.economy >= ApocalypseConstants.FAMINE_MUTATION_ECONOMY_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.FAMINE_MUTATION_SCIENCE_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_MUTATION_ECONOMY_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.FaminePlague)
            {
                if (gameManager.activeAlliance.religion >= ApocalypseConstants.FAMINE_PLAGUE_RELIGION_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Religion, ApocalypseConstants.FAMINE_PLAGUE_RELIGION_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }


        }
        else if (gameManager.activeAlliance.currentApoclypseType == ApoclypseTypes.Angels)
        {
            if (gameManager.activeAlliance.currentEventType == EventTypes.None)
            {
                if (gameManager.activeAlliance.military >= ApocalypseConstants.ANGELS_MILITARY_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.ANGELS_SCIENCE_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.ANGELS_MILITARY_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.ANGELS_SCIENCE_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureApoclypse();
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.AngelsHellfire)
            {
                if (gameManager.activeAlliance.religion >= ApocalypseConstants.ANGELS_HELLFIRE_RELIGION_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Religion, ApocalypseConstants.ANGELS_HELLFIRE_RELIGION_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.AngelsMinions)
            {
                if (gameManager.activeAlliance.military >= ApocalypseConstants.ANGELS_MINIONS_MILITARY_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.ANGELS_MINIONS_MILITARY_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.AngelsPlague)
            {
                if (gameManager.activeAlliance.religion >= ApocalypseConstants.ANGELS_PLAGUE_RELIGION_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.ANGELS_PLAGUE_SCIENCE_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Religion, ApocalypseConstants.ANGELS_PLAGUE_RELIGION_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.ANGELS_PLAGUE_SCIENCE_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }

        }
        else if (gameManager.activeAlliance.currentApoclypseType == ApoclypseTypes.Zombies)
        {
            if (gameManager.activeAlliance.currentEventType == EventTypes.None)
            {
                if (gameManager.activeAlliance.economy >= ApocalypseConstants.ZOMBIES_ECONOMY_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.ZOMBIES_SCIENCE_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.ANGELS_MILITARY_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.ANGELS_SCIENCE_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureApoclypse();
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.ZombiesEvolutioin)
            {
                if (gameManager.activeAlliance.religion >= ApocalypseConstants.ZOMBIES_EVOLUTION_ECOMONY_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.ZOMBIES_EVOLUTION_ECOMONY_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.ZombiesHord)
            {
                if (gameManager.activeAlliance.military >= ApocalypseConstants.ZOMBIES_HORDE_MILITARY_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.ZOMBIES_HORDE_MILITARY_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.ZombiesMutation)
            {
                if (gameManager.activeAlliance.economy >= ApocalypseConstants.ZOMBIES_MUTATION_ECONOMY_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.ZOMBIES_MUTATION_SCIENCE_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.ZOMBIES_MUTATION_ECONOMY_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.ZOMBIES_MUTATION_SCIENCE_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
        }
        gameManager.activeAllianceActionCount++;
    }
    public void ApocolypseSolution2()
    {
        if (gameManager.activeAlliance.currentApoclypseType == ApoclypseTypes.Famine)
        {
            if (gameManager.activeAlliance.currentEventType == EventTypes.None)
            {
                if (gameManager.activeAlliance.military >= ApocalypseConstants.FAMINE_MILITARY_SOLVE && gameManager.activeAlliance.population >= ApocalypseConstants.FAMINE_POPULATION_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.FAMINE_MILITARY_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Population, ApocalypseConstants.FAMINE_POPULATION_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();

                    CureApoclypse();
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.FaminePlague)
            {
                if (gameManager.activeAlliance.military >= ApocalypseConstants.FAMINE_PLAGUE_MILITARY_SOLVE && gameManager.activeAlliance.economy >= ApocalypseConstants.FAMINE_PLAGUE_ECONOMY_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.FAMINE_PLAGUE_SCIENCE_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.FAMINE_PLAGUE_MILITARY_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_PLAGUE_ECONOMY_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.FAMINE_PLAGUE_SCIENCE_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.FamineEvolution)
            {
                if (gameManager.activeAlliance.military >= ApocalypseConstants.FAMINE_EVOLUTION_MILITARY_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.FAMINE_EVOLUTION_MILITARY_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }

        }
        else if (gameManager.activeAlliance.currentApoclypseType == ApoclypseTypes.Angels)
        {
            if (gameManager.activeAlliance.religion >= ApocalypseConstants.ANGELS_RELIGION_SOLVE)
            {
                SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Religion, ApocalypseConstants.ANGELS_RELIGION_SOLVE);
                gameManager.activeAlliance.updateAllianceStats();

                CureApoclypse();
                Close();

            }
            else
            {
                bodyText.text = "You do not have the Resources";
            }
        }
        else if (gameManager.activeAlliance.currentApoclypseType == ApoclypseTypes.Zombies)
        {
            if (gameManager.activeAlliance.currentEventType == EventTypes.None)
            {
                if (gameManager.activeAlliance.military >= ApocalypseConstants.ZOMBIES_MILITARY_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.ZOMBIES_MILITARY_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();

                    CureApoclypse();
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (gameManager.activeAlliance.currentEventType == EventTypes.ZombiesHord)
            {
                if (gameManager.activeAlliance.science >= ApocalypseConstants.ZOMBIES_HORDE_SCIENCE_SOLVE && gameManager.activeAlliance.economy >= ApocalypseConstants.ZOMBIES_HORDE_ECONOMY_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.ZOMBIES_HORDE_SCIENCE_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.ZOMBIES_HORDE_ECONOMY_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    CureEvent();
                    Close();
                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
        }
        gameManager.activeAllianceActionCount++;
    }

    public void CureApoclypse()
    {
        gameManager.activeAlliance.currentApoclypseType = ApoclypseTypes.None;
        gameManager.activeAlliance.apocolypseDurration = 0;
    }
    #endregion
    #region Events
    public void StartEvent(ApoclypseTypes currentApoclypse)
    {
        Start();
        if (currentApoclypse != ApoclypseTypes.None)
        {
            int random = Random.Range(7, 10);
            if (currentApoclypse == ApoclypseTypes.Famine)
            {
                switch (random)
                {
                    case 7:
                        titleText.text = ApocalypseConstants.FAMINE_MUTATION_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.FAMINE_MUTATION_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_MUTATION_SOLVE_TEXT1;
                        button1.GetComponentInChildren<Text>().text = "";
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Famine)
                            {
                                player.currentEventType = EventTypes.FamineMutation;
                            }
                        }
                        eventType = EventTypes.FamineMutation;
                        break;
                    case 8:
                        titleText.text = ApocalypseConstants.FAMINE_PLAGUE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.FAMINE_PLAGUE_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_PLAGUE_SOLVE_TEXT0;
						button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_PLAGUE_SOLVE_TEXT1;
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Famine)
                            {
                                player.currentEventType = EventTypes.FaminePlague;
                            }
                        }
                        eventType = EventTypes.FaminePlague;
                        break;
                    case 9:
                        titleText.text = ApocalypseConstants.FAMINE_EVOLUTION_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.FAMINE_EVOLUTION_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_EVOLUTION_SOLVE_TEXT0;
						button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_EVOLUTION_SOLVE_TEXT1;
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Famine)
                            {
                                player.currentEventType = EventTypes.FamineEvolution;
                            }
                        }
                        eventType = EventTypes.FamineEvolution;
                        break;
                    case 10:
                        titleText.text = ApocalypseConstants.FAMINE_BREAKTHROUGH_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.FAMINE_BREAKTHROUGH_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_BREAKTHROUGH_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().text = "";
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Famine)
                            {
                                player.currentEventType = EventTypes.FamineBreakthrough;
                            }
                        }
                        eventType = EventTypes.FamineBreakthrough;
                        break;
                }
            }
            else if(currentApoclypse == ApoclypseTypes.Angels)
            {
                switch (random)
                {
                    case 7:
                        titleText.text = ApocalypseConstants.ANGELS_MINIONS_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ANGELS_MINIONS_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_MINIONS_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().text = "";
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Angels)
                            {
                                player.currentEventType = EventTypes.AngelsMinions;
                            }
                        }
                        eventType = EventTypes.AngelsMinions;
                        break;
                    case 8:
                        titleText.text = ApocalypseConstants.ANGELS_HELLFIRE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ANGELS_HELLFIRE_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_HELLFIRE_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().text = "";
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Angels)
                            {
                                player.currentEventType = EventTypes.AngelsHellfire;
                            }
                        }
                        eventType = EventTypes.AngelsHellfire;
                        break;
                    case 9:
                        titleText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_PLAGUE_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().text = "";
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Angels)
                            {
                                player.currentEventType = EventTypes.AngelsPlague;
                            }
                        }
                        eventType = EventTypes.AngelsPlague;
                        break;
                    case 10:
                        titleText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_PLAGUE_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().text = "";
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Angels)
                            {
                                player.currentEventType = EventTypes.AngelsPlague;
                            }
                        }
                        eventType = EventTypes.AngelsPlague;
                        break;
                }
            }
            else if (currentApoclypse == ApoclypseTypes.Zombies)
            {
                switch (random)
                {
                    case 7:
                        titleText.text = ApocalypseConstants.ZOMBIES_EVOLUTION_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ZOMBIES_EVOLUTION_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_EVOLUTION_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().text = "";
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Zombies)
                            {
                                player.currentEventType = EventTypes.ZombiesEvolutioin;
                            }
                        }
                        eventType = EventTypes.ZombiesEvolutioin;
                        break;
                    case 8:
                        titleText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT0;
						button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT1;
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Zombies)
                            {
                                player.currentEventType = EventTypes.ZombiesHord;
                            }
                        }
                        eventType = EventTypes.ZombiesHord;
                        break;
                    case 9:
                        titleText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT0;
						button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT1;
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Zombies)
                            {
                                player.currentEventType = EventTypes.ZombiesHord;
                            }
                        }
                        eventType = EventTypes.ZombiesHord;
                        break;
                    case 10:
                        titleText.text = ApocalypseConstants.ZOMBIES_MUTATION_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ZOMBIES_MUTATION_EVENT_TEXT;
						button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_MUTATION_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().text = "";
                        foreach (Alliance player in gameManager.players)
                        {
                            if (player.currentApoclypseType == ApoclypseTypes.Zombies)
                            {
                                player.currentEventType = EventTypes.ZombiesMutation;
                            }
                        }
                        eventType = EventTypes.ZombiesMutation;
                        break;
                }
            }
        }
        else
        {
            int rand = Random.Range(0, 1);
            switch (rand)
            {
                case 0:

                    titleText.text = ApocalypseConstants.WEATHER_EVENT_STRING;
                    bodyText.text = ApocalypseConstants.WEATHER_EVENT_TEXT;
				button0.GetComponentInChildren<Text>().text = ApocalypseConstants.WEATHER_SOLVE_TEXT;
                    button1.GetComponentInChildren<Text>().text = "";
                    foreach (Alliance player in gameManager.players)
                    {
                        if (player.currentApoclypseType == ApoclypseTypes.None)
                        {
                            player.currentEventType = EventTypes.AdverseWeather;
                        }
                    }
                    eventType = EventTypes.AdverseWeather;
                    break;
                case 1:
                    titleText.text = ApocalypseConstants.DROUGHT_EVENT_STRING;
                    bodyText.text = ApocalypseConstants.DROUGHT_EVENT_TEXT;
				button0.GetComponentInChildren<Text>().text = ApocalypseConstants.DROUGHT_EVENT_SOLVE;
                    button1.GetComponentInChildren<Text>().text = "";
                    foreach (Alliance player in gameManager.players)
                    {
                        if (player.currentApoclypseType == ApoclypseTypes.Zombies)
                        {
                            player.currentEventType = EventTypes.Drought;
                        }
                    }
                    eventType = EventTypes.Drought;
                    break;
               
            }
        }
        
        button2.GetComponentInChildren<Text>().text = "Ignore";
    }

    public void CureEvent()
    {
        gameManager.activeAlliance.currentEventType = EventTypes.None;
        gameManager.activeAlliance.eventDurration = 0;

    }

    public void EventEffect(EventTypes eventtype)
    {
        foreach (Alliance alliance in gameManager.players)
        {
            if (alliance.currentEventType != EventTypes.None)
            {
                if (eventtype == EventTypes.AdverseWeather)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.WEATHER_POPULATION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.Drought)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.DROUGHT_POPULATION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.AngelsHellfire)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.ANGELS_HELLFIRE_POPULATION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.AngelsMinions)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.ANGELS_MINIONS_POPULATION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Religion, (int)(ApocalypseConstants.ANGELS_MINIONS_RELIGION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.AngelsPlague)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Military, (int)(ApocalypseConstants.ANGELS_PLAGUE_MILITARY_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.ANGELS_PLAGUE_POPULATION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.FamineBreakthrough)
                {

                }
                else if (eventtype == EventTypes.FamineEvolution)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.FAMINE_EVOLUTION_POPULATION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.FamineMutation)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Science, (int)(ApocalypseConstants.FAMINE_MUTATION_SCIENCE_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.FaminePlague)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.FAMINE_PLAGUE_POPULATION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Religion, (int)(ApocalypseConstants.FAMINE_PLAGUE_RELIGION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.ZombiesEvolutioin)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Science, (int)(ApocalypseConstants.ZOMBIES_EVOLUTION_SCIENCE_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.ZombiesHord)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Military, (int)(ApocalypseConstants.ZOMBIES_HORDE_MILITARY_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    SubtractFromAllianceStat(alliance, AllianceStats.Population, (int)(ApocalypseConstants.ZOMBIES_HORDE_POPULATION_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else if (eventtype == EventTypes.ZombiesMutation)
                {
                    SubtractFromAllianceStat(alliance, AllianceStats.Military, (int)(ApocalypseConstants.ZOMBIES_MUTATION_MILITARY_REDUCTION * (gameManager.activeAlliance.eventDurration * 0.5)));
                    alliance.updateAllianceStats();
                }
                else { }

                alliance.eventDurration++;
            }
        }
    }


    #endregion
    // A method to subtract a value from a given stat in a given alliance
    public void SubtractFromAllianceStat(Alliance alliance, AllianceStats stat, int value)
    {
        if (alliance.AlliedNations.Count > 0)
        {
            int splitValue = value / alliance.AlliedNations.Count;
            foreach (Nation nation in alliance.AlliedNations)
            {
                switch (stat)
                {
                    case AllianceStats.Economy:
                        nation.Economy -= splitValue;
                        break;
                    case AllianceStats.Military:
                        nation.Military -= splitValue;
                        break;
                    case AllianceStats.Population:
                        nation.Population -= splitValue;
                        break;
                    case AllianceStats.Religion:
                        nation.Religion -= splitValue;
                        break;
                    case AllianceStats.Science:
                        nation.Science -= splitValue;
                        break;
                        
                }
                nation.updateInfoPanel();
                
            }
            alliance.updateAllianceStats();
        }
    }

    public void Close()
    {

        gameManager.CloseEventPanel();
    }
    public void CheckForApocAndEvents(GameManager gamemanager)
    {
        if (gamemanager.player1.currentApoclypseType == ApoclypseTypes.None && gamemanager.player2.currentApoclypseType == ApoclypseTypes.None &&
            gamemanager.player3.currentApoclypseType == ApoclypseTypes.None && gamemanager.player4.currentApoclypseType == ApoclypseTypes.None)
        {
            apoclypseType = ApoclypseTypes.None;
        }

        if (gamemanager.player1.currentEventType == EventTypes.None && gamemanager.player2.currentEventType == EventTypes.None &&
            gamemanager.player3.currentEventType == EventTypes.None && gamemanager.player4.currentEventType == EventTypes.None)
        {
            eventType = EventTypes.None;
        }
    }
}
