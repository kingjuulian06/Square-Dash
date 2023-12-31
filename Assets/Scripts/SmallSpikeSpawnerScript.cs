using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpikeSpawnerScript : MonoBehaviour
{
    public GameObject Spike;
    public float spawnRate = 10;
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
        if (timer<spawnRate) {
            timer+=Time.deltaTime;
        }

        else {
            spawnSpike();
            timer=0;
            spawnRate = Random.Range(0, 10);
        }

        if (!player.IsAlive) {
            spawnRate = 10;
        }
    }

    void spawnSpike() {
        Instantiate(Spike, transform.position, transform.rotation);
    }


}
