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
    public bool inAlliance;
    public GameObject panel;
    NationInfoPanel nationInfoPanel;
    GameManager gameManager;
    public Canvas canvas;
	bool LeaveOpen { get; set; }
    
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
        int nationNumber = worldMap.NationNumbers[nationName];
        Economy = worldMap.NationEconomies[nationNumber];
        Military = worldMap.NationMilitaries[nationNumber];
        Science = worldMap.NationSciences[nationNumber];
        Religion = worldMap.NationReligions[nationNumber];
        Population = worldMap.NationPopulations[nationNumber];

        gameManager = FindObjectOfType<GameManager>();
        nationInfoPanel = panel.GetComponent<NationInfoPanel>();
        nationInfoPanel = (NationInfoPanel)(GameObject.Instantiate(nationInfoPanel, canvas.transform, false));
        nationInfoPanel.transform.SetParent(canvas.transform);
        nationInfoPanel.Name.text = name.ToString();
        nationInfoPanel.militaryNumber.text = military.ToString();
        nationInfoPanel.populationNumber.text = population.ToString();
        nationInfoPanel.scienceNumber.text = science.ToString();
        nationInfoPanel.econNumber.text = economy.ToString();
        nationInfoPanel.religionNumber.text = religion.ToString();
        nationInfoPanel.enabled = false;

		LeaveOpen = false;

        //Debug.Log(nationName + ": Economy: " + economy + "  Military: " + military + "  Science: " + science + "  Religion: " + religion + "  Population: " + population);


    }


    void OnMouseEnter ()
    {
        Debug.Log("Welcome to " + nationName + "!!!");
        //Debug.Log(nationName + ": Economy: " + economy + "  Military: " + military + "  Science: " + science + "  Religion: " + religion + "  Population: " + population);
        // will actually pop up the country stats
        
        panel.SetActive(true);
        Vector3 panelPos = new Vector3(70,70,10);
        Debug.Log(panelPos + "pos");

        nationInfoPanel.enabled = true;
        nationInfoPanel.gameObject.SetActive(true);
        //panel.transform.position.Set(pos.x, pos.y, pos.z);
        nationInfoPanel.GetComponent<RectTransform>().position = panelPos;

        Debug.Log(nationInfoPanel.transform.position);
        

    }

    void OnMouseExit()
    {
		if (!LeaveOpen)
		{
			Debug.Log("Leaving " + nationName + "!");
        	// will actually destroy the popu-up
        	panel.SetActive(false);
        	nationInfoPanel.enabled = false;
        	nationInfoPanel.gameObject.SetActive(false);
		}
    }

    void OnMouseUpAsButton()
    {
		LeaveOpen = true;
		//gameManager.activeAlliance.addNationToAlliance(nationName);
		panel.SetActive(true);
		Vector3 panelPos = new Vector3(70,70,10);
		Debug.Log(panelPos + "pos");

		nationInfoPanel.enabled = true;
		nationInfoPanel.gameObject.SetActive(true);
		nationInfoPanel.GetComponent<RectTransform>().position = panelPos;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (boundingArea.bounds.Contains((Vector2)((Camera.main.ScreenToWorldPoint(Input.mousePosition)))))
            {
                gameManager.activeAlliance.AttackAlliance(GetComponentInParent<WorldMap>().NationNumbers[nationName]);
            }
        }
    }
    #endregion
}
