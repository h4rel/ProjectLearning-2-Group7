using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick_ResumeGame : MonoBehaviour
{

    void OnMouseDown()
    {
        // ゲームを再開する
        Time.timeScale = 1;
    }
}
