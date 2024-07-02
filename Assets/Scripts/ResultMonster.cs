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