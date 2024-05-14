using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolargeistScript : MonoBehaviour
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
            Debug.Log("Polargeist Deleted");          // Name of the Object
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer==3) {
            Debug.Log("Player On Me");    
        }

        if(collider.gameObject.layer==30){
            if(movement.direction == collider.gameObject.GetComponent<TriggerScript>().direction){
                Destroy(gameObject);
            }

        }
    }
}
