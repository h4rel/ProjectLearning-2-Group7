using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Switch : MonoBehaviour
{
    public Button initialButton;  // 初期のボタンをInspectorから設定
    public Button replacementButton;  // 置き換えのボタンをInspectorから設定

    void Start()
    {
        if (initialButton != null && replacementButton != null)
        {
            // 最初に置き換えボタンを非表示にする
            replacementButton.gameObject.SetActive(false);

            // 初期のボタンのクリックイベントを設定
            initialButton.onClick.AddListener(SwitchToReplacementButton);

            // 置き換えボタンのクリックイベントを設定
            replacementButton.onClick.AddListener(SwitchToInitialButton);
        }
    }

    void SwitchToReplacementButton()
    {
        // 初期のボタンを非表示にし、置き換えボタンを表示する
        initialButton.gameObject.SetActive(false);
        replacementButton.gameObject.SetActive(true);
    }

    void SwitchToInitialButton()
    {
        // 置き換えボタンを非表示にし、初期のボタンを表示する
        replacementButton.gameObject.SetActive(false);
        initialButton.gameObject.SetActive(true);
    }
}
