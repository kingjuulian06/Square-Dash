using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpikeSpawnerScript : MonoBehaviour
{
    public GameObject Spike;
    public float spawnRate = 10;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void spawnSpike() {
        Instantiate(Spike, transform.position, transform.rotation);
    }


}
