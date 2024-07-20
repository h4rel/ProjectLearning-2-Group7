using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyName : MonoBehaviour
{
    [SerializeField] Text tx;
    // Start is called before the first frame update
    void Start()
    {
        tx.text = EnemySettings.eset[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]].e_name;
    }

}
