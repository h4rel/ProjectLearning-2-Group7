using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using System.Text.RegularExpressions;

public class Sample1 : MonoBehaviour
{
    [SerializeField][TextArea(10,10)][InspectorTextArea()] private TMP_Text text; //対象のテキスト(Inspecterから指定)

    [SerializeField][TextArea(1,10)] private string s; //反映したい文字列(Inspecterから指定)

    public void Start()
    {
        text.SetText(s);
    }
}