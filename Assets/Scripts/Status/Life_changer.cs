using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Life_changer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string s;

    void Start()
    {
        text.SetText(s + GlobalVariables.life);
    }
}