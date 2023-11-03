using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float blockStrength;
    public bool IsAlive = true;
    public LogicScript  logic;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float speed;
    public bool IsFlying = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsFlying) {
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
        
        if(Input.GetKeyDown(KeyCode.Space) && IsAlive && !IsFlying) {
            IsFlying = true;
            myRigidbody.velocity = Vector2.up * blockStrength;
        }

        if (transform.position.y < -5) {
            logic.gameOver();
            IsAlive = false;
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer==7) {
            logic.gameOver();
            IsAlive = false;
        }

        if (collision.gameObject.layer==6) {
            IsFlying = false;
        }
    }

}
