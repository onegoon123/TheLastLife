using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    void Awake() {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
        HighScore = PlayerPrefs.GetInt("HighScore");
        BGM = PlayerPrefs.GetFloat("BGM");
        SE = PlayerPrefs.GetFloat("SE");
    }

    void InitGame() {

    }
    public bool Hit;
    public bool TouchOn;
    public bool Run;
    public bool startBattle;
    public bool Pause;
    public float StartSpeed;
    public float NomalSpeed;
    public float ScrollSpeed;
    public float MaxHp;
    public float PlayerHp;
    public float BGM;
    public float SE;
    public int GetCoin = 0;
    public int HighScore = 0;
}
