using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterBattle : MonoBehaviour
{

    public string targetObjectName;
    public string nowscene;
    [SerializeField] int building_num;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == targetObjectName)
        {
            // ��ʑJ�ڂ̕����̕ۑ�
            GlobalVariables.dir = "enter";
            GlobalVariables.building = building_num;
            GlobalVariables.beforeScene = nowscene;

            // �V�[����؂芷����
            SceneManager.LoadScene("Multi_CommandBattle");

        }
    }
}
