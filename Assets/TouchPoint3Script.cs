using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint3Script : MonoBehaviour
{
    public bool IsTouching3 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsTouching3 = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 6) {
            IsTouching3 = true;
        }
    }
}
