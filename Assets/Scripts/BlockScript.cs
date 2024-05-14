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
    public int gravity = 2;
    private GameObject movement;
    public Sprite sprite1;
    public Sprite sprite2;
    public int direction = 1;

    private UnityEngine.RigidbodyConstraints2D constraints;


    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprite1;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        m_Rigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        movement = GameObject.FindWithTag("Level");
    }

    void Update()
    {
        if (!logic.IsFreezed) {
            m_Rigidbody.gravityScale = gravity;
            m_Rigidbody.constraints = RigidbodyConstraints2D.None;
            logic.addTime();
        }
        if (IsFlying && !logic.IsFreezed && GetComponent<SpriteRenderer>().sprite == sprite1) {
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }
    
        if(Input.GetKeyDown(KeyCode.Space) && IsAlive && !IsFlying && !logic.IsFreezed && GetComponent<SpriteRenderer>().sprite == sprite1) {
            logic.addJump();
            IsFlying = true;
            AudioManager.instance.PlayOneShot(FMODEvents.instance.jumped, this.transform.position);
            m_Rigidbody.velocity = Vector2.up * blockStrength * direction;
        }

        if(logic.IsFreezed) {
            m_Rigidbody.gravityScale = gravity;
            velocity = m_Rigidbody.velocity;
            m_Rigidbody.velocity = Vector2.zero;
            m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        if(GetComponent<SpriteRenderer>().sprite == sprite2){
            if(Input.GetKeyDown(KeyCode.Space) && IsAlive && !IsFlying && !logic.IsFreezed){
                gravity = -gravity;
            }

            rotation = Vector3.forward;
            transform.Rotate(rotation * speed * Time.deltaTime);
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
            m_Rigidbody.velocity = Vector2.up * 10;
            IsFlying = true;
        }

        if (collision.gameObject.layer==9) {
            m_Rigidbody.velocity = Vector2.up * 17;
            IsFlying = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.layer==10) {
            IsFlying = false;
            rotation = Vector3.back;
            transform.Rotate(rotation * speed * Time.deltaTime);
        }

        if (collider.gameObject.layer==11) {
            if (collider.gameObject.GetComponent<Gravity_Reverse_Portal_Script>().direction==0) {
                gravity = -2;
                direction = -1;
            }
            else if(collider.gameObject.GetComponent<Gravity_Reverse_Portal_Script>().direction==1){
                gravity = 2;
                direction = 1;
            }
        }

        if (collider.gameObject.layer==12){
            
            if (collider.gameObject.GetComponent<MirrorScript>().direction==0) {
                movement.GetComponent<MovementScript>().direction = -1;
            }
            else if(collider.gameObject.GetComponent<MirrorScript>().direction==1) {
                movement.GetComponent<MovementScript>().direction = 1;
            }
        }

        if (collider.gameObject.layer==13){
            if(GetComponent<SpriteRenderer>().sprite==sprite1){
                GetComponent<SpriteRenderer>().sprite = sprite2;
                //transform.position.y = transform.position.y + 0.86;
            }
            else{
                GetComponent<SpriteRenderer>().sprite = sprite1;
               //transform.position.y = transform.position.y + -4.468984;
            }
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
