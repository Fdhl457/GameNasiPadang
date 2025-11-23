using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public StackManager stackManager;

    public void OnDrop(PointerEventData eventData)
    {
        var item = eventData.pointerDrag.GetComponent<DragDrop>();
        if (item != null)
        {
            stackManager.AddItem(item.gameObject);
        }
    }
}