using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// シーン切り替えに必要

// タッチすると、シーンを切り換える
public class ExitBattle : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene(GlobalVariables.beforeScene);
    }
}