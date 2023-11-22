using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    float t;
	// Use this for initialization
	void Start () {
        StartCoroutine(End());
        GameObject.Find("game over").GetComponent<AudioSource>().volume = GameManager.instance.BGM;
        GameObject.Find("game over").GetComponent<AudioSource>().Play();
    }
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator End()
    {
        float t = 0;
        while (t <= 3)
        {
            t += Time.deltaTime;
            yield return null;
        }
        t = 0;
        while (t <= 2)
        {
            t += Time.deltaTime;
            GameObject.Find("game over").GetComponent<AudioSource>().volume -= Time.deltaTime * 0.5f;
            yield return null;
        }
        GameObject.Find("game over").GetComponent<AudioSource>().Stop();
        SceneManager.LoadScene(4);
    }
}
