using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// �V�[���؂�ւ��ɕK�v

// �^�b�`����ƁA�V�[����؂芷����
public class ExitBattle : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene(GlobalVariables.beforeScene);
    }
}