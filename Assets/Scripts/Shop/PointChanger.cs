using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointChanger : MonoBehaviour
{
    [SerializeField] Text tx;
    // Start is called before the first frame update
    void Start()
    {
        tx.text = GlobalVariables.point.ToString();
    }

    public void change()
    {
        tx.text = GlobalVariables.point.ToString();
    }


}
