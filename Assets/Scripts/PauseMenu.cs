using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement; 
=======
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public AudioSource BG_Music;
    public BackgroundScroller bgscript;

    public LogicScript logic;

<<<<<<< HEAD
    public void ClosePauseMenu(){
        pauseMenu.SetActive(false);
        BG_Music.Play();
        bgscript.ScrollSpeed = 1f;
        logic.IsFreezed = false;        
    }

    public void ExitGame() {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(1);
    }
    
=======

>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
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
<<<<<<< HEAD
        }   
    }

    
=======
        }    
    }
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
}
