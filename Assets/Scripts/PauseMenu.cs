using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public BackgroundScroller bgscript;

    public LogicScript logic;

    
    void Start() 
    {
        bgscript = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundScroller>();
        logic = GetComponent<LogicScript>();
    }

    void Update()
    {
        
    }

    
}
