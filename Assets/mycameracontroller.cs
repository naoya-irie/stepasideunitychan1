﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mycameracontroller : MonoBehaviour {
    private GameObject unitychan;
    private float difference;
    
	void Start () {
        this.unitychan = GameObject.Find("unitychan");
        this.difference = unitychan.transform.position.z - this.transform.position.z;

		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
        
		
	}
}