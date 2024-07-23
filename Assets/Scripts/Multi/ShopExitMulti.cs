using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ShopExitMulti : MonoBehaviourPunCallbacks
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
            AvatarController.triggerId++;
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel("Field05SceneMulti");
        }
        
    }
}