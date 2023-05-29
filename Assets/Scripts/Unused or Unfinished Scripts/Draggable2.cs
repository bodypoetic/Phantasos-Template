using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Draggable2 : MonoBehaviour, IDragHandler
{
    private RectTransform myRectTransform;
    private Vector2 guiSizeHalf;
    public Vector2 screenSize;
    private Vector2 targetRes;// Set this to whatever your target resolution is.
    private Vector2 screenReciprocal;

    void Start()
    {
        myRectTransform = (RectTransform)transform;
        DefineScreenValues();
    }

    //Here we define values about the screen for use in some calculation later on.
    void DefineScreenValues()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        screenReciprocal = new Vector2(1 / screenSize.x, 1 / screenSize.y);
        targetRes = new Vector2(800.0f, 600.0f);
        guiSizeHalf = new Vector2(myRectTransform.rect.width * 0.5f, myRectTransform.rect.height * 0.5f);
    }

    //Here we determine what happens when the mouse/finger starts moving while pressing down on the gameobject.
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = Vector3.zero;

        int deltaX = (int)((eventData.position.x - screenSize.x * 0.5f) * targetRes.x * screenReciprocal.x);
        deltaX = (int)(Mathf.Clamp(deltaX, (-targetRes.x * 0.5f + guiSizeHalf.x), (targetRes.x * 0.5f - guiSizeHalf.x)));
        newPos.x = deltaX;// deltaX value is assigned to newPos.x

        int deltaY = (int)((eventData.position.y - screenSize.y * 0.5f) * targetRes.y * screenReciprocal.y);
        deltaY = (int)Mathf.Clamp(deltaY, (-targetRes.y * 0.5f + guiSizeHalf.y), (targetRes.y * 0.5f - guiSizeHalf.y));
        newPos.y = deltaY;// deltaY value is assigned to newPos.y

        //The position of the dragged object is defined.
        myRectTransform.anchoredPosition = new Vector3(newPos.x, newPos.y, newPos.z);
    }
}
