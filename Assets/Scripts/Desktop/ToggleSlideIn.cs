using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GogoGaga.TME;

public class ToggleSlideIn : MonoBehaviour
{
    public GameObject Window;
    public LeantweenCustomAnimator[] animationsArray;
    public bool isUp;

    public Transform desktopContainer;

    public void Start()
    {
        animationsArray = Window.GetComponents<LeantweenCustomAnimator>();
        isUp = false;
    }

    public void ToggleWindow()
    {
        if (isUp == true)
        {
            animationsArray[1].PlayAnimation();
            isUp = false;
        }

        else
        {
            Window.transform.SetAsLastSibling();
            animationsArray[0].PlayAnimation();
            isUp = true;
        }
    }

    public void MinimiseAllWindows()
    {
        foreach (Transform child in desktopContainer)
        {
            if (child.tag == "Window")
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
