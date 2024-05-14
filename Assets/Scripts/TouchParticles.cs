using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchParticles : MonoBehaviour
{
    public Transform playerTransform;
    public Transform transform;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform = gameObject.transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position - new Vector3(0,1,0) / 5;
        
        //if(player.GetComponent<BlockScript>().IsFlying==true){
        //    gameObject.SetActive(false);
        //}

        //if(player.GetComponent<BlockScript>().IsFlying==false){
        //    gameObject.SetActive(true);
        //}
    }

    //void FixedUpdate() {
    //    if(player.GetComponent<BlockScript>().IsFlying==false){
    //        Debug.Log("Ich bin aktiv");
    //        gameObject.SetActive(true);
    //    }
    //}
}
