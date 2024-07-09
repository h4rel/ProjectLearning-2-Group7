using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Time_changer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string s;

    void Start()
    {
        text.SetText(s + GlobalVariables.minutes + ':' + GlobalVariables.seconds);
    }

    void Update()
    {
        string t = s;
        if (GlobalVariables.hours < 10)
        {
            t += '0';
        }
        t += GlobalVariables.hours;
        t += ':';

        if (GlobalVariables.minutes < 10)
        {
            t += '0';
        }
        t += GlobalVariables.minutes;
        t += ':';

        if (GlobalVariables.seconds < 10)
        {
            t += '0';
        }
        t += GlobalVariables.seconds;

        text.SetText(t);
    }
}