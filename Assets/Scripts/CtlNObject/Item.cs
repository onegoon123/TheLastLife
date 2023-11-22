using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

	void Update () {
        Come();
	}

    void Come()
    {
        if (GameManager.instance.startBattle == false)
        {
            Vector2 vector = new Vector2(-1, 0);
            transform.Translate(vector * GameManager.instance.ScrollSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
        if (collider.transform.CompareTag("Remove"))
        {
            Destroy(gameObject);
        }
    }
}
