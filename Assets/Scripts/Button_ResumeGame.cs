using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_ResumeGame : MonoBehaviour
{

    public Button resumeButton;

    void Start()
    {
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeGame);
        }
    }

    void ResumeGame()
    {
        // ゲームを再開する
        Time.timeScale = 1;
    }
}
