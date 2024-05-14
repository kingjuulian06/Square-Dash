using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject m_player;
    public Transform safeBoden;
    public LogicScript logic;
    public Transform cam;
    public Transform bg;
    private MovementScript movementScript;
    private Transform player_transform;
    [field: SerializeField]
    public int direction;
    public MovementScript thisScript1;
    public MovementScript thisScript2;


    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        movementScript = GameObject.FindGameObjectWithTag("Level").GetComponent<MovementScript>();
        player_transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        safeBoden = GameObject.Find("Safe_Boden").GetComponent<Transform>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        bg = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();
        thisScript1 = GameObject.Find("Trigger_01").GetComponent<MovementScript>();
        thisScript2 = GameObject.Find("Trigger_02").GetComponent<MovementScript>();
        if(gameObject.name == "Trigger_01"){
            direction = 1;
        }
        else if(gameObject.name == "Trigger_02"){
            direction = -1;
        }
    }

    void Update () {
        if(movementScript.direction==1){
            thisScript1.direction = -1;
            thisScript2.direction = -1;
        }
        else if(movementScript.direction==-1){
           thisScript1.direction = 1;
           thisScript2.direction = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("Collision with " + collider.gameObject.name);
    }
}
