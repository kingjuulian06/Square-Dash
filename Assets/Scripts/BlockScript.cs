using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockScript : MonoBehaviour
{

    public Vector2 velocity; 
    public Rigidbody2D myRigidbody;
    public float blockStrength;
    public bool IsAlive = true;
    public LogicScript  logic;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private float speed;
    public bool IsFlying = false;
    [SerializeField] private AudioSource JumpSound;
    [SerializeField] private AudioSource DieSound;

    public UnityEngine.RigidbodyConstraints2D constraints;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.IsFreezed) {
            myRigidbody.gravityScale = 2;
            myRigidbody.constraints = RigidbodyConstraints2D.None;
        }
        if (IsFlying && !logic.IsFreezed) {
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    
        if(Input.GetKeyDown(KeyCode.Space) && IsAlive && !IsFlying && !logic.IsFreezed) {
            logic.addJump();
            IsFlying = true;
            JumpSound.Play();
            myRigidbody.velocity = Vector2.up * blockStrength;
        }

        if(logic.IsFreezed) {
            velocity = myRigidbody.velocity;
            myRigidbody.velocity = Vector2.zero;
            myRigidbody.gravityScale = 0;
            myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer==7) {
            DieSound.Play();
            logic.gameOver();
            IsAlive = false;
            Destroy(gameObject);
        }

        if (collision.gameObject.layer==6) {
            IsFlying=false;
        }

        if (collision.gameObject.layer==8) {
            IsFlying = true;
            myRigidbody.velocity = Vector2.up * 10;
        }

        if (collision.gameObject.layer==9) {
            IsFlying = true;
            myRigidbody.velocity = Vector2.up * 17;
        }

        if (collision.gameObject.layer==10) {
            IsFlying = false;
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    }

    void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.layer==10) {
            IsFlying = false;
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.layer==10) {
            IsFlying = true;
        }
    }


}
