using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DesktopToggle : MonoBehaviour
{

    public GameObject Window;
    public GameObject ErrorMessage;

    public void ToggleWindow()
    {
        if (Window != null)
        {
            bool isActive = Window.activeSelf;

            if (isActive == false)
            {
                Window.SetActive(true);
                Window.transform.SetAsLastSibling();
            }

            if (isActive == true)
            {
                bool errorisActive = ErrorMessage.activeSelf;
                
                if(errorisActive == false)
                {
                    ErrorMessage.SetActive(true);
                    ErrorMessage.transform.SetAsLastSibling();
                }
                
                if(errorisActive == true)
                {
                    AudioSource audioSource = ErrorMessage.GetComponent<AudioSource>();
                    audioSource.Play();
                }

            }
        }
    }
}
