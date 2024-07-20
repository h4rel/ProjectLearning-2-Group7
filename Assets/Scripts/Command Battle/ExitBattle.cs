using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// シーン切り替えに必要

// タッチすると、シーンを切り換える
public class ExitBattle : MonoBehaviour
{
    public void OnMouseDown()
    {
        GlobalVariables.GPT += GlobalVariables.GP[GlobalVariables.battleresult] * EnemySettings.eset[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]].credit;
        GlobalVariables.credit += EnemySettings.eset[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]].credit;
        GlobalVariables.point += EnemySettings.eset[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]].point; //成績による傾斜をまだつけていない

        GlobalVariables.GPA = GlobalVariables.GPT / GlobalVariables.credit;
        GlobalVariables.enter_times[GlobalVariables.building]++;

        SceneManager.LoadScene(GlobalVariables.beforeScene);
    }
}