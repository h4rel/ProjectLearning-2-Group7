using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyWeapon : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] PointChanger pc;
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
        if (GlobalVariables.weapon[GlobalVariables.shopselect] == 0 && GlobalVariables.weaponPrice[GlobalVariables.shopselect] <= GlobalVariables.point)
        {
            GlobalVariables.point -= GlobalVariables.weaponPrice[GlobalVariables.shopselect];
            GlobalVariables.weapon[GlobalVariables.shopselect] = 1;
            this.gameObject.SetActive(false);
            obj.SetActive(true);
            pc.change();
        }
    }
}
