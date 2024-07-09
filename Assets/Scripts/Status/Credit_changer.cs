using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credit_changer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string s;

    void Start()
    {
        text.SetText(s + GlobalVariables.credit);
    }
}