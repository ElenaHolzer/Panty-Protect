using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadBar : MonoBehaviour
{
    public Slider slider;

    public void SetMinFullness (int fullness)
    {
        slider.minValue = fullness;
        slider.value = fullness;
    }

    public void SetFullness(int fullness)
    {
        slider.value = fullness;
    }

}
