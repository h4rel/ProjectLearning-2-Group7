using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_HideImages : MonoBehaviour
{
    public Button hideButton;  // 非表示にするボタンをInspectorから設定
    public List<Image> targetImages;  // 非表示にしたいイメージのリストをInspectorから設定

    void Start()
    {
        if (hideButton != null && targetImages != null && targetImages.Count > 0)
        {
            hideButton.onClick.AddListener(HideImages);
        }
    }

    void HideImages()
    {
        foreach (Image img in targetImages)
        {
            img.gameObject.SetActive(false);  // ボタンがクリックされたらすべてのImageを非表示にする
        }
    }
}
