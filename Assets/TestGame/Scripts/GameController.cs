﻿using UnityEngine;
using System.Collections;

public class GameController: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void BackToHomePage(){
		Application.LoadLevel (0);
	}
}
