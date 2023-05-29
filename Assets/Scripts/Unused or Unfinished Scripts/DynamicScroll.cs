using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicScroll : MonoBehaviour
{
    [SerializeField]
    private Transform scrollviewContent;

    //[SerializeField]
    //private GameObject prefab;

    [SerializeField]
    private List<GameObject> convos;

    private void Start()
    {
        foreach (GameObject convo in convos)
        {
            GameObject newConvo = Instantiate(convo, scrollviewContent);
        }
    }
}
