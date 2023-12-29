using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class LogicScript : MonoBehaviour
{

    public BlockScript player;
    public bool IsFreezed = false;
    public GameObject gameOverScreen;
    public GameObject pauseMenu;
    public BackgroundScroller bgscript;
    [field: Header("Stats")]
    private int playerJumps;
    public Text jumpsText;

    private int playTime;
    public Text timeText;
    [field: Header("Audio")]
    public AudioManager audioManager;
    [field: Header("Animation")]
    public LevelChanger levelChanger;


    void Start() 
    {
        bgscript = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundScroller>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
        levelChanger = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
    }

    public void addJump() {
        playerJumps += 1;
        jumpsText.text = playerJumps.ToString() + "  Jumps";
    }

    public void addTime() {
        playTime += Mathf.RoundToInt(Time.deltaTime);
        timeText.text = playTime.ToString() + "  Seconds";
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
        bgscript.ScrollSpeed = 0f;
        audioManager.StopMusic();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsFreezed && player.IsAlive) {
            IsFreezed = true;
            pauseMenu.SetActive(true);
            bgscript.ScrollSpeed = 0f;
            audioManager.PauseMusic();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsFreezed && player.IsAlive) {
            ClosePauseMenu();
        }
    }

    public void ClosePauseMenu(){
        IsFreezed = false;
        pauseMenu.SetActive(false);
        bgscript.ScrollSpeed = 1f;
        audioManager.PlayMusic();
        player.myRigidbody.velocity = player.velocity;
    }

    public void ExitGame() {
        pauseMenu.SetActive(false);
        levelChanger.FadeToLevel(1);
    }
}
