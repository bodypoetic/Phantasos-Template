using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform limit;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public Transform target;
    public RectTransform topbar;

    private bool isMouseDown = false;
    private Vector3 startMousePosition;
    private Vector3 startPosition;
    public bool shouldReturn;

    // Use this for initialization
    void Start()
    {

    }

    public void OnPointerDown(PointerEventData dt)
    {
        isMouseDown = true;

        Debug.Log("Draggable Mouse Down");

        startPosition = target.position;
        startMousePosition = Input.mousePosition;

        target.transform.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData dt)
    {
        Debug.Log("Draggable mouse up");

        isMouseDown = false;

        if (shouldReturn)
        {
            target.position = startPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseDown)
        {
            Vector3[] limitcorners = new Vector3[4];
            limit.GetWorldCorners(limitcorners);

            Vector3[] topbarcorners = new Vector3[4];
            topbar.GetWorldCorners(topbarcorners);

            Vector3 offset0 = target.position - topbarcorners[0];
            Vector3 offset1 = target.position - topbarcorners[1];
            Vector3 offset2 = topbarcorners[2] - target.position;
            Vector3 offset3 = topbarcorners[3] - target.position;

            maxX = limitcorners[2].x - offset2.x;
            minX = limitcorners[0].x + offset0.x;
            maxY = limitcorners[1].y + offset1.y;
            minY = limitcorners[3].y - offset3.y;

            Vector3 currentPosition = Input.mousePosition;

            Vector3 diff = currentPosition - startMousePosition;

            Vector3 pos = startPosition + diff;
            
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            target.position = pos;
        }
    }
}
