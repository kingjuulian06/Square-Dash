using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchParticles : MonoBehaviour
{
    public Transform playerTransform;
    public Transform transform;
    public BlockScript playerScript;

    // Start is called before the first frame 
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform = GetComponent<Transform>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position - new Vector3(0,1,0) / 5;        
    }

    //void FixedUpdate() {
    //    if(player.GetComponent<BlockScript>().IsFlying==false){
    //        Debug.Log("Ich bin aktiv");
    //        gameObject.SetActive(true);
    //    }
    //}
}
