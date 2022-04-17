using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoapBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxSoap(float soap)
    {
        slider.maxValue = soap;
        slider.value = soap;
    }

    public void SetSoap(float soap)
    {
        slider.value = soap;
    }
}
