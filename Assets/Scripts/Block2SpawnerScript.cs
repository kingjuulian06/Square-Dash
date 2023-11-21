using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2SpawnerScript : MonoBehaviour
{

    public GameObject Block;
    public float spawnRate = 0;
    private float timer = 0;
    public BlockScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer<=spawnRate) {
            timer+=Time.deltaTime;
        }

        else {
            spawnBlock();
            timer = 0;
        }
    }

    void spawnBlock(){
        if (player.IsAlive) {
            Instantiate(Block, transform.position, transform.rotation);
        }
    }
}
