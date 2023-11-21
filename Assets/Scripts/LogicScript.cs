using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject pauseMenu;
    public AudioSource BG_Music;
    public BackgroundScroller bgscript;

    private int playerJumps;
    public Text jumpsText;

    private int playTime;
    public Text timeText;


    void Start() 
    {
        bgscript = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundScroller>();
    }

    public void addScore(int scoreToAdd){
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void addJump() {
        playerJumps += 1;
        jumpsText.text = playerJumps.ToString() + "  Jumps";
    }

    public void addTime() {
        playTime += Time;
        timeText.text = playTime.ToString() + "  Seconds";
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
        BG_Music.Stop();
        bgscript.ScrollSpeed = 0f;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.SetActive(true);
            BG_Music.Stop();
            bgscript.ScrollSpeed = 0f;
        }
    }
}