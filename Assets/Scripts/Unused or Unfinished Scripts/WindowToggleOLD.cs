using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowToggleOLD : MonoBehaviour
{
    public GameObject WindowContainer;
    public bool WindowisActive;

    public void Start()
    {
        bool WindowisActive = WindowContainer.activeSelf;
    }

    public void ToggleWindow()
    {
        if (WindowContainer != null)
        {
            WindowContainer.SetActive(!WindowisActive);
            WindowContainer.transform.SetAsLastSibling();
        }
    }

    public void CloseWindow()
    {
        if (WindowContainer != null)
        {
            WindowContainer.SetActive(false);
        }
    }
}
