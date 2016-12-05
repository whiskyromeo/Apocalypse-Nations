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
    public ApoclypseTypes apoclypseType;
    public EventTypes eventType;
    public List<Alliance> apocAffectedAlliances = new List<Alliance>();
    public List<Alliance> eventAffectedAlliances = new List<Alliance>();

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        if(apocAffectedAlliances.Count == 0)
        {
            apoclypseType = ApoclypseTypes.None;
        }
        if(eventAffectedAlliances.Count == 0)
        {
            eventType = EventTypes.None;
        }
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
                apoclypseType = ApoclypseTypes.Famine;
                break;
            case 1:
                titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.FAMINE_INTRO_TEXT1;
                introText = ApocalypseConstants.FAMINE_INTRO_TEXT1;
                mainText = ApocalypseConstants.FAMINE_MAIN_TEXT1;
                button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
                button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                apoclypseType = ApoclypseTypes.Famine;
                break;
            case 2:
                titleText.text = ApocalypseConstants.ANGELS_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.ANGELS_INTRO_TEXT1;
                introText = ApocalypseConstants.ANGELS_INTRO_TEXT1;
                mainText = ApocalypseConstants.ANGELS_MAIN_TEXT1;
                button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_0_TEXT;
                button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_1_TEXT;
                apoclypseType = ApoclypseTypes.Angels;
                break;
            case 3:
                titleText.text = ApocalypseConstants.ANGELS_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.ANGELS_INTRO_TEXT0;
                introText = ApocalypseConstants.ANGELS_INTRO_TEXT0;
                mainText = ApocalypseConstants.ANGELS_MAIN_TEXT0;
                button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_0_TEXT;
                button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_SOLVE_BUTTON_1_TEXT;
                apoclypseType = ApoclypseTypes.Angels;
                break;
            case 4:
                titleText.text = ApocalypseConstants.ZOMBIES_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.ZOMBIES_INTRO_TEXT0;
                introText = ApocalypseConstants.ZOMBIES_INTRO_TEXT0;
                mainText = ApocalypseConstants.ZOMBIES_MAIN_TEXT0;
                button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_0_TEXT;
                button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_1_TEXT;
                apoclypseType = ApoclypseTypes.Zombies;
                break;
            case 5:
                titleText.text = ApocalypseConstants.ZOMBIES_APOCALYPSE_STRING;
                bodyText.text = ApocalypseConstants.ZOMBIES_INTRO_TEXT1;
                introText = ApocalypseConstants.ZOMBIES_INTRO_TEXT1;
                mainText = ApocalypseConstants.ZOMBIES_MAIN_TEXT1;
                button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_0_TEXT;
                button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_SOLVE_BUTTON_1_TEXT;
                apoclypseType = ApoclypseTypes.Zombies;
                break;
        }
        button2.GetComponentInChildren<Text>().text = "Ignore";
        apocAffectedAlliances.Add(gameManager.player1);
        apocAffectedAlliances.Add(gameManager.player2);
        apocAffectedAlliances.Add(gameManager.player3);
        apocAffectedAlliances.Add(gameManager.player4);
    }
    public void ApocolypseTurnEffect(ApoclypseTypes apoclypsetype)
    {
        foreach (Alliance alliance in apocAffectedAlliances)
        {

            if (apoclypsetype == ApoclypseTypes.Famine)
            {
                SubtractFromAllianceStat(alliance, AllianceStats.Population, ApocalypseConstants.FAMINE_POPULATION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                SubtractFromAllianceStat(alliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_ECONOMY_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                SubtractFromAllianceStat(alliance, AllianceStats.Science, ApocalypseConstants.FAMINE_SCIENCE_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                alliance.updateAllianceStats();
            }
            else if (apoclypsetype == ApoclypseTypes.Angels)
            {
                SubtractFromAllianceStat(alliance, AllianceStats.Population, ApocalypseConstants.ANGELS_POPULATION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                SubtractFromAllianceStat(alliance, AllianceStats.Military, ApocalypseConstants.ANGELS_MILITARY_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                SubtractFromAllianceStat(alliance, AllianceStats.Religion, ApocalypseConstants.ANGELS_RELIGION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                alliance.updateAllianceStats();
            }
            else if (apoclypsetype == ApoclypseTypes.Zombies)
            {
                SubtractFromAllianceStat(alliance, AllianceStats.Population, ApocalypseConstants.ZOMBIES_POPULATION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                SubtractFromAllianceStat(alliance, AllianceStats.Military, ApocalypseConstants.ZOMBIES_MILITARY_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                SubtractFromAllianceStat(alliance, AllianceStats.Religion, ApocalypseConstants.ZOMBIES_RELIGION_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                SubtractFromAllianceStat(alliance, AllianceStats.Economy, ApocalypseConstants.ZOMBIES_ECONOMY_REDUCTION * (gameManager.activeAlliance.apocolypseDurration ^ 2));
                alliance.updateAllianceStats();
            }
            alliance.apocolypseDurration++;
        }
    }
    public void ApocolypseSolution1()
    {
        if (apoclypseType == ApoclypseTypes.Famine)
        {
            if (eventType == EventTypes.None)
            {
                if (gameManager.activeAlliance.economy >= ApocalypseConstants.FAMINE_ECONOMY_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.FAMINE_SCIENCE_SOLVE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_ECONOMY_SOLVE);
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.FAMINE_SCIENCE_SOLVE);
                    gameManager.activeAlliance.updateAllianceStats();
                    gameManager.activeAlliance.activeApoclypse = null;
                    CureApoclypse();
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }
            else if (eventType == EventTypes.FamineBreakthrough)
            {
                if (gameManager.activeAlliance.science >= ApocalypseConstants.FAMINE_BREAKTHROUGH_SCIENCE_INCREASE)
                {
                    SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_BREAKTHROUGH_SCIENCE_INCREASE);
                    gameManager.activeAlliance.updateAllianceStats();
                    
                    Close();

                }
                else
                {
                    bodyText.text = "You do not have the Resources";
                }
            }

        }
        else if (apoclypseType == ApoclypseTypes.Angels)
        {
            if (gameManager.activeAlliance.military >= ApocalypseConstants.ANGELS_MILITARY_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.ANGELS_SCIENCE_SOLVE)
            {
                SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.ANGELS_MILITARY_SOLVE);
                SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.ANGELS_SCIENCE_SOLVE);
                gameManager.activeAlliance.updateAllianceStats();
                gameManager.activeAlliance.activeApoclypse = null;
                CureApoclypse();
                Close();

            }
            else
            {
                bodyText.text = "You do not have the Resources";
            }

        }
        else if (apoclypseType == ApoclypseTypes.Zombies)
        {
            if (gameManager.activeAlliance.economy >= ApocalypseConstants.ZOMBIES_ECONOMY_SOLVE && gameManager.activeAlliance.science >= ApocalypseConstants.ZOMBIES_SCIENCE_SOLVE)
            {
                SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Economy, ApocalypseConstants.ANGELS_MILITARY_SOLVE);
                SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Science, ApocalypseConstants.ANGELS_SCIENCE_SOLVE);
                gameManager.activeAlliance.updateAllianceStats();
                gameManager.activeAlliance.activeApoclypse = null;
                CureApoclypse();
                Close();

            }
            else
            {
                bodyText.text = "You do not have the Resources";
            }

        }

        gameManager.activeAllianceActionCount++;
    }
    public void ApocolypseSolution2()
    {
        if (apoclypseType == ApoclypseTypes.Famine)
        {
            if (gameManager.activeAlliance.military >= ApocalypseConstants.FAMINE_MILITARY_SOLVE)
            {
                SubtractFromAllianceStat(gameManager.activeAlliance, AllianceStats.Military, ApocalypseConstants.FAMINE_MILITARY_SOLVE);
                gameManager.activeAlliance.updateAllianceStats();

                CureApoclypse();
                Close();

            }
            else
            {
                bodyText.text = "You do not have the Resources";
            }
        }
        else if (apoclypseType == ApoclypseTypes.Angels)
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
        else if (apoclypseType == ApoclypseTypes.Zombies)
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
        gameManager.activeAllianceActionCount++;
    }

    public void CureApoclypse()
    {
        if (gameManager.activeAlliance == gameManager.player1)
        {
            apocAffectedAlliances.Remove(gameManager.player1);
        }
        else if (gameManager.activeAlliance == gameManager.player2)
        {
            apocAffectedAlliances.Remove(gameManager.player2);
        }
        else if (gameManager.activeAlliance == gameManager.player3)
        {
            apocAffectedAlliances.Remove(gameManager.player3);
        }
        else if (gameManager.activeAlliance == gameManager.player4)
        {
            apocAffectedAlliances.Remove(gameManager.player4);
        }
        gameManager.activeAlliance.activeApoclypse = null;
        gameManager.activeAlliance.apocolypseActive = false;
        gameManager.activeAlliance.apocolypseDurration = 0;
    }
    #endregion
    #region Events
    public void StartEvent(ApoclypseTypes currentApoclypse)
    {
        Start();

        int random = Random.Range(0, 10);
        if (random > 6 && currentApoclypse != ApoclypseTypes.None)
        {
            if (currentApoclypse == ApoclypseTypes.Famine)
            {
                switch (random)
                {
                    case 7:
                        titleText.text = ApocalypseConstants.FAMINE_MUTATION_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.FAMINE_MUTATION_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_MUTATION_SOLVE_TEXT1;
                        button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
                        eventType = EventTypes.FamineMutation;
                        break;
                    case 8:
                        titleText.text = ApocalypseConstants.FAMINE_PLAGUE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.FAMINE_PLAGUE_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_PLAGUE_SOLVE_TEXT0;
                        button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_PLAGUE_SOLVE_TEXT1;
                        eventType = EventTypes.FaminePlague;
                        break;
                    case 9:
                        titleText.text = ApocalypseConstants.FAMINE_EVOLUTION_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.FAMINE_EVOLUTION_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_EVOLUTION_SOLVE_TEXT0;
                        button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_EVOLUTION_SOLVE_TEXT1;
                        eventType = EventTypes.FamineEvolution;
                        break;
                    case 10:
                        titleText.text = ApocalypseConstants.FAMINE_BREAKTHROUGH_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.FAMINE_BREAKTHROUGH_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_BREAKTHROUGH_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
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
                        button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
                        eventType = EventTypes.AngelsMinions;
                        break;
                    case 8:
                        titleText.text = ApocalypseConstants.ANGELS_HELLFIRE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ANGELS_HELLFIRE_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_HELLFIRE_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
                        eventType = EventTypes.AngelsHellfire;
                        break;
                    case 9:
                        titleText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_PLAGUE_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
                        eventType = EventTypes.AngelsPlague;
                        break;
                    case 10:
                        titleText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ANGELS_PLAGUE_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ANGELS_PLAGUE_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
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
                        button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
                        eventType = EventTypes.ZombiesEvolutioin;
                        break;
                    case 8:
                        titleText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT0;
                        button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT1;
                        eventType = EventTypes.ZombiesHord;
                        break;
                    case 9:
                        titleText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ZOMBIES_HORDE_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT0;
                        button1.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_HORDE_SOLVE_TEXT1;
                        eventType = EventTypes.ZombiesHord;
                        break;
                    case 10:
                        titleText.text = ApocalypseConstants.ZOMBIES_MUTATION_EVENT_STRING;
                        bodyText.text = ApocalypseConstants.ZOMBIES_MUTATION_EVENT_TEXT;
                        button0.GetComponentInChildren<Text>().text = ApocalypseConstants.ZOMBIES_MUTATION_SOLVE_TEXT;
                        button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
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
                    button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
                    eventType = EventTypes.AdverseWeather;
                    break;
                case 1:
                    titleText.text = ApocalypseConstants.DROUGHT_EVENT_STRING;
                    bodyText.text = ApocalypseConstants.DROUGHT_EVENT_TEXT;
                    button0.GetComponentInChildren<Text>().text = ApocalypseConstants.DROUGHT_EVENT_SOLVE;
                    button1.GetComponentInChildren<Text>().gameObject.SetActive(false);
                    eventType = EventTypes.Drought;
                    break;
               
            }
        }
        
        button2.GetComponentInChildren<Text>().text = "Ignore";
        eventAffectedAlliances.Add(gameManager.player1);
        eventAffectedAlliances.Add(gameManager.player2);
        eventAffectedAlliances.Add(gameManager.player3);
        eventAffectedAlliances.Add(gameManager.player4);
    }

    public void CureEvent()
    {
        if (gameManager.activeAlliance == gameManager.player1)
        {
            eventAffectedAlliances.Remove(gameManager.player1);
        }
        else if (gameManager.activeAlliance == gameManager.player2)
        {
            eventAffectedAlliances.Remove(gameManager.player2);
        }
        else if (gameManager.activeAlliance == gameManager.player3)
        {
            eventAffectedAlliances.Remove(gameManager.player3);
        }
        else if (gameManager.activeAlliance == gameManager.player4)
        {
            eventAffectedAlliances.Remove(gameManager.player4);
        }

    }


    #endregion
    // A method to subtract a value from a given stat in a given alliance
    public void SubtractFromAllianceStat(Alliance alliance, AllianceStats stat, int value)
    {
        switch (stat)
        {
            case AllianceStats.Economy:
                alliance.AlliedNations[0].Economy -= value;
                break;
            case AllianceStats.Military:
                alliance.AlliedNations[0].Military -= value;
                break;
            case AllianceStats.Population:
                alliance.AlliedNations[0].Population -= value;
                break;
            case AllianceStats.Religion:
                alliance.AlliedNations[0].Religion -= value;
                break;
            case AllianceStats.Science:
                alliance.AlliedNations[0].Science -= value;
                break;
        }
        alliance.AlliedNations[0].updateInfoPanel();
        alliance.updateAllianceStats();
    }

    public void Close()
    {

        gameManager.CloseEventPanel();
    }
}
