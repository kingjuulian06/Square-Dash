using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f,1f)]
    public float ScrollSpeed = 1f;
    private float offset;
    private Material mat;

    void Start() 
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update() {
        offset += (Time.deltaTime * ScrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

}
