using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePrinter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Text tx;
    void Start()
    {
        tx.text = "GPA : " + GlobalVariables.GPA.ToString("F2") + "    Score : " + GlobalVariables.score.ToString("F2");
    }
}
