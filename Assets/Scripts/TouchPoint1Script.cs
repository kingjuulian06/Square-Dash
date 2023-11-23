using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint1Script : MonoBehaviour
{
    public bool IsTouching1 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsTouching1 = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 6) {
            IsTouching1 = true;
        }
    }
}
