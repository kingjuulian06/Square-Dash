using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockScript : MonoBehaviour
{
    public Vector2 velocity; 
    public Rigidbody2D m_Rigidbody;
    public float blockStrength;
    public bool IsAlive = true;
    public LogicScript  logic;
    private Vector3 rotation;
    private float speed = 175;
    public bool IsFlying = false; 

    private UnityEngine.RigidbodyConstraints2D constraints;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        m_Rigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!logic.IsFreezed) {
            m_Rigidbody.gravityScale = 2;
            m_Rigidbody.constraints = RigidbodyConstraints2D.None;
            logic.addTime();
        }
        if (IsFlying && !logic.IsFreezed) {
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    
        if(Input.GetKeyDown(KeyCode.Space) && IsAlive && !IsFlying && !logic.IsFreezed) {
            logic.addJump();
            IsFlying = true;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.jumped, this.transform.position);
            m_Rigidbody.velocity = Vector2.up * blockStrength;
        }

        if(logic.IsFreezed) {
            velocity = m_Rigidbody.velocity;
            m_Rigidbody.velocity = Vector2.zero;
            m_Rigidbody.gravityScale = 0;
            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer==7) {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.died, this.transform.position);
            logic.gameOver();
            IsAlive = false;
            Destroy(gameObject);
        }

        if (collision.gameObject.layer==6) {
            IsFlying=false;
        }

        if (collision.gameObject.layer==8) {
            IsFlying = true;
            m_Rigidbody.velocity = Vector2.up * 10;
        }

        if (collision.gameObject.layer==9) {
            IsFlying = true;
            m_Rigidbody.velocity = Vector2.up * 17;
        }

        if (collision.gameObject.layer==10) {
            IsFlying = false;
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer==10) {
            IsFlying = false;
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if (collider.gameObject.layer==10) {
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    }   
    

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.gameObject.layer==10) 
        {
            IsFlying = true;
        }
    }        
    


}
