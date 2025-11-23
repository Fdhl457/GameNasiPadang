using UnityEngine;

public class ResetItem : MonoBehaviour
{
    private Vector3 startPos;
    private Transform startParent;

    void Start()
    {
        startPos = transform.position;
        startParent = transform.parent;
    }

    public void ResetItemPosition()
    {
        transform.SetParent(startParent);
        transform.position = startPos;
    }
}
