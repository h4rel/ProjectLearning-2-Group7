using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPContoroller : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private TextMeshProUGUI text;
    void Start()
    {
        GlobalVariables.currentHP = GlobalVariables.maxHP;
        text.SetText(GlobalVariables.currentHP + "/" + GlobalVariables.maxHP);
    }

    public void updateHP()
    {
        bar.fillAmount = (float)GlobalVariables.currentHP / (float)GlobalVariables.maxHP;
        text.SetText(GlobalVariables.currentHP + "/" + GlobalVariables.maxHP);
    }
}
