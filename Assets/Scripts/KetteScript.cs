using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KetteScript : MonoBehaviour
{
    public MovementScript movement;
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Level").GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.layer==30){
            if(movement.direction == col.gameObject.GetComponent<TriggerScript>().direction){
                Destroy(gameObject);
            }

        }
    }
}
