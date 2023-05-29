using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FolderNav : MonoBehaviour
{
    public Transform fullWindow;
    public Transform folderParent;
    public string folderName = "Jules";
    public GameObject folderNameObject;

    public string folderAbove;

    public string folderRouteFirst;
    public string folderRoute;
    public TextMeshProUGUI folderRouteText;

    public string folderRouteFull;
    public string folderRouteBack;

    public bool shortenFilePath = false;
  
    public void SwitchFolder(string folderName)
    {
        folderAbove = GameObject.FindWithTag("Folder").name;

        folderNameObject = folderParent.transform.Find(folderName).gameObject;

        if (folderNameObject == null)
        {
            UnityEngine.Debug.LogError("SwitchFolder could not find folder with name: " + folderName);
        }

        foreach (Transform child in folderParent)
        {
            if (child.tag == "Folder")
            {
                child.gameObject.SetActive(false);
            }
        }

        folderNameObject.SetActive(true);

        if (folderName == "0")
        {
            folderRouteFirst = "C:\\Users\\";
        }

        else if ((folderName != "0") && (shortenFilePath == false))
        {
            folderRouteFirst = "C:\\Users\\PC\\";
        }

        else if ((folderName != "0") && (shortenFilePath == true))
        {
            folderRouteFirst = "C:\\Users\\...\\";
        }

        if (folderName != "PhotoZoom")
        {
            folderRouteFull = string.Concat(folderRouteFirst, folderName);
            folderRouteText.text = folderRouteFull;
        }
        
        fullWindow.SetAsLastSibling();
        shortenFilePath = false;
    }

    public void FolderBack()
    {
        GameObject folderAboveObject = folderParent.transform.Find(folderAbove).gameObject;
        UnityEngine.Debug.Log("folderAboveObject = " +  folderAboveObject.name);

        if (folderAboveObject != null )
        {
            foreach (Transform child in folderParent)
            {
                if (child.tag == "Folder")
                {
                    child.gameObject.SetActive(false);
                }
            }

            folderAboveObject.gameObject.SetActive(true);

            if (folderAboveObject.name == "0")
            {
                folderRouteFirst = "C:\\Users\\";
            }

            else
            {
                folderRouteFirst = "C:\\Users\\PC\\";
            }

            if (folderAboveObject.name == "PhotoZoom")
            {
                folderRouteBack = string.Concat(folderRouteFirst, folderName);
            }

            else
            {
                folderRouteBack = string.Concat(folderRouteFirst, folderAbove);
            }

            folderRouteText.text = folderRouteBack;

            folderAbove = GameObject.FindWithTag("Folder").name;

            fullWindow.SetAsLastSibling();
        }

        else
        {
            SwitchFolder("0");
        }

        shortenFilePath = false;
    }

    public void SetShortenFilePathTrue()
    {
        shortenFilePath = true;
    }
}
