using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopExit : MonoBehaviour
{

    void Start()
    {
        // �{�^���R���|�[�l���g���擾���A�N���b�N�C�x���g�Ƀ��X�i�[��ǉ����܂�
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    // �{�^�����N���b�N���ꂽ�Ƃ��̏���
    void OnButtonClick()
    {
        // �w�肵���V�[���ɑJ�ڂ��܂�
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