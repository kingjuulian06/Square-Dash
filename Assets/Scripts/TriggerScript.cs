using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject m_player;
    public Transform safeBoden;
    private float moveSpeed = 5;
    private float deadZone = -15;
    public LogicScript logic;
    public Transform cam;
    public Transform bg;
    private BlockScript player_script;
    private Transform player_transform;

    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        player_script = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
        player_transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        safeBoden = GameObject.Find("Safe_Boden").GetComponent<Transform>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        bg = GameObject.FindGameObjectWithTag("Background").GetComponent<Transform>();
    }

    void Update()
    {
        if (player_script.IsAlive&&!logic.IsFreezed) {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if(transform.position.x<deadZone){
            Debug.Log("Block Deleted");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
            if (collider.gameObject.CompareTag("Player"))
            {
                cam.position += new Vector3(0, -10, 0);
                safeBoden.position += new Vector3(0, -10, 0);
                bg.position += new Vector3(0, -10, 0);
                player_transform.position += new Vector3(0, -10, 0);
                Debug.LogError("Erkannt");
            }
        }
}
