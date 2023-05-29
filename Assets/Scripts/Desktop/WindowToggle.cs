using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.EventSystems;
using TMPro;

public class WindowToggle : MonoBehaviour
{
    public GameObject Window;
    public GameObject ErrorMessage;

    public GameObject prefabNotepad;
    public Transform desktopContainer;

    public Transform folderWindow;
    public Transform saveasWindow;
    public Button saveasButton;
    public Button cancelButton;

    [SerializeField] public TMP_InputField filenameText;
    [SerializeField] public GameObject prefabFileLink;

    public TextAsset textAsset;

    public void ToggleWindow()
    {
        if (Window != null)
        {

            if (Window.activeSelf)
            {
                Window.transform.SetAsLastSibling();
            }

            else
            {
                Window.SetActive(true);
                Window.transform.SetAsLastSibling();
            }

            AudioSource audioSource = Window.GetComponent<AudioSource>();
            audioSource.Play();
        }
    }

    public void CloseWindow()
    {
        if (Window != null)
        {
            AudioSource audioSource = Window.GetComponent<AudioSource>();
            audioSource.Play();

            Window.SetActive(false);
        }

        else
        {
            UnityEngine.Debug.LogWarning("Tried to close a window that was already closed.");
        }
    }

    public void DesktopToggle()
    {
        if (Window != null)
        {
            bool isActive = Window.activeSelf;

            if (isActive == false)
            {
                Window.SetActive(true);
                Window.transform.SetAsLastSibling();

                AudioSource audioSource = Window.GetComponent<AudioSource>();
                audioSource.Play();
            }

            else
            {
                bool errorisActive = ErrorMessage.activeSelf;

                if (errorisActive == false)
                {
                    ErrorMessage.SetActive(true);
                    ErrorMessage.transform.SetAsLastSibling();
                }

                if (errorisActive == true)
                {
                    AudioSource audioSource = ErrorMessage.GetComponent<AudioSource>();
                    audioSource.Play();
                }

            }
        }
    }

    public void NotepadToggle()
    {
        GameObject cloneNoteEditor = Instantiate(prefabNotepad, desktopContainer);

        NoteManager noteManager = cloneNoteEditor.GetComponentInChildren<NoteManager>();

        noteManager.folderWindow = folderWindow;
        noteManager.saveasWindow = saveasWindow;

        noteManager.filenameText = filenameText;
        noteManager.notepadText = cloneNoteEditor.GetComponentInChildren<TMP_InputField>();

        noteManager.prefabNoteEditor = prefabNotepad;
        noteManager.prefabFileLink = prefabFileLink;
        noteManager.desktopContainer = desktopContainer;

        saveasButton.onClick.AddListener(delegate
        {
            noteManager.OnSaveAsClick();
        });

        cancelButton.onClick.AddListener(delegate
        {
            noteManager.OnCancelClick();
        });

        cloneNoteEditor.GetComponentInChildren<Draggable>().limit = desktopContainer.GetComponent<RectTransform>();
    }

    public void OpenTextFile()
    {
        GameObject cloneNoteEditor = Instantiate(prefabNotepad, desktopContainer);

        NoteManager noteManager = cloneNoteEditor.GetComponentInChildren<NoteManager>();

        noteManager.timesSaved = 1;

        noteManager.folderWindow = folderWindow;
        // noteManager.saveasWindow = saveasWindow;

        // noteManager.filenameText = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        noteManager.notepadText = cloneNoteEditor.GetComponentInChildren<TMP_InputField>();

        noteManager.prefabNoteEditor = prefabNotepad;
        noteManager.prefabFileLink = prefabFileLink;
        noteManager.desktopContainer = desktopContainer;

        noteManager.notepadText.text = textAsset.ToString();

        TextMeshProUGUI filenameText = this.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        noteManager.savedFileName = filenameText.text;

        cloneNoteEditor.GetComponentInChildren<Draggable>().limit = desktopContainer.GetComponent<RectTransform>();
    }
}
