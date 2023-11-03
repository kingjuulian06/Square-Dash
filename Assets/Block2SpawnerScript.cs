using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block2SpawnerScript : MonoBehaviour
{

    public GameObject Block;
    public float spawnRate = 4;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
        Instantiate(Block, transform.position, transform.rotation);
    }
}
