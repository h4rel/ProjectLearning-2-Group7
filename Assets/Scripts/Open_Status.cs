using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Open_Status : MonoBehaviour
{

    [SerializeField] private Canvas panel;

    [SerializeField] private TextMeshProUGUI tmp;

    [SerializeField] private string s;

    public void OnPointerEnter()
    {
        tmp.text = "<color=#ffffa0>" + s;
    }

    public void OnPointerExit()
    {
        tmp.text = s;
    }

    public void OnPointerClick()
    {
        panel.enabled = true;
    }

}
