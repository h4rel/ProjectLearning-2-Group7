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

        for(int i = 0; i < 4; i++)
        {
            if (GlobalVariables.id[i,GlobalVariables.enter_times[i]] >= 0)
            {
                break;
            }

            if (i == 3)
            {
                // �w�N���オ�����Ƃ��̏���
                for (int j = 0; j < 4; j++)
                {
                    GlobalVariables.enter_times[i]++;
                }
                GlobalVariables.maxHP += 20;
                GlobalVariables.ATK += 10;
                GlobalVariables.grade++;

            }
        }


        SceneManager.LoadScene(GlobalVariables.beforeScene);
    }
}