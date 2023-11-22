using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlay : MonoBehaviour {
    public GameObject image;
	// Use this for initialization
	void Start () {
        GameObject.Find("ready").GetComponent<AudioSource>().volume = GameManager.instance.BGM;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
            image.transform.position = new Vector3(3000, 0, 0);
    }
    public void how()
    {
        image.transform.position = new Vector3(960, 540, 0);
    }
}
