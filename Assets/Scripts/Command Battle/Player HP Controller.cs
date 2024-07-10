using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPController : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private PlayerSettings player;
    void Start()
    {
        text.SetText(player.getmaxHP() + "/" + player.getmaxHP());
    }

    public void updateHP()
    {
        bar.fillAmount = (float)player.getcurrentHP() / (float)GlobalVariables.maxHP;
        text.SetText(player.getcurrentHP() + "/" + GlobalVariables.maxHP);
    }
}
