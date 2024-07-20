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
            // ‰æ–Ê‘JˆÚ‚Ì•ûŒü‚Ì•Û‘¶
            GlobalVariables.dir = "enter";
            GlobalVariables.building = building_num;
            GlobalVariables.beforeScene = nowscene;

            // ƒV[ƒ“‚ğØ‚èŠ·‚¦‚é
            SceneManager.LoadScene("Multi_CommandBattle");

        }
    }
}
