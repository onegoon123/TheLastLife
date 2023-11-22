using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeImage : MonoBehaviour {

    public Slider slider;
    AudioSource audio;
    public Sprite V0;
    public Sprite V1;
    public Sprite V2;
    public Sprite V3;
    Image image;
    float imageChange;

    void Start () {
        image = GetComponent<Image>();
	}

    // Update is called once per frame
    void Update () {
        imageChange = slider.value;
        if (imageChange > 0.6f)
        {
            image.sprite = V3;
        }
        else if (imageChange > 0.3f)
            image.sprite = V2;
        else if (imageChange > 0f)
            image.sprite = V1;
        else if (imageChange == 0f)
            image.sprite = V0;
    }
}
