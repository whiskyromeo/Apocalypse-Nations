using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WorldMap : MonoBehaviour {

    List<Nation> Nations;
    BoxCollider2D[] NationBoraders;
	// Use this for initialization
	void Start ()
    {
        NationBoraders = GetComponents<BoxCollider2D>();
        BoxCollider2D USA = NationBoraders[0];
        BoxCollider2D Canada = NationBoraders[1];
        BoxCollider2D GreenLand = NationBoraders[2];	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
