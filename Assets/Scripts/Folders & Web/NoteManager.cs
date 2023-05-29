using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Text;

public class NoteManager : MonoBehaviour
{
    [SerializeField] public TMP_InputField notepadText;
    [SerializeField] public TMP_InputField filenameText;

    public GameObject notepadWindow;

    public Transform folderWindow;
    public Transform saveasWindow;

    public int timesSaved;

    string textFile;
    string fileName;

    public string savedFileName;
    public string rootfilePath;

    [SerializeField] public GameObject prefabFileLink;
    [SerializeField] public GameObject prefabNoteEditor;

    public Transform desktopContainer;

    public FolderNav folderNav;

    public void Awake()
    {
        timesSaved = 0;
        rootfilePath = Application.persistentDataPath;
    }
    
    public void OnSaveClick()
    {
        // Check whether JSON file has already been created.
        
        if (timesSaved == 0)
        {
            SaveFileAs();
        }

        else
        {
            SaveToFile(notepadText.text, savedFileName);
        }
    }

    public void SaveFileAs()
    {
        // notepadWindow.SetActive(false);
        
        // Make Save As Window active
        folderWindow.gameObject.SetActive(true);
        saveasWindow.gameObject.SetActive(true);
        folderWindow.SetAsLastSibling();
    }

    public void OnSaveAsClick()
    {
        Transform currentFolder = GameObject.FindWithTag("Folder").transform;

        savedFileName = filenameText.text;
        // TextAsset textFile = SaveToFile(notepadText.text, savedFileName);

        timesSaved = timesSaved + 1;

        //instantiate link to open file in the relevant file location
        GameObject clonePrefab = Instantiate(prefabFileLink, currentFolder);
        clonePrefab.SetActive(true);

        TMPro.TextMeshProUGUI cloneFileLabel = clonePrefab.GetComponentInChildren<TMPro.TextMeshProUGUI>();
        cloneFileLabel.text = filenameText.text;

        Button clonePrefabButton = clonePrefab.GetComponent<Button>();
        clonePrefabButton.onClick.AddListener(delegate
        {
            GameObject cloneNoteEditor = Instantiate(prefabNoteEditor, desktopContainer);

            cloneNoteEditor.GetComponentInChildren<Draggable>().limit = desktopContainer.GetComponent<RectTransform>();
            
            TMP_InputField cloneNoteEditorInput = cloneNoteEditor.GetComponentInChildren<TMPro.TMP_InputField>();

            string path = rootfilePath + "/" + savedFileName + ".txt";
            cloneNoteEditorInput.text = File.ReadAllText(path);
        });

        SaveToFile(notepadText.text, savedFileName);
        timesSaved = timesSaved + 1;

        // Make Save As Window inactive
        filenameText.text = "";
        saveasWindow.gameObject.SetActive(false);
        folderWindow.gameObject.SetActive(false);
    }

    public void OnCancelClick()
    {
        // Make Save As Window inactive
        saveasWindow.gameObject.SetActive(false);
        folderWindow.gameObject.SetActive(false);
    }

    public void SaveToFile(string textToSave, string fileName)
    {
        string path = rootfilePath + "/" + fileName + ".txt";
        File.WriteAllText(path, textToSave);
        timesSaved = timesSaved + 1;
    }
}
