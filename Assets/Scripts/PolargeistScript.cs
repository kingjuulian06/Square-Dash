using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolargeistScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -15;
    public BlockScript player;

    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsAlive&&!logic.IsFreezed) {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if(transform.position.x<deadZone){
            Debug.Log("Block Deleted");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer==3) {
            Debug.Log("Player On Me");    
        }
    }
}
