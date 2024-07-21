using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBattle : MonoBehaviour
{

    public string targetObjectName;
    public string nowscene;
    [SerializeField] int building_num;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == targetObjectName)
        {
            // 画面遷移の方向の保存
            GlobalVariables.dir = "enter";
            GlobalVariables.building = building_num;
            GlobalVariables.beforeScene = nowscene;

            if (building_num == 2) GlobalVariables.dir = "down";

            // シーンを切り換える
            if (GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]] >= 0)
            {
                SceneManager.LoadScene("Multi_CommandBattle");
            }
            else
            {
                SceneManager.LoadScene("NoOneHereScene");
            }

        }
    }
}
