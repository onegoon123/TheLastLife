﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
