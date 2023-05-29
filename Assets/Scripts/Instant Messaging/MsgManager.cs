using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MsgManager : MonoBehaviour
{
    // The commented out code depends upon ProudCookie's Timekeeper to function. If you download it, this is the function that should be placed in the JobScheduler:

    //public IEnumerator advanceStory(string jobDateTime, GameObject timeDateObject, MsgManager msgManager)
    //{
    //    TMPro.TextMeshProUGUI dateTimeText = timeDateObject.GetComponent<TMPro.TextMeshProUGUI>();

    //    yield return new WaitUntil
    //        (() => dateTimeText.text == jobDateTime);

    //    msgManager.LoadTextAndWeave();
    //    msgManager.transform.SetAsFirstSibling();

    //    if (msgManager.minutesToWait != 0)
    //    {
    //        GameObject msgManagerObject = msgManager.gameObject;
    //        msgManagerObject.GetComponent<AudioSource>().Play();
    //    }

    //    UnityEngine.Debug.Log("Job successfully ran.");
    //}

    public TextAsset InkJSONAsset;
    public GameObject prefabButton;
    public Transform buttonParent;
    public Transform messageParent;
    public Transform fullWindow;

    public AudioSource typingSource;

    // PC
    [SerializeField] public GameObject prefabMessageR_PC;

    // NPC 0
    [SerializeField] public GameObject prefabMessageL_NPC0;

    // NPC 1
    [SerializeField] public GameObject prefabMessageL_NPC1;

    // [SerializeField] public GameObject prefabTimestamp;
    public bool autoProgress;
    public bool noAudio;

    public Story inkStory;
    private TextMeshProUGUI currentLinesText;

    public List<string> speakerList;
    public List<string> alignList;
    public List<string> typeList;

    private const string SPEAKER_TAG = "speaker";
    private const string ALIGN_TAG = "align";
    private const string TYPE_TAG = "type";
    // private const string WAIT_TAG = "wait";

    // public GameObject timeDateObject;
    public MsgVariables inkObserver;
    //public TimeManager timeManager;
    // public JobScheduler jobScheduler;

    public GameObject notifObject;
    // public int minutesToWait;

    public TKIntegration tkIntegration;

    void Start()
    {
        typingSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        // tkIntegration = Camera.main.GetComponent<TKIntegration>();

        GameObject inkObserverObject = GameObject.FindWithTag("InkObserver");
        inkObserver = inkObserverObject.GetComponent<MsgVariables>();

        inkStory = new Story(InkJSONAsset.text);
        LoadTextAndWeave();
    }

    public void LoadTextAndWeave()
    {
        inkObserver.StartListening(inkStory);

        if (inkStory.canContinue)
        {
            UnityEngine.Debug.Log("Story can continue.");
            inkStory.Continue();

            UnityEngine.Debug.Log($"line has {inkStory.currentTags.Count} tags");

            foreach (string tag in inkStory.currentTags)
            {
                string[] splitTag = tag.Split(':');
                if (splitTag.Length != 2)
                {
                    UnityEngine.Debug.LogError("Tag could not be appropriately parsed: " + tag);
                }
                string tagKey = splitTag[0].Trim();
                string tagValue = splitTag[1].Trim();

                switch (tagKey)
                {
                    case ALIGN_TAG:
                        alignList.Add(tagValue);
                        break;
                    case SPEAKER_TAG:
                        speakerList.Add(tagValue);
                        break;
                    case TYPE_TAG:
                        typeList.Add(tagValue);
                        break;
                    //case WAIT_TAG:
                    //    int.TryParse(tagValue, out int tagInt);
                    //    string targetTime = timeManager.FutureDateFromMinutes(tagInt);
                    //    UnityEngine.Debug.Log("targetTime = " + targetTime);
                    //    tkIntegration.AdvanceStory(targetTime, timeDateObject, this);
                    //    break;
                    default:
                        UnityEngine.Debug.LogWarning("Tag came in but is not currently being handled: " + tag);
                        break;
                }

                UnityEngine.Debug.Log($"found key {tagKey} and value {tagValue}");
            }

            if (typeList.Contains("old") || typeList.Contains("Old"))
            {
                autoProgress = true;
                noAudio = true;
            }

            if ((speakerList.Contains("PC") || speakerList.Contains("pc")) && alignList.Contains("right"))
            {
                UnityEngine.Debug.Log("Identified right PC.");

                GameObject cloneMessageGameObjectR_PC = Instantiate(prefabMessageR_PC, messageParent);
                currentLinesText = cloneMessageGameObjectR_PC.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                currentLinesText.text = inkStory.currentText;

                notifObject.SetActive(true);

                if (noAudio == false)
                {
                    AudioSource notificationSource = cloneMessageGameObjectR_PC.GetComponent<AudioSource>();
                    notificationSource.Play();
                }

                else
                {
                    noAudio = false;
                }
            }

            else if ((speakerList.Contains("NPC0") || speakerList.Contains("npc0")) && alignList.Contains("left"))
            {
                UnityEngine.Debug.Log("Identified left NPC 0.");

                GameObject cloneMessageGameObjectL_NPC0 = Instantiate(prefabMessageL_NPC0, messageParent);
                currentLinesText = cloneMessageGameObjectL_NPC0.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                currentLinesText.text = inkStory.currentText;

                if (noAudio == false)
                {
                    AudioSource notificationSource = cloneMessageGameObjectL_NPC0.GetComponent<AudioSource>();
                    notificationSource.Play();
                }

                else
                {
                    noAudio = false;
                }
            }

            else if ((speakerList.Contains("NPC1") || speakerList.Contains("npc1")) && alignList.Contains("left"))
            {
                UnityEngine.Debug.Log("Identified left NPC 1.");

                GameObject cloneMessageGameObjectL_NPC1 = Instantiate(prefabMessageL_NPC0, messageParent);
                currentLinesText = cloneMessageGameObjectL_NPC1.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                currentLinesText.text = inkStory.currentText;

                if (noAudio == false)
                {
                    AudioSource notificationSource = cloneMessageGameObjectL_NPC1.GetComponent<AudioSource>();
                    notificationSource.Play();
                }

                else
                {
                    noAudio = false;
                }
            }

            //else if ((speakerList.Contains("Time") || speakerList.Contains("time")) && (typeList.Contains("old") || typeList.Contains("Old")))
            //{
            //    UnityEngine.Debug.Log("Identified timestamp.");
            //    GameObject cloneTimestampGameObject = Instantiate(prefabTimestamp, messageParent);
            //    currentLinesText = cloneTimestampGameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();

            //    currentLinesText.text = inkStory.currentText;

            //    autoProgress = true;
            //}

            //else if ((speakerList.Contains("Time") || speakerList.Contains("time")) && (typeList.Contains("new") || typeList.Contains("New")))
            //{
            //    UnityEngine.Debug.Log("Identified timestamp.");
            //    GameObject cloneTimestampGameObject = Instantiate(prefabTimestamp, messageParent);
            //    currentLinesText = cloneTimestampGameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();

            //    string timeText = timeDateObject.GetComponent<TMPro.TextMeshProUGUI>().text;
            //    currentLinesText.text = timeText;

            //    autoProgress = true;
            //}

            if (typeList.Contains("end") || typeList.Contains("End"))
            {
                SceneManager.LoadScene("");
            }

            speakerList.Clear();
            alignList.Clear();
            typeList.Clear();

            foreach (Choice c in inkStory.currentChoices)
            {
                GameObject cloneButtonGameObject = Instantiate(prefabButton, buttonParent);

                Button cloneButtonButton = cloneButtonGameObject.GetComponent<Button>();
                cloneButtonButton.onClick.AddListener(delegate
                {
                    inkStory.ChooseChoiceIndex(c.index);
                    DestroyButtonChildren();
                    LoadTextAndWeave();

                    fullWindow.SetAsLastSibling();
                    this.transform.SetAsFirstSibling();
                    notifObject.SetActive(false);
                });

                TMPro.TextMeshProUGUI cloneButtonText = cloneButtonButton.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                cloneButtonText.text = c.text;
            }

            if (autoProgress == true)
            {
                notifObject.SetActive(false);
                autoProgress = false;
                LoadTextAndWeave();
            }

            inkObserver.StopListening(inkStory);
        }
    }

    public void DestroyButtonChildren()
    {
        foreach (Transform child in buttonParent)
        {
            if (child.tag == "ButtonChoice")
            {
                UnityEngine.Debug.Log("Buttons destroyed.");
                GameObject.Destroy(child.gameObject);
            }
        }
    }
}
