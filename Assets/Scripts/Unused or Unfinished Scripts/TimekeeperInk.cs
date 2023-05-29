using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using Ink.Runtime;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;

public class TimekeeperInk : MonoBehaviour
{
    public GameObject jobManager;
    public GameObject DateTime;
    public string nextKnot;
    public TextAsset InkJSONAsset;

    // public TextMeshProUGUI DateTimeText;

    // Start is called before the first frame update
    void Start()
    {
        //JobScheduler jobScheduler = jobManager.GetComponent<JobScheduler>();
        //TimeManager timeManager = DateTime.GetComponent<TimeManager>();
        //TextMeshProUGUI DateTimeText = DateTime.GetComponent<TextMeshProUGUI>();
        //inkStory = new Story(InkJSONAsset.text);
    }

    //public void CheckStoryCanContinue()
    //{
    //    if (inkStory.canContinue)
    //    {
    //        StartCoroutine(jobScheduler.advanceStory(timeManager.FutureDateFromMinutes(5)), DateTimeText));
    //    }

    //    else
    //    {
    //        StartCoroutine((jobScheduler.advanceStory(timeManager.FutureDateFromMinutes(0)), DateTimeText)))
    //    }
    //}

    //public void GetNextKnot()
    //{
    //    knotList = GetAllKnotNames(InkJSONAsset);
    //    // Figure out where in the story the reader is.
    //    // Pick the next knot down.

    //    // Move the ink story to that knot.
    //    inkStory.ChoosePathString(nextKnot);
    //}

    //private static List<string> GetAllKnotNames(string json)
    //{
    //    List<string> keyList = new List<string>();
    //    JObject storyText = JObject.Parse(json);
    //    IList<JToken> results = storyText["root"]?.Children().ToList();
    //    if (results != null && results.Count >= 3)
    //    {
    //        Dictionary<string, object> knotDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(results[2].ToString());
    //        keyList = new List<string>(knotDictionary.Keys);
    //    }
    //    return keyList;
    //}
}
