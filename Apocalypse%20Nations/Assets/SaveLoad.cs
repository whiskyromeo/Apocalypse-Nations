using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public class SaveLoad : MonoBehaviour
	{
	public static List<nationData> nations = new List<nationData> ();
	nationData data =  nationData.current; 

		public  void SaveNations(){
		Debug.Log ("test");
		SaveLoad.nations.Add (nationData.current);
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.OpenWrite (Application.persistentDataPath + "/ChoiceCalcs.db");
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
	private  void CalcNation(Nation nation, int apocalypse)
	{
		nation.allegience = nation.allegience * apocalypse;
		nation.control = nation.control * apocalypse;
		nation.military = nation.military * apocalypse;
		nation.religion = nation.religion * apocalypse;
		nation.science = nation.science * apocalypse;
	}
	public  void CalcNations(int apocalypse)
	{
		nations.Clear();
		nations.Add (nationData.current);

		CalcNation (nations[0].n1, apocalypse);
		CalcNation (nations[0].n2, apocalypse);
		CalcNation (nations[0].n3, apocalypse);
		CalcNation (nations[0].n4, apocalypse);
		CalcNation (nations[0].n5, apocalypse);
		CalcNation (nations[0].n6, apocalypse);
		CalcNation (nations[0].n7, apocalypse);
		CalcNation (nations[0].n8, apocalypse);
		CalcNation (nations[0].n9, apocalypse);
		CalcNation (nations[0].n10, apocalypse);
		CalcNation (nations[0].n11, apocalypse);
		CalcNation (nations[0].n12, apocalypse);
		CalcNation (nations[0].n13, apocalypse);
		CalcNation (nations[0].n14, apocalypse);
		CalcNation (nations[0].n15, apocalypse);
		CalcNation (nations[0].n16, apocalypse);
		CalcNation (nations[0].n17, apocalypse);
		CalcNation (nations[0].n18, apocalypse);
		CalcNation (nations[0].n19, apocalypse);
		CalcNation (nations[0].n20, apocalypse);
		CalcNation (nations[0].n21, apocalypse);
		CalcNation (nations[0].n22, apocalypse);
		CalcNation (nations[0].n23, apocalypse);
		CalcNation (nations[0].n24, apocalypse);
		CalcNation (nations[0].n25, apocalypse);
		CalcNation (nations[0].n26, apocalypse);
		CalcNation (nations[0].n27, apocalypse);
		CalcNation (nations[0].n28, apocalypse);
		CalcNation (nations[0].n29, apocalypse);
		CalcNation (nations[0].n30, apocalypse);
		CalcNation (nations[0].n31, apocalypse);
		CalcNation (nations[0].n32, apocalypse);
		CalcNation (nations[0].n33, apocalypse);
		CalcNation (nations[0].n34, apocalypse);
		CalcNation (nations[0].n35, apocalypse);
		CalcNation (nations[0].n36, apocalypse);
		CalcNation (nations[0].n37, apocalypse);
		CalcNation (nations[0].n38, apocalypse);
		CalcNation (nations[0].n39, apocalypse);
		CalcNation (nations[0].n40, apocalypse);
		CalcNation (nations[0].n41, apocalypse);
		CalcNation (nations[0].n42, apocalypse);
		CalcNation (nations[0].n43, apocalypse);
		CalcNation (nations[0].n44, apocalypse);
		CalcNation (nations[0].n45, apocalypse);
		CalcNation (nations[0].n46, apocalypse);
		CalcNation (nations[0].n47, apocalypse);
		CalcNation (nations[0].n48, apocalypse);
		CalcNation (nations[0].n49, apocalypse);
		CalcNation (nations[0].n50, apocalypse);

	}
	public  void CalcThreat(Nation nation)
	{
		nation.threat = (((nation.science * nation.economy) * 1.1) +
			((nation.military - nation.population) * 1.3) + 
			((nation.truces - nation.takeovers) * 1.6));

	}
	}


