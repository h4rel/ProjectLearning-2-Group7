using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Open_Status : MonoBehaviour
{
    [SerializeField] private GameObject now;

    [SerializeField] private GameObject to_open;

    [SerializeField] private List<GameObject> to_close;

    [SerializeField] private TextMeshProUGUI tmp;

    [SerializeField] private string s;

    [SerializeField] private int close_option;


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
        foreach (GameObject obj in to_close)
        {
            obj.SetActive(false);
        }
        if (close_option > 0)
        {
            now.SetActive(false);
        }
    }

}
