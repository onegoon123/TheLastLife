using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Onclick()
    {
        Application.Quit();
    }
    public void mainmenu()
    {
        SceneManager.LoadScene(5);
        Time.timeScale = 1;
    }
    public void titel()
    {
        SceneManager.LoadScene(0);
    }
}
