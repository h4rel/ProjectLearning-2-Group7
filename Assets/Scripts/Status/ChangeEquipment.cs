using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class ChangeEquipment : MonoBehaviour
{
    [SerializeField] private Image now;
    [SerializeField] private int w_num;
    [SerializeField] private WeaponRef Ref;

    [SerializeField] private List<Image> other;

    [SerializeField] private Material SelectMat;
    [SerializeField] private Material watchingMat;
    [SerializeField] private Material defaultmat;

    [SerializeField] private Image inside;
    [SerializeField] private Material Monomat;

    private void Awake()
    {
        if (GlobalVariables.hold == w_num)
        {
            now.material = SelectMat;
        }
        if (GlobalVariables.weapon[w_num] == 0)
        {
            inside.material = Monomat;
        }
        else
        {
            inside.material = defaultmat;
        }
    }




    public void OnPointerEnter()
    {
        if (GlobalVariables.weapon[w_num] > 0)
        {
            if (now.material != SelectMat) now.material = watchingMat;
        }
    }

    public void OnPointerExit()
    {
        if (GlobalVariables.weapon[w_num] > 0)
        {
            if (now.material != SelectMat) now.material = defaultmat;
        }
    }

    public void OnPointerClick()
    {
        if (GlobalVariables.weapon[w_num] > 0)
        {
            foreach (Image obj in other)
            {
                obj.material = defaultmat;
            }

            if (GlobalVariables.hold != w_num)
            {
                GlobalVariables.hold = w_num;
                now.material = SelectMat;
            }
            else
            {
                GlobalVariables.hold = -1;
                now.material = defaultmat;
            }
            Ref.change();
        }
    }

}