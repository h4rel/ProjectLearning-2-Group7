using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// �V�[���؂�ւ��ɕK�v

// �^�b�`����ƁA�V�[����؂芷����
public class ExitBattle : MonoBehaviour
{
    public void OnMouseDown()
    {
        GlobalVariables.GPT += GlobalVariables.GP[GlobalVariables.battleresult] * EnemySettings.eset[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]].credit;
        GlobalVariables.credit += EnemySettings.eset[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]].credit;
        GlobalVariables.point += EnemySettings.eset[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]].point; //���тɂ��X�΂��܂����Ă��Ȃ�

        GlobalVariables.GPA = GlobalVariables.GPT / GlobalVariables.credit;
        GlobalVariables.enter_times[GlobalVariables.building]++;

        SceneManager.LoadScene(GlobalVariables.beforeScene);
    }
}