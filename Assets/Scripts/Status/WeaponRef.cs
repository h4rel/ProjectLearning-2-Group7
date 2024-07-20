using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponRef : MonoBehaviour
{
    private static string[] weapon = new string[] { "‚»‚¤‚Ñ‚È‚µ", "Logical   ATK +5", "Accuracy   ATK +10", "Knowledgeble   ATK +15", "Punctual   ATK +20" };
    [SerializeField] private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.SetText(weapon[GlobalVariables.hold + 1]);
    }

    public void change()
    {
        text.SetText(weapon[GlobalVariables.hold + 1]);
    }
}