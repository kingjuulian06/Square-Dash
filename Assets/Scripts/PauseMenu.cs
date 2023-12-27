using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public AudioSource BG_Music;
    public BackgroundScroller bgscript;

    public LogicScript logic;

    public void ClosePauseMenu(){
        pauseMenu.SetActive(false);
        BG_Music.Play();
        bgscript.ScrollSpeed = 1f;
        logic.IsFreezed = false;        
    }

    public void ExitGame() {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }
    
    void Start() 
    {
        bgscript = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundScroller>();
        logic = GetComponent<LogicScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!logic.IsFreezed) {
            pauseMenu.SetActive(true);
            BG_Music.Stop();
            bgscript.ScrollSpeed = 0f;
        }   
    }

    
}
