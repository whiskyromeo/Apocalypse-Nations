using UnityEngine;
using System.Collections;

[System.Serializable]
public class Nation
	{
	//list of nation variables stored in class
	public string name;
	public int military;
	public int population;
	public int religion;
	public int science;
	public int economy;
	public int control;
	public int empireSize;
	public double threat;
	public int takeovers;
	public int truces;
	public int miracle;
	public bool protection;
	public bool uprising;
	public int allegience;


		public Nation ()
		{
		this.name = "";
		this.military = 0;
		this.population = 0;
		this.religion = 0;
		this.science = 0;
		this.economy = 0;
		this.empireSize = 0;
		this.threat = 0.0;
		this.truces = 0;
		this.miracle = 0;
		this.protection = false;
		this.uprising = false;
		this.allegience = 0;

		}
	}


