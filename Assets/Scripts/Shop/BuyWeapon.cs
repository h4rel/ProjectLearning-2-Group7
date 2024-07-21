using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuyWeapon : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] PointChanger pc;
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }
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
