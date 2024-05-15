using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab_Script : MonoBehaviour
{
    public Sprite sprite_1;
    public Sprite sprite_2;
    public Sprite sprite_3;
    public Sprite sprite_4;
    public Sprite sprite_5;
    public Sprite sprite_6;
    public Sprite sprite_7;
    public Sprite sprite_8;
    public Sprite sprite_9;
    public Sprite sprite_10;
    private List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;
    private bool onTop;
    private int i;
    private LogicScript logicScript;
    private BlockScript blockScript;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = new List<Sprite>();
        onTop = false;
        i = 0;
        blockScript = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        sprites.Add(sprite_1);
        sprites.Add(sprite_2);
        sprites.Add(sprite_3);
        sprites.Add(sprite_4);
        sprites.Add(sprite_5);
        sprites.Add(sprite_6);
        sprites.Add(sprite_7);
        sprites.Add(sprite_8);
        sprites.Add(sprite_9);
        sprites.Add(sprite_10);
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExampleCoroutine(){
        while(true){
            while(blockScript.IsAlive && !logicScript.IsFreezed){
                if(i==9){
                    onTop = true;
                }

                if(i==0){
                    onTop = false;
                }

                if(!onTop){  
                    i++;
                }

                if(onTop){
                    i--;
                }
                yield return new WaitForSecondsRealtime(1/2);
                yield return new WaitForSecondsRealtime(1/2);
                yield return new WaitForSecondsRealtime(1/2);
                yield return new WaitForSecondsRealtime(1/2);
                spriteRenderer.sprite = sprites[i];
            }
        }
    }
}   

