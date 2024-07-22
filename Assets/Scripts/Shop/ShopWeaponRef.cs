using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopWeaponRef : MonoBehaviour
{
    private static string[] weapon = new string[] { "", "Logical   ATK +5", "Accuracy   ATK +7", "Knowledgeble   ATK +11", "Punctual   ATK +15" };
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.SetText(weapon[GlobalVariables.shopselect + 1]);
    }

    public void change()
    {
        text.SetText(weapon[GlobalVariables.shopselect + 1]);
    }
}