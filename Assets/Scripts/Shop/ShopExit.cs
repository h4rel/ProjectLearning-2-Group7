using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopExit : MonoBehaviour
{

    void Start()
    {
        // ボタンコンポーネントを取得し、クリックイベントにリスナーを追加します
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    // ボタンがクリックされたときの処理
    void OnButtonClick()
    {
        // 指定したシーンに遷移します
        if (GlobalVariables.NOP == 1)
        {
            SceneManager.LoadScene("Field05Scene");
        }
        else
        {
            SceneManager.LoadScene("Field05SceneMulti");
        }
        
    }
}