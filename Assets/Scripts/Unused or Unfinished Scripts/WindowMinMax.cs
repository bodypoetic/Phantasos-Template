using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowMinMax : MonoBehaviour
{
    public RectTransform Window;
    public bool isMax;

    public RectTransform TargetMax;
    public RectTransform TargetMin;

    public Vector2 MinSize;
    public Vector2 MaxSize;

    public GameObject Topbar;

    void Start()
    {
        isMax = false;

        MinSize.x = TargetMin.rect.width;
        MinSize.y = TargetMin.rect.height;

        MaxSize.x = TargetMax.rect.width;
        MaxSize.y = TargetMax.rect.height;
    }
    
    public void OnClick()
    {
        if (isMax == false)
        {
            Maximise();
        }

        else if (isMax == true)
        {
            Minimise();
        }

        if (isMax != false && isMax != true)
        {
            UnityEngine.Debug.LogWarning("variable isMax is neither true nor false");
        }
    }

    public void Minimise()
    {
        Window.sizeDelta = MinSize;

        Topbar.GetComponent<Draggable>().enabled = true;
        Topbar.GetComponent<Selectable>().enabled = true;

        isMax = false;
    }

    public void Maximise()
    {
        Window.sizeDelta = MaxSize;

        Window.position = TargetMax.position;

        Topbar.GetComponent<Draggable>().enabled = false;
        Topbar.GetComponent<Selectable>().enabled = false;

        isMax = true;
    }
}
