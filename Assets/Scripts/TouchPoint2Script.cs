using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint2Script : MonoBehaviour
{
    public bool IsTouching2 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsTouching2 = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 6) {
            IsTouching2 = true;
        }
    }
}
