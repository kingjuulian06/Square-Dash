using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumppad_script : MonoBehaviour
{
    public Sprite m_SpriteA;
    public Sprite m_SpriteB;
    private float progress;
    public float duration;
    public SpriteRenderer m_SR;


    // Start is called before the first frame update
    void Start()
    {
        m_SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

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
}
