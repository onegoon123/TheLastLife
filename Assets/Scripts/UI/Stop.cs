using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stop : MonoBehaviour {

    int Voulme = 3;
    Time MyTime;
    public Image sprite;

    public Sprite StopSprite;
    public Sprite PlaySprite;
    public GameObject Menu;
    void Start()
    {
        MyTime = GetComponent<Time>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Click();
    }
    public void Click()
    {
        GameObject.Find("button").GetComponent<AudioSource>().Play();
        if (GameManager.instance.Pause == false)
        {
            Time.timeScale = 0;
            GameManager.instance.Pause = true;
            sprite.sprite = PlaySprite;
            Menu.transform.position = new Vector3(0, -0.4f, -1);
        }
        else if (GameManager.instance.Pause == true)
        {
            Time.timeScale = 1.0f;
            GameManager.instance.Pause = false;
            sprite.sprite = StopSprite;
            Menu.transform.position = new Vector3(-16, -0.4f, -1);
        }
    }
}
