using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// initial author TylerD
/// </summary>
public class Nation : MonoBehaviour {

    #region fields
    public PolygonCollider2D boundingArea;
    //public enum NationStats { Population, Science, Military, Economy, Religion};
    public string nationName;
    int population;
    int science;
    int military;
    int economy;
    int religion;
	int nationNumber;
    public bool inAlliance;
    public GameObject nationPanel;
    public GameObject actionsPanel;
    public NationInfoPanel nationInfoPanel;
    public PlayerActionsPanel playerActionsPanel;
    GameManager gameManager;
    public Canvas canvas;
    bool isOpen;
	public bool LeaveOpen { get; set; }
    
    #endregion

    #region Properties
    /// <summary>
    /// Gets and set the population Value
    /// </summary>
    public int Population
    {  get
        {
            return population;
        }

        set
        {
            population = value;
        }
    }
    /// <summary>
    /// Gets and set the Science Value
    /// </summary>
    public int Science
    {
        get
        {
            return science;
        }

        set
        {
            science = value;
        }
    }
    /// <summary>
    /// Gets and set the Military Value
    /// </summary>
    public int Military
    {
        get
        {
            return military;
        }

        set
        {
            military = value;
        }
    }
    /// <summary>
    /// Gets and set the Economy Value
    /// </summary>
    public int Economy
    {
        get
        {
            return economy;
        }

        set
        {
            economy = value;
        }
    }
    /// <summary>
    /// Gets and set the Religion Value
    /// </summary>
    public int Religion
    {
        get
        {
            return religion;
        }

        set
        {
            religion = value;
        }
    }
    #endregion



    #region Private Methods
    // Use this for initialization
    void Start () {
        inAlliance = false;
        WorldMap worldMap = GetComponentInParent<WorldMap>();
        nationNumber = worldMap.NationNumbers[nationName];
        Economy = worldMap.NationEconomies[nationNumber];
        Military = worldMap.NationMilitaries[nationNumber];
        Science = worldMap.NationSciences[nationNumber];
        Religion = worldMap.NationReligions[nationNumber];
        Population = worldMap.NationPopulations[nationNumber];

        gameManager = FindObjectOfType<GameManager>();
        nationInfoPanel = nationPanel.GetComponent<NationInfoPanel>();
        nationInfoPanel = (NationInfoPanel)(GameObject.Instantiate(nationInfoPanel, canvas.transform, false));
        nationInfoPanel.transform.SetParent(canvas.transform);
        nationInfoPanel.Name.text = name.ToString();
        nationInfoPanel.militaryNumber.text = military.ToString();
        nationInfoPanel.populationNumber.text = population.ToString();
        nationInfoPanel.scienceNumber.text = science.ToString();
        nationInfoPanel.econNumber.text = economy.ToString();
        nationInfoPanel.religionNumber.text = religion.ToString();
        nationInfoPanel.enabled = false;
        playerActionsPanel = actionsPanel.GetComponent<PlayerActionsPanel>();
        playerActionsPanel = PlayerActionsPanel.Instantiate(playerActionsPanel);
        playerActionsPanel.transform.SetParent(canvas.transform);
        playerActionsPanel.gameObject.SetActive(false);
        Vector3 actionPanelPos = new Vector3(300, 150, 10);
        playerActionsPanel.GetComponent<RectTransform>().position = actionPanelPos;

		LeaveOpen = false;

        //Debug.Log(nationName + ": Economy: " + economy + "  Military: " + military + "  Science: " + science + "  Religion: " + religion + "  Population: " + population);

    }

    /// <summary>
    /// pops up the nation info panel on mouse enter
    /// </summary>
    void OnMouseEnter ()
    {
        foreach (PlayerActionsPanel info in gameManager.actionPanels)
        {
            if (info.gameObject.activeInHierarchy)
            {
                isOpen = true;
            }
        }
        if (!isOpen)
        {
            Vector3 panelPos = new Vector3(70, 70, 10);
            nationInfoPanel.gameObject.SetActive(true);
            nationInfoPanel.GetComponent<RectTransform>().position = panelPos;
        }
    }

    /// <summary>
    /// close the nation info panel if you have not clicked on the nation
    /// </summary>
    void OnMouseExit()
    {
		if (!LeaveOpen)
		{
        	nationInfoPanel.gameObject.SetActive(false);
		}
    }

    /// <summary>
    /// leave opeen the nation info panel
    /// pop up actions panel
    /// </summary>
    void OnMouseUpAsButton()
    {
        foreach (PlayerActionsPanel info in gameManager.actionPanels)
        {
            if (info.gameObject.activeInHierarchy)
            {
                isOpen = true;
            }
        }
        if (!isOpen)
        {
            LeaveOpen = true;
            gameManager.CurrentNationNumber = nationNumber;
            playerActionsPanel.gameObject.SetActive(true);
        }

        /// this is for using a turn to boulster your defences of nations you already own
        //if (gameManager.activeAlliance.AlliedNations.Contains(this))
        //{
        //    military = (int)(military * (gameManager.activeAlliance.AlliedNations.Count * 0.1f));
        //    population = (int)(population * (gameManager.activeAlliance.AlliedNations.Count * 0.1f));
        //    science = (int)(science * (gameManager.activeAlliance.AlliedNations.Count * 0.1f));
        //    religion = (int)(religion * (gameManager.activeAlliance.AlliedNations.Count * 0.1f));
        //    economy = (int)(economy * (gameManager.activeAlliance.AlliedNations.Count * 0.1f));
        //}
    }


    void Update()
    {


		if (Input.GetKeyDown(KeyCode.C))
		{
			LeaveOpen = false;
			nationPanel.SetActive(false);
			nationInfoPanel.enabled = false;
			nationInfoPanel.gameObject.SetActive(false);
		}
    }
    #endregion

    #region Public Methods
    public void updateInfoPanel()
    {
        nationInfoPanel.militaryNumber.text = military.ToString();
        nationInfoPanel.populationNumber.text = population.ToString();
        nationInfoPanel.scienceNumber.text = science.ToString();
        nationInfoPanel.econNumber.text = economy.ToString();
        nationInfoPanel.religionNumber.text = religion.ToString();
    }
    #endregion
}
