using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GPA_changer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string s;

    void Start()
    {
        string tx = GlobalVariables.GPA.ToString("F2");
        text.SetText(s + tx);
    }
}