using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpikeScript : MonoBehaviour
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
        if (player.IsAlive||!logic.IsFreezed) {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if(transform.position.x<deadZone){
            Debug.Log("Spike Deleted");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer==7) {
            Debug.Log("Spike destroyed cause of Overlapping!");
            Destroy(gameObject);
        }
    }
}
