using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantyBar : MonoBehaviour
{
    public Slider slider;

    public void SetMinDirtiness(int dirtiness)
    {
        slider.minValue = dirtiness;
        slider.value = dirtiness;
    }

    public void SetDirtiness(int dirtiness)
    {
        slider.value = dirtiness;
    }

}