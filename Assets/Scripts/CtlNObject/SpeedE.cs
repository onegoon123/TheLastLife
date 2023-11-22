using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedE : MonoBehaviour {

    void Update()
    {
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
        if (collider.transform.CompareTag("Remove"))
        {
            Destroy(gameObject);
        }
    }
}
