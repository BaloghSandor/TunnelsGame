using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina_Bar_Script : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStamina(float stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }

    public void SetMinStamina(float stamina)
    {
        slider.minValue = stamina;
    }

    public void SetStamina(float stamina)
    {
        slider.value = stamina;
    }

}
