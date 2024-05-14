using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class LogicScript : MonoBehaviour
{

    public BlockScript player;
    public GameObject particles;
    public bool IsFreezed = false;
    [field: Header("Screens")]
    public GameObject gameOverScreen;
    public GameObject pauseMenu;
    public BackgroundScroller bgscript;
    private int playerJumps;
    private int playTime;
    private int lastTime;
    private int trys;
    [field: Header("Stats")]
    public Text jumpsText;
    public Text timeText;
    public Text tryText;
    [field: Header("Audio")]
    public AudioManager audioManager;
    [field: Header("Animation")]
    public LevelChanger levelChanger;


    void Start() 
    {
        bgscript = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundScroller>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
        levelChanger = GameObject.FindGameObjectWithTag("LevelChanger").GetComponent<LevelChanger>();
        particles = GameObject.Find("Touch");
    }

    public void addJump() {
        playerJumps += 1;
        jumpsText.text = playerJumps.ToString() + "  Jumps";
    }

    public void addTime() {
        playTime = Mathf.RoundToInt(Time.time) - lastTime;
        timeText.text = playTime.ToString() + "  Seconds";
    }

    public void addTry() {
        trys += 1;
        tryText.text = trys.ToString() + " Versuche";
    }

    public void restartGame() {
        addTry();
        lastTime = playTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
        bgscript.ScrollSpeed = 0f;
        audioManager.StopMusic();
        particles.SetActive(false);
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsFreezed && player.IsAlive) {
            IsFreezed = true;
            pauseMenu.SetActive(true);
            bgscript.ScrollSpeed = 0f;
            audioManager.PauseMusic();
            player.gravity = 0;
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
        player.m_Rigidbody.velocity = player.velocity;
        player.gravity = 2;
    }

    public void ExitGame() {
        pauseMenu.SetActive(false);
        levelChanger.FadeToLevel(1);
    }
}
