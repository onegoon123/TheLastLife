using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScreen : MonoBehaviour {
    public Text Score;
    public Text HighScore;
	// Use this for initialization
	void Start () {
        Score.text = "" + GameManager.instance.GetCoin;
        HighScore.text = "" + GameManager.instance.HighScore;
    }
	
	// Update is called once per frame
	void Update () {
	}
}
