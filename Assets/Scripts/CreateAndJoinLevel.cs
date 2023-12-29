using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAndJoinLevel : MonoBehaviour
{

    public LevelScoller scroller;
    public LevelChanger levelChanger;

    private void Start()
    {
        scroller = GameObject.Find("Level_Scroller").GetComponent<LevelScoller>();
        levelChanger = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
    }
    public void JoinRoom() 
    {
        levelChanger.FadeToLevel(scroller.i + 2);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

}
