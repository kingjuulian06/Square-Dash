using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public int direction = 1;
    public float moveSpeed = 5;
    public float deadZone = -15;
    public BlockScript player;
    public LogicScript logic;
    private string name;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        name = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsAlive&&!logic.IsFreezed) {
            transform.position = transform.position + (Vector3.left * moveSpeed * direction) * Time.deltaTime;
        }

        if(transform.position.x<deadZone){
            Debug.Log(name + " Deleted");          // Name of the Object
            Destroy(gameObject);
        }
    }
}
