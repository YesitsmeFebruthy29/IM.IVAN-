using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIhealthBar : MonoBehaviour
{
    private Slider _HealthBar;

    private void Awake()
    {
        _HealthBar = GetComponent<Slider>();
    }

    public void setValue(int health)
    {
        _HealthBar.value = health;
    }


    public void SetMax(int maxHealth)
    {
        _HealthBar.maxValue = maxHealth;
    }

    
}
