using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool cloneOnDrag = true;
    public Transform originalParent;
    private RectTransform rt;
    private CanvasGroup cg;
    private Canvas canvas;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
        cg = GetComponent<CanvasGroup>();
        canvas = FindFirstObjectByType<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;

        if (cloneOnDrag)
        {
            GameObject clone = Instantiate(gameObject, originalParent);
            clone.name = gameObject.name; // keep name
            CanvasGroup cloneCg = clone.GetComponent<CanvasGroup>();
            if (cloneCg == null) {
                cloneCg = clone.AddComponent<CanvasGroup>();
            }
            DragDrop dd = clone.GetComponent<DragDrop>();
            if (dd == null) {
                dd = clone.AddComponent<DragDrop>();
                dd.cloneOnDrag = false;
            }// clones shouldn't clone themselves
        }

        transform.SetParent(canvas.transform, true);
        cg.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas == null) return;
        rt.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = true;

        if (transform.parent == canvas.transform)
        {
            transform.SetParent(originalParent, false);
            rt.anchoredPosition = Vector2.zero;
        }
    }

}
