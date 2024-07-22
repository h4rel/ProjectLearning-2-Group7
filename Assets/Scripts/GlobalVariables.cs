using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
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
    // GPA
    public static float GPA = 0;
    // GPT
    public static float GPT = 0;
    // 所持ポイント
    public static int point = 0;
    // 残りライフ数
    public static int life = 4;
    // HP(最大)
    public static int maxHP = 40;
    // 攻撃力
    public static int ATK = 20;
    // プレイヤー人数
    public static int NOP = 1;
    // 学年
    public static int grade = 1;



    // 自分のid(マッチング時に決定するもの)
    public static int mynum = 1;
    public static int hasTransitioned = 0; // フラグを追加
    public static int numOfPlayer = 2;
    public static string playername = "Player1";
    public static string teamname = "TeamA";
    public static float gpa = 3.5f;
    public static float score = 25.0f;




    public static int[] weapon = new int[] { 0, 0, 0, 0 };
    public static int[] weaponATK = new int[] { 0, 5, 7, 11, 15 };
    public static int[] weaponPrice = new int[] { 2, 4, 6, 8 };
    public static int hold = -1;

    public static int shopselect = -1;



    public static int building = 0;
    public static List<int> enter_times = new List<int> { 0, 0, 0, 0 };
    public static int[,] id = new int[,] { { 4, 5, -1, 8, -1, 9, -1, -1 }, { 0, 1, -1, 6, -1, 11, -1, -1 }, { 2, 3, -1, 7, -1, 10, -1, -1 }, { -1, -1, -1, 12, -1, -1, -1, -1 } };
    public static string beforeScene;

    public static int battleresult = 2;
    public static float[] GP = new float[] { 0, 2, 3, 4, 4.5f };


    // 経過時間の管理
    public static int minutes = 0;
    public static int seconds = 0;
    public static int hours = 0;
    private static int _time;

    private static int starttime;

    public static void init()
    {
        for (int i = 0; i < 4; i++)
        {
            weapon[i] = 0;
            enter_times[i] = 0;
        }
        dir = "start";
        credit = 0;
        GPA = 0;
        GPT = 0;
        point = 0;
        life = 4;
        maxHP = 40;
        ATK = 20;
        grade = 1;
        hold = -1;
        shopselect = -1;
        minutes = 0;
        seconds = 0;
        hours = 0;
        starttime = (int)Time.time;
    }

    public void Update()
    {
        _time = (int)Time.time - starttime;
        minutes = _time / 60;
        seconds = _time % 60;
        if (minutes >= 60)
        {
            hours++;
            minutes -= 60;
        }
        
    }
}
