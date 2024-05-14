using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public MovementScript movement;
    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Level").GetComponent<MovementScript>();
        m_transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collision with " + gameObject.name);
        if(col.gameObject.layer==30){
            if(movement.direction == col.gameObject.GetComponent<TriggerScript>().direction){
                Destroy(gameObject);
            }

        }
    }
}
