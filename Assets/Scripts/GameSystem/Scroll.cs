using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour
{

    void Start() {
    }

    void Update()
    {
        if (GameManager.instance.startBattle == false)
        {

            transform.Translate(Vector2.left * GameManager.instance.ScrollSpeed * Time.deltaTime);

            if (transform.position.x < -14.2f)
            {
                transform.position = new Vector2(0, 0);
            }
        }
    }
}