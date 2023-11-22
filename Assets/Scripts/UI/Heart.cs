using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    public Sprite sprite;
	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.instance.PlayerHp <= 0)
        {
            spriteRenderer.sprite = sprite;
        }
	}
}
