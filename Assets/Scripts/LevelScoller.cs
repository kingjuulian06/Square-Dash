using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScoller : MonoBehaviour
{
    RectTransform myRectTransform;
    public int i = 0;

    private void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
    }
    public void LeftClick()
    {
        if (i==0) {}
        else {
            myRectTransform.localPosition += Vector3.right * 1500;
            i -= 1;
        }
    }

    public void RightClick()
    {
        if (i==4) {}
        else{
            myRectTransform.localPosition += Vector3.left * 1500;
            i += 1;
        }
    }
}
