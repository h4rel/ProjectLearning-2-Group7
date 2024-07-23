using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Revenge : MonoBehaviour
{
    // 遷移先のシーン名を指定します
    public string sceneName;

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
            SceneManager.LoadScene("Multi_CommandBattle");
        }
        else
        {
            SceneManager.LoadScene("DroppedOut");
        }
    }
}
