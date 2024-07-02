using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_ShowImages : MonoBehaviour
{
    public Button showButton;  // 表示するボタンをInspectorから設定
    public List<Image> targetImages;  // 表示したいイメージのリストをInspectorから設定

    void Start()
    {
        if (showButton != null && targetImages != null && targetImages.Count > 0)
        {
            showButton.onClick.AddListener(ShowImages);
            foreach (Image img in targetImages)
            {
                img.gameObject.SetActive(false);  // 最初はすべてのImageを非表示にする
            }
        }
    }

    void ShowImages()
    {
        foreach (Image img in targetImages)
        {
            img.gameObject.SetActive(true);  // ボタンがクリックされたらすべてのImageを表示する
        }
    }
}
