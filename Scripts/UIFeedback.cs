using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIFeedback : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text text;
    public Image bg;

    public void Show(string message, bool ok)
    {
        if (panel == null) return;
        panel.SetActive(true);
        if (text != null) text.text = message;
        if (bg != null) bg.color = ok ? new Color(0,1,0,0.8f) : new Color(1,0,0,0.8f);
        CancelInvoke(nameof(Hide));
        Invoke(nameof(Hide), 1.8f);
    }
    void Hide() => panel.SetActive(false);
}
