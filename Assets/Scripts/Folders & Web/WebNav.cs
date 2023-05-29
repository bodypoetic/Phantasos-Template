using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WebNav : MonoBehaviour
{
    public Transform fullWindow;
    public Transform pageParent;
    public Transform tabParent;

    public string pageName = "https://en.wikipedia.org/wiki/Derealization";
    public GameObject pageObject;

    public string lastPage;

    public TextMeshProUGUI addressBarText;

    public string webAddressBack;

    public void SwitchPage(string pageName)
    {
        lastPage = GameObject.FindWithTag("Webpage").name;

        pageObject = pageParent.transform.Find(pageName).gameObject;

        if (pageObject == null)
        {
            UnityEngine.Debug.LogError("SwitchPage could not find webpage with name: " + pageName);
        }

        foreach (Transform child in pageParent)
        {
            if (child.tag == "Webpage")
            {
                child.gameObject.SetActive(false);
            }
        }

        ChangePageName(pageName);

        pageObject.SetActive(true);
        fullWindow.SetAsLastSibling();
    }

    public void SwitchTab(string tabName)
    {
        foreach (Transform child in tabParent)
        {
            if (child.tag == "Tab")
            {
                child.GetComponent<Image>().color = new Color(0.5960785f, 0.5960785f, 0.5960785f, 1f);
            }
        }

        Transform currentTab = GameObject.Find(tabName).transform;

        if (tabName != "Error")
        {
            currentTab.GetComponent<Image>().color = new Color(1f, 0.654902f, 0f, 1f);
            currentTab.gameObject.SetActive(true);
        }

        currentTab.SetAsFirstSibling();
    }

    public void ChangePageName(string pageName)
    {
        if (pageName == "Error")
        {
            addressBarText.text = "www.ERRORCODE.000";
        }

        if (pageName == "Derealization")
        {
            addressBarText.text = "www.wikipedia.org/wiki/Derealization";
        }

        if (pageName == "TY")
        {
            addressBarText.text = "www.wikipedia.org/wiki/Transcendental_Youth";
        }

        if (pageName == "Nuclear")
        {
            addressBarText.text = "www.wikipedia.org/wiki/Long-term_nuclear_waste_warning_messages";
        }

        if (pageName == "Tulpa")
        {
            addressBarText.text = "www.wikipedia.org/wiki/Tulpa";
        }
    }

    public void PageBack()
    {
        GameObject lastPageObject = pageParent.transform.Find(lastPage).gameObject;
        UnityEngine.Debug.Log("lastPageObject = " + lastPageObject.name);

        SwitchPage(lastPageObject.name);
        SwitchTab(lastPageObject.name);
        ChangePageName(lastPageObject.name);

        lastPage = GameObject.FindWithTag("Webpage").name;

        fullWindow.SetAsLastSibling();

        if (lastPageObject = null)
        {
            SwitchPage("Error");
            SwitchTab("Error");
            ChangePageName("Error");
        }
    }
}
