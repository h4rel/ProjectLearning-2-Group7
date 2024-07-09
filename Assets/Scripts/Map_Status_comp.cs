using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_Status_comp : MonoBehaviour
{
    [SerializeField] private List<Button> buttons;
    bool q = true;

    // Update is called once per frame
    void Update()
    {
        if (q)
        {
            foreach (Button b in buttons)
            {
                if (!b.IsActive())
                {
                    q = false;
                    inactive();

                }
            }
        }
        else
        {
            foreach (Button b in buttons)
            {
                if (b.IsActive())
                {
                    q = true;
                    active();
                }
            }
        }
    }

    void active()
    {
        foreach (Button b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    void inactive()
    {
        foreach (Button b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }
}
