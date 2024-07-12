using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// グローバル変数を宣言するためのクラス

public class GlobalVariables : MonoBehaviour
{
    // 画面遷移の方向を保存する用の変数
    public static string dir = "start";
    // プレイヤー名
    public static string _name = "Player1";
    // 取得単位数
    public static int credit = 0;
    // 残りライフ数
    public static int life = 4;
    // HP(最大)
    public static int maxHP = 30;
    // 攻撃力
    public static int ATK = 10;


    public static int building = -1;
    public static List<int> enter_times = new List<int> { 0, 0, 0, 0, 0 };
    public static int[,] id = new int[3, 4] { { 0, 1, 2, 3 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
    public static string beforeScene;

    public static int battleresult = 0;


    // 経過時間の管理
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
