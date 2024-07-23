using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OK : MonoBehaviour
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
        if (GlobalVariables.life > 0)
        {
            SceneManager.LoadScene(GlobalVariables.beforeScene);
        }
        else
        {
            SceneManager.LoadScene("DroppedOut");
        }
    }
}
