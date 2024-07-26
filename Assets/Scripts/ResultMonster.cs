using UnityEngine;
using UnityEngine.UI;

public class ResultMonster : MonoBehaviour
{
    // 評価用の画像を保持する配列
    public Sprite[] ratingSprites;

    // Imageコンポーネント
    private Image resultImage;

    void Start()
    {
        // PanelにアタッチされているImageコンポーネントを取得
        resultImage = GetComponent<Image>();
        int mimg;
        switch (GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]])
        {
            case 0: mimg = 0; break;
            case 1: mimg = 1; break;
            case 2: mimg = 2; break;
            case 3: mimg = 2; break;
            case 4: mimg = 3; break;
            case 5: mimg = 4; break;
            case 6: mimg = 5; break;
            case 7: mimg = 6; break;
            case 8: mimg = 6; break;
            case 9: mimg = 7; break;
            case 10: mimg = 8; break;
            case 11: mimg = 8; break;
            case 12: mimg = 9; break;
            default: mimg = 0; break;
        }
        SetResultImage(mimg*5+GlobalVariables.battleresult);
    }

    // 評価に応じて画像を設定するメソッド
    public void SetResultImage(int rating)
    {
        // 評価が有効範囲内かチェック
        if (rating >= 0 && rating < ratingSprites.Length)
        {
            resultImage.sprite = ratingSprites[rating];
        }
        else
        {
            Debug.LogWarning("Invalid rating value.");
        }
    }
}

// ゲームの評価が決まったら、ResultPanelControllerのSetResultImageメソッドを呼び出して画像を設定する
// 例↓(シーン内で参照を保持している場合)
// ResultMonster resultPanel = FindObjectOfType<ResultPanelController>();
// 評価に応じて画像を設定
// resultPanel.SetResultImage(3);