using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button_SwitchScene : MonoBehaviour
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
        // 指定したシーンに遷移します
        SceneManager.LoadScene(sceneName);
    }
}
