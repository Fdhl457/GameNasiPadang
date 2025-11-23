using UnityEngine;
using UnityEngine.UI;

public class SlidePanel : MonoBehaviour
{
    public RectTransform panel;
    public float hideAmount = 280f;
    public float slideSpeed = 10f;
    private bool isOpen = true;

    private Vector2 openPos;
    private Vector2 closedPos;

    void Start()
    {
        openPos = Vector2.zero;
        closedPos = new Vector2(hideAmount, 0);
        panel.anchoredPosition = openPos;
    }

    public void TogglePanel()
    {
        StopAllCoroutines();
        StartCoroutine(Slide(isOpen ? closedPos : openPos));
        isOpen = !isOpen;
    }

    System.Collections.IEnumerator Slide(Vector2 target)
    {
        while (Vector2.Distance(panel.anchoredPosition, target) > 0.1f)
        {
            panel.anchoredPosition = Vector2.Lerp(panel.anchoredPosition, target, Time.deltaTime * slideSpeed);
            yield return null;
        }
        panel.anchoredPosition = target;
    }
}
