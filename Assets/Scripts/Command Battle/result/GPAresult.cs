using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPAresult : MonoBehaviour
{
    [SerializeField] private Text tx;
    // Start is called before the first frame update
    void Start()
    {
        tx.text = GlobalVariables.GPA.ToString("F2") + "Å®" + ((GlobalVariables.GPT + GlobalVariables.GP[GlobalVariables.battleresult]* EnemySettings.eset[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]].credit) / (GlobalVariables.credit + EnemySettings.eset[GlobalVariables.id[GlobalVariables.building, GlobalVariables.enter_times[GlobalVariables.building]]].credit)).ToString("F2");
    }
}
