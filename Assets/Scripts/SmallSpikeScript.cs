using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpikeScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -15;
    public BlockScript player;

    public LogicScript logic;
    public MovementScript movement;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        movement = GameObject.FindGameObjectWithTag("Level").GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsAlive&&!logic.IsFreezed) {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if(transform.position.x<deadZone){
            Debug.Log("Small Spike Deleted");          // Name of the Object
            Destroy(gameObject);
        }
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
