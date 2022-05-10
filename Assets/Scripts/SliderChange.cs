using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderChange : MonoBehaviour
{
    public Slider slider;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value == 1)
        {
            point3.SetActive(true);
        }else if(slider.value >= 0.5)
        {
            point2.SetActive(true);
            point3.SetActive(false);
        }else if(slider.value <= 0.5)
        {
            point1.SetActive(true);
            point2.SetActive(false);
            point3.SetActive(false);
        }
    }

}
