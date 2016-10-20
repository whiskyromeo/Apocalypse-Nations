using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


	public class SaveLoad
	{
	public static List<nationData> nations = new List<nationData> ();
		
		public static void SaveNations(){
		SaveLoad.nations.Add (nationData.current);
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/ChoiceCalcs.db", FileMode.OpenOrCreate);
		bf.Serialize (file, nationData.current);
			file.Close ();
		}
		public static void LoadNations()
		{
			if(File.Exists(Application.persistentDataPath+ "/ChoiceCalcs.db"))
			{
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open(Application.persistentDataPath +"/ChoiceCalcs.db", FileMode.Open);
				SaveLoad.nations = (List<nationData>)bf.Deserialize(file);
				file.Close();
			}
		}
	public static void CalcNation(Nation nation, int apocalypse)
	{
		nation.allegience = nation.allegience * apocalypse;
		nation.control = nation.control * apocalypse;
		nation.military = nation.military * apocalypse;
		nation.religion = nation.religion * apocalypse;
		nation.science = nation.science * apocalypse;
	}
	public static void CalcNations(int apocalypse)
	{

	}
	public static void CalcThreat(Nation nation)
	{
		nation.threat = (((nation.science * nation.economy) * 1.1) +
			((nation.military - nation.population) * 1.3) + 
			((nation.truces - nation.takeovers) * 1.6));

	}
	}


