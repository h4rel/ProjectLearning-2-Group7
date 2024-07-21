using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DecideNOP : MonoBehaviour
{
    [SerializeField] private int nop;
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
        GlobalVariables.NOP = nop;
        GlobalVariables.init();
    }
}