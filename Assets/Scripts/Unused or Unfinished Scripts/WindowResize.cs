using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WindowResize : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public RectTransform limit;
    public RectTransform topbar;

    public Vector2 minSize;
    public Vector2 maxSize;

    private RectTransform target;
    private Vector2 currentPointerPosition;
    private Vector2 previousPointerPosition;

    void Awake()
    {
        target = transform.parent.GetComponent<RectTransform>();
    }

    void Start()
    {
        maxSize = limit.rect.size;
    }

    public void OnPointerDown(PointerEventData data)
    {
        target.SetAsLastSibling();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(target, data.position, data.pressEventCamera, out previousPointerPosition);
    }

    public void OnDrag(PointerEventData data)
    {
        if (target == null)
            return;

        Vector2 sizeDelta = target.sizeDelta;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(target, data.position, data.pressEventCamera, out currentPointerPosition);
        Vector2 resizeValue = currentPointerPosition - previousPointerPosition;

        sizeDelta += new Vector2(resizeValue.x, -resizeValue.y);
        sizeDelta = new Vector2(
            Mathf.Clamp(sizeDelta.x, minSize.x, maxSize.x),
            Mathf.Clamp(sizeDelta.y, minSize.y, maxSize.y)
            );

        target.sizeDelta = sizeDelta;

        previousPointerPosition = currentPointerPosition;
    }
}
