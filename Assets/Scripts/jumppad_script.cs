using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumppad_script : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -15;
    public BlockScript player;
    public Sprite m_SpriteA;
    public Sprite m_SpriteB;
    private float progress;
    public float duration;
    public SpriteRenderer m_SR;

    public LogicScript logic;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
        m_SR = GetComponent<SpriteRenderer>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsAlive&&!logic.IsFreezed) {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        if(transform.position.x<deadZone){
            Debug.Log("Jumppad_klein Deleted");
            Destroy(gameObject);
        }

        progress+=1;

        if (progress > duration) {
            if (m_SR.sprite==m_SpriteA) {
                m_SR.sprite = m_SpriteB;
            }
            else {
                m_SR.sprite = m_SpriteB;
            }
            progress = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.layer==7) {
            Debug.Log("Spike Destroyed!");
            Destroy(gameObject);
        }
    }

}
