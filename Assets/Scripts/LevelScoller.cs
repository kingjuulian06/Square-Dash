using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScoller : MonoBehaviour
{
    RectTransform myRectTransform;
<<<<<<< HEAD
    public int i = 0;
=======
    public int i;
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080

    private void Start()
    {
        myRectTransform = GetComponent<RectTransform>();
    }
    public void LeftClick()
    {
<<<<<<< HEAD
        if (i==0) {}
        else {
            myRectTransform.localPosition += Vector3.right * 1500;
            i -= 1;
        }
=======
        myRectTransform.localPosition += Vector3.right * 1500;
        i -= 1;
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
    }

    public void RightClick()
    {
<<<<<<< HEAD
        if (i==2) {}
        else{
            myRectTransform.localPosition += Vector3.left * 1500;
            i += 1;
        }
=======
        myRectTransform.localPosition += Vector3.left * 1500;
        i += 1;
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
    }
}
