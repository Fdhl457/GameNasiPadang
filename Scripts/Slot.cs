using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    public int maxCount = 0; // 0 = unlimited

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;

        Transform dragged = eventData.pointerDrag.transform;

        if (maxCount > 0 && transform.childCount >= maxCount)
        {
            return;
        }

        dragged.SetParent(transform, false);
        dragged.SetAsLastSibling();
    }
}
