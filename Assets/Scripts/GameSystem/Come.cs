using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Come : MonoBehaviour {

    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    public GameObject Object4;
    public GameObject Object5;

    void Start () {

	}
	
	void Update () {
        Coming();
	}

    void Coming()
    {
        if (GameManager.instance.startBattle == false)
        {
            Vector2 vector = new Vector2(-1, 0);
            transform.Translate(vector * GameManager.instance.ScrollSpeed * Time.deltaTime);
        }
    }

}
