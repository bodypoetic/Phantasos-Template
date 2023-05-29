using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeConvo : MonoBehaviour
{
    public Transform fullWindow;
    public Transform msgParent;
    public Transform msgParentParent;
    public Transform convoButtonParent;
    public Transform convoButtonParentParent;

    public void SwitchConvo()
    {
        foreach (Transform child in msgParentParent)
        {
            if (child.tag == "Convo")
            {
                child.gameObject.SetActive(false);
            }
        }

        foreach (Transform child in convoButtonParentParent)
        {
            if (child.tag == "Convo")
            {
                child.gameObject.SetActive(false);
            }
        }

        msgParent.gameObject.SetActive(true);
        convoButtonParent.gameObject.SetActive(true);
        fullWindow.SetAsLastSibling();
    }
}
