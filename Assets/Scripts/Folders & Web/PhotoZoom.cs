using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotoZoom : MonoBehaviour
{
    [SerializeField] public bool hasGlitches;
    
    public GameObject currentFolder;
    public GameObject photoZoom;
    public GameObject photoEnlarged;
    public int timesClicked;
    public Transform fullWindow;

    public TextAsset photoMetadata0;
    public TextAsset photoMetadata1;
    public TextAsset photoMetadata2;

    public Sprite sourcePhoto0;
    public Sprite sourcePhoto1;
    public Sprite sourcePhoto2;
    public Sprite sourcePhoto3;
    public Sprite sourcePhoto4;
    public Sprite sourcePhoto5;
    public Sprite sourcePhoto6;

    private TextMeshProUGUI photoText;

    public MsgVariables msgVariables;
    public FolderNav folderNav;

    void Start()
    {
        timesClicked = 0;
    }

    public void enlargePhoto()
    {
        folderNav.folderAbove = GameObject.FindWithTag("Folder").name;

        folderNav.SwitchFolder("PhotoZoom");

        photoText = photoZoom.GetComponentInChildren<TextMeshProUGUI>();

        if (hasGlitches == true)
        {
            switch (timesClicked)
            {
                case 0:
                    photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto0;
                    photoText.text = photoMetadata0.text;
                    break;
                case 1:
                    photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto1;
                    photoText.text = photoMetadata0.text;
                    break;
                case 2:
                    photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto2;
                    photoText.text = photoMetadata1.text;
                    break;
                case 3:
                    photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto3;
                    photoText.text = photoMetadata1.text;
                    break;
                case 4:
                    photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto4;
                    photoText.text = photoMetadata1.text;
                    break;
                case 5:
                    photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto5;
                    photoText.text = photoMetadata1.text;
                    break;
                case 6:
                    photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto6;
                    photoText.text = photoMetadata1.text;
                    break;
                case 7:
                    photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto6;
                    photoText.text = photoMetadata2.text;
                    msgVariables.AddProgressCounter(1);
                    break;
                case >= 8:
                    photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto6;
                    photoText.text = photoMetadata2.text;
                    break;
                default:
                    Debug.LogWarning("Picture change not handled by switch statement: " + timesClicked);
                    break;
            }
            timesClicked++;
        }

        else
        {
            photoEnlarged.gameObject.GetComponent<Image>().sprite = sourcePhoto0;
            photoText.text = photoMetadata0.text;
        }

        Image sourcephotoPhoto = photoEnlarged.GetComponent<Image>();
        sourcephotoPhoto.preserveAspect = true;
    }

    public void unzoomPhoto()
    {
        photoZoom.SetActive(false);
    }
}
