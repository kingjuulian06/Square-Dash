using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAndJoinLevel : MonoBehaviour
{

    public LevelScoller scroller;

    private void Start()
    {
        scroller = GameObject.Find("Level_Scroller").GetComponent<LevelScoller>();
    }
    public void JoinRoom() 
    {
        SceneManager.LoadScene(scroller.i + 3);
    }

}