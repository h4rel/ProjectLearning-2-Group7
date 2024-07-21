using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class SelectEquipment : MonoBehaviour
{
    [SerializeField] private Image now;
    [SerializeField] private int w_num;
    [SerializeField] private ShopWeaponRef Ref;

    [SerializeField] private List<Image> other;

    [SerializeField] private Material SelectMat;
    [SerializeField] private Material watchingMat;
    [SerializeField] private Material defaultmat;

    [SerializeField] private GameObject Buy;
    [SerializeField] private GameObject NoMoney;
    [SerializeField] private GameObject Already;

    private void Awake()
    {
        if (GlobalVariables.shopselect == w_num)
        {
            now.material = SelectMat;
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
        foreach (Image obj in other)
        {
            obj.material = defaultmat;
        }

        if (GlobalVariables.shopselect != w_num)
        {
            GlobalVariables.shopselect = w_num;
            now.material = SelectMat;
        }
        else
        {
            GlobalVariables.shopselect = -1;
            now.material = defaultmat;
        }
        Ref.change();

        if (GlobalVariables.shopselect == -1) return;

        if (GlobalVariables.weapon[GlobalVariables.shopselect] == 1)
        {
            Already.SetActive(true);
            Buy.SetActive(false);
            NoMoney.SetActive(false);
        }
        else if (GlobalVariables.weaponPrice[GlobalVariables.shopselect] > GlobalVariables.point)
        {
            Already.SetActive(false);
            Buy.SetActive(false);
            NoMoney.SetActive(true);
        }
        else
        {
            Already.SetActive(false);
            Buy.SetActive(true);
            NoMoney.SetActive(false);
        }
    }

}