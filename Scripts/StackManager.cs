using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public Transform stackParent;
    public float offsetY = 0f;

    private List<GameObject> stack = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        stack.Add(item);

        item.transform.SetParent(stackParent);

        RectTransform rt = item.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(0, stack.Count * offsetY);
    }
}