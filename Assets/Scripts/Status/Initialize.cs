using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> objs;

    void Start()
    {
        foreach (GameObject obj in objs)
        {
            obj.SetActive(false);
        }
    }
}