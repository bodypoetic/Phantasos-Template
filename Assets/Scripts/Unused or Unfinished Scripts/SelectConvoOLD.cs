using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class SelectConvo : MonoBehaviour
{
    public GameObject MsgManager;
    public TextAsset convoJSON;
    public Transform msgParent;
    public Transform convoParent;
    public Transform convoButtonParent;
    public Transform convoButtonParentParent;

    public bool StoryInProgress;
    
    void Start()
    {
        StoryInProgress = false;
    }
    
    public void GiveJSON()
    {
        if(StoryInProgress == false)
        {
            MsgManager.GetComponent<MsgManager>().inkStory = new Story(convoJSON.text);
        }

        else if (StoryInProgress == true)
        {
            //MsgManager.GetComponent<MsgManager>().SaveStory();
            MsgManager.GetComponent<MsgManager>().InkJSONAsset = convoJSON;
        }

        ClearMsgHistory();
        
        MsgManager.GetComponent<MsgManager>().messageParent = msgParent;
        MsgManager.GetComponent<MsgManager>().buttonParent = convoButtonParent;

        msgParent.gameObject.SetActive(true);
        convoButtonParent.gameObject.SetActive(true);

        MsgManager.GetComponent<MsgManager>().LoadTextAndWeave();
        // MsgManager.GetComponent<MsgManager>().CreateChoiceButtons();

        StoryInProgress = true;
    }

    public void ClearMsgHistory()
    {
        foreach (Transform child in convoParent)
        {
            if (child.tag == "Convo")
            {
                child.gameObject.SetActive(false);
            }
        }
        
        foreach (Transform child in convoButtonParentParent)
        {
            child.gameObject.SetActive(false);
        }

        // MsgManager.GetComponent<MsgManager>().DestroyButtonChildren();
    }
}
