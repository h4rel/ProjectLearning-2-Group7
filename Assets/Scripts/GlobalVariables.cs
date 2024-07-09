using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// グローバル変数を宣言するためのクラス

public class GlobalVariables : MonoBehaviour
{
    // 画面遷移の方向を保存する用の変数
    public static string dir = "start";
    public static string _name = "Player1";
    public static int credit = 0;
    public static int life = 4;
    public static int minutes = 0;
    public static int seconds = 0;
    public static int hours = 0;
    private int _time;

    public void Update()
    {
        _time = (int)Time.time;
        minutes = _time / 60;
        seconds = _time % 60;
        if (minutes >= 60)
        {
            hours++;
            minutes -= 60;
        }
    }
}
