using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public Slot[] slots;             // array slot
    public Transform itemParent;     // tempat item kembali saat reset
    public string[] answer = { "Nasi" };

    [Header("UI (Opsional)")]
    public TextMeshProUGUI feedbackText;

    public void ResetPuzzle()
    {
        foreach (Slot slot in slots)
        {
            for (int i = slot.transform.childCount - 1; i >= 0; i--)
            {
                Transform item = slot.transform.GetChild(i);

                if (item.CompareTag("Item"))
                {
                    item.SetParent(itemParent, false);
                    item.localPosition = Vector3.zero;

                    // kembalikan originalParent
                    DragDrop drag = item.GetComponent<DragDrop>();
                    if (drag != null)
                        drag.originalParent = itemParent;
                }
            }
        }

       
    }

    public void CheckCorrect()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            bool foundCorrect = false;

            for (int j = 0; j < slots[i].transform.childCount; j++)
            {
                if (slots[i].transform.GetChild(j).name == answer[i])
                {
                    foundCorrect = true;
                    break;
                }
            }

            if (!foundCorrect)
            {
                string salahNama = (slots[i].transform.childCount > 0)
                    ? slots[i].transform.GetChild(0).name
                    : "Kosong";

                ShowFeedback($"Alun batua lai", false);
                return;
            }
        }

        ShowFeedback("Lamak bana!", true);
    }

    private void ShowFeedback(string message, bool isCorrect)
    {
        Debug.Log(message);

        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = isCorrect ? Color.green : Color.red;
        }
    }
}
