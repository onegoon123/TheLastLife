using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour {
    Slider slider;
    // Use this for initialization
    void Start() {
        slider = GetComponent<Slider>();
        slider.value = GameManager.instance.BGM;
        GameObject.Find("main").GetComponent<AudioSource>().volume = GameManager.instance.BGM;
    }

    // Update is called once per frame
    void Update() {

    }

    public void Sound()
    {
        PlayerPrefs.SetFloat("BGM", slider.value);
        GameManager.instance.BGM = slider.value;
        GameObject.Find("main").GetComponent<AudioSource>().volume = GameManager.instance.BGM;
    }
}
