using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity_Reverse_Portal_Script : MonoBehaviour
{
    //0 means from right to false
    //1 means from false to right
    public int direction;
    public MovementScript movement;
    
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Level").GetComponent<MovementScript>();
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

