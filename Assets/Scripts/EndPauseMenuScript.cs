using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EndPauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public AudioSource BG_Music;
    public BackgroundScroller bgscript;

    public LogicScript logic;

    void Start()
    {
        bgscript = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundScroller>();
        logic = GetComponent<LogicScript>();
    }
    public void ClosePauseMenu(){
        pauseMenu.SetActive(false);
        BG_Music.Play();
        bgscript.ScrollSpeed = 0.5f;
    }

    public void ExitGame() {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
