using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TopBarDrag : EventTrigger
{

    private RectTransform WindowTopBar;
    private RectTransform WindowContainer;
    private RectTransform DragHandle;
    private bool dragging;

    public void Awake()
    {
        WindowTopBar = transform.parent.GetComponent<RectTransform>();
        WindowContainer = WindowTopBar.transform.parent.GetComponent<RectTransform>();
        DragHandle = WindowContainer.transform.parent.GetComponent<RectTransform>();
    }

    public void Update()
    {
        if (dragging)
        {
            DragHandle.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
