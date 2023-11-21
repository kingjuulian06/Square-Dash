using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScoller : MonoBehaviour
{
    RectTransform myRectTransform;
    public int i;

    private void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
    }
    public void LeftClick()
    {
        myRectTransform.localPosition += Vector3.right * 1500;
        i -= 1;
    }

    public void RightClick()
    {
        myRectTransform.localPosition += Vector3.left * 1500;
        i += 1;
    }
}
