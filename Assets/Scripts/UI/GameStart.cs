using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.Find("title").GetComponent<AudioSource>().volume = GameManager.instance.BGM;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Onclick()
    {
        SceneManager.LoadScene(1);
    }
    public void Ready()
    {
        SceneManager.LoadScene(5);
    }
}
