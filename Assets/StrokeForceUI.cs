using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeForceUI : MonoBehaviour
{
    void Start()
    {
        StrokeManager = GameObject.FindObjectOfType<StrokeManager>();
        image = GetComponent<Image>();
    }

    StrokeManager StrokeManager;
    Image image;

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = StrokeManager.StrokeForcePerc;
    }
}
