using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Apoclypse : MonoBehaviour {

    string title, introText, mainText, button0Text, button1Text, button2Text;
    int solveCost1, solveCost2, solveCost0, turnCost0, turnCost1, turnCost2;
    public enum AllianceStats { Population, Military, Science, Religion, Economy };
    public enum ApoclypseTypes { Famine};
    public GameObject eventPanelObject;
    public EventPanel eventPanelScript;
    // Use this for initialization
    public void StartApocolypse()
    {

        int rand = Random.Range(0, 1);
        switch (rand)
        {
            case 0:
                eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                eventPanelScript.introText.text = ApocalypseConstants.FAMINE_INTRO_TEXT0;
                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                break;
            case 1:
                eventPanelScript.titleText.text = ApocalypseConstants.FAMINE_APOCALYPSE_STRING;
                eventPanelScript.introText.text = ApocalypseConstants.FAMINE_INTRO_TEXT1;
                eventPanelScript.button0.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_0_TEXT;
                eventPanelScript.button1.GetComponentInChildren<Text>().text = ApocalypseConstants.FAMINE_SOLVE_BUTTON_1_TEXT;
                break;
        }
        eventPanelScript.button2.GetComponentInChildren<Text>().text = "Ignore";
    }
    public void ApocolypseTurnEffect(Alliance alliance, ApoclypseTypes apoclypseType)
    {
            if (apoclypseType == ApoclypseTypes.Famine)
            {
                SubtractFromAllianceStat(alliance, AllianceStats.Population, ApocalypseConstants.FAMINE_POPULATION_REDUCTION);
                SubtractFromAllianceStat(alliance, AllianceStats.Economy, ApocalypseConstants.FAMINE_ECONOMY_REDUCTION);
                SubtractFromAllianceStat(alliance, AllianceStats.Science, ApocalypseConstants.FAMINE_SCIENCE_REDUCTION);
            }
    }
    public void ApocolypseSolution1(ApoclypseTypes apoclypseType, Alliance alliance)
    {
        if (apoclypseType == ApoclypseTypes.Famine)
        {
            if (alliance.economy >= 40 && alliance.science >= 30)
            {
                alliance.activeApoclypse = null;
            }
            else
            {
                eventPanelScript.mainText.text = "You do not have the Resources";
            }
        }
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
}
