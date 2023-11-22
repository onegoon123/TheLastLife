using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle : MonoBehaviour {
    public ParticleSystem particleSystem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        particleSystem.startLifetime = 0.005f * GameManager.instance.ScrollSpeed;
    }
}
