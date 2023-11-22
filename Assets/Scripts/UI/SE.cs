using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SE : MonoBehaviour {
    Slider slider;
    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = GameManager.instance.SE;
        GameObject.Find("button").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("Bat").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("trap").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("Jump").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("attack").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("coin").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("speed").GetComponent<AudioSource>().volume = GameManager.instance.SE;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Sound()
    {
        PlayerPrefs.SetFloat("SE", slider.value);
        GameManager.instance.SE = slider.value;
        GameObject.Find("button").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("Bat").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("trap").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("Jump").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("attack").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("coin").GetComponent<AudioSource>().volume = GameManager.instance.SE;
        GameObject.Find("speed").GetComponent<AudioSource>().volume = GameManager.instance.SE;
    }
}
