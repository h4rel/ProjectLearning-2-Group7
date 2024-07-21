using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInit : MonoBehaviour
{
    [SerializeField] private List<GameObject> objs;
    void Start()
    {
        GlobalVariables.shopselect = -1;
        foreach (GameObject obj in objs) {
            obj.SetActive(false);
        }
    }

}
