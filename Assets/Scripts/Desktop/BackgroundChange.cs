using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class BackgroundChange : MonoBehaviour
{
    public MsgVariables inkObserver;
    
    public Sprite sourcePhoto0;
    public Sprite sourcePhoto1;
    public Sprite sourcePhoto2;
    public Sprite sourcePhoto3;
    public Sprite sourcePhoto4;
    public Sprite sourcePhoto5;
    public Sprite sourcePhoto6;
    public Sprite sourcePhoto7;
    public Sprite sourcePhoto8;
    public Sprite sourcePhoto9;

    void Awake()
    {
        GameObject inkObserverObject = GameObject.FindWithTag("InkObserver");
        inkObserver = inkObserverObject.GetComponent<MsgVariables>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Ink.Runtime.IntValue currentProgress = (Ink.Runtime.IntValue) inkObserver.GetVariableState("player_progression");

        int currentProgressInt = (int)currentProgress.value;

        switch (currentProgressInt)
        {
            case 0:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto0;
                break;
            case 1:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto1;
                break;
            case 2:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto2;
                break;
            case 3:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto3;
                break;
            case 4:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto4;
                break;
            case 5:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto5;
                break;
            case 6:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto6;
                break;
            case 7:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto7;
                break;
            case 8:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto8;
                break;
            case >= 9:
                this.gameObject.GetComponent<Image>().sprite = sourcePhoto9;
                break;
            default:
                Debug.LogWarning("Background change not handled by switch statement: " + currentProgressInt);
                break;
        }
    }
}
