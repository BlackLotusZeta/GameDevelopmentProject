using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDManager : MonoBehaviour
{

    [SerializeField]
    private Slider healthBarAmount = null;
    [SerializeField]
    private Text timeText = null;
    [SerializeField]
    private String timeTextMessage = null;
    [SerializeField]
    private float sliderFillSpeed = .5f;

    private float timeTillFill = 0;
    private float currentHealthValue;
    private float newHealthValue = 100;
    private float timeInLevel;

    void Start()
    {
        EfiHealth.UpdatePlayerHealth += ChangeValue;
    }

    private void Update()
    {
        AddTime();
        NewBarValue();
    }

    private void AddTime()
    {
        if(currentHealthValue > 0)
        {
            timeInLevel += Time.deltaTime;
            timeText.text = timeTextMessage + Math.Round(timeInLevel, 2);
        }
    }

    private void ChangeValue(int amount)
    {
        newHealthValue = amount;
        timeTillFill = 0;
    }

    private void NewBarValue()
    {
        if(currentHealthValue != newHealthValue)
        {
            currentHealthValue = Mathf.Lerp(currentHealthValue, newHealthValue, timeTillFill);
        }
        healthBarAmount.value = currentHealthValue;
    }

}
