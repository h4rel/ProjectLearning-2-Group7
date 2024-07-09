using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Open_Status : MonoBehaviour
{
    [SerializeField] private GameObject now;

    [SerializeField] private GameObject to_open;

    [SerializeField] private TextMeshProUGUI tmp;

    [SerializeField] private string s;

    private void Start()
    {
        to_open.SetActive(false);
    }

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
        tmp.text = s;
        to_open.SetActive(true);
        now.SetActive(false);
    }

}
