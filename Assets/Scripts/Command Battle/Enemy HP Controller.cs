using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPController : MonoBehaviour
{
    [SerializeField] private Image bar;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private EnemySettings enemy;
    void Start()
    {
        text.SetText(enemy.getmaxHP() + "/" + enemy.getmaxHP());
    }

    public void updateHP()
    {
        bar.fillAmount = (float)enemy.getcurrentHP() / (float)enemy.getmaxHP();
        text.SetText(enemy.getcurrentHP() + "/" + enemy.getmaxHP());
    }
}

