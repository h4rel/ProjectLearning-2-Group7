using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GradeUp : MonoBehaviour
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
        SceneManager.LoadScene(GlobalVariables.beforeScene);
    }
}
