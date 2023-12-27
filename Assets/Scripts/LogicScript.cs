using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public BlockScript player;
    public bool IsFreezed = false;
    public GameObject gameOverScreen;
    public GameObject pauseMenu;
    public AudioSource BG_Music;
    public BackgroundScroller bgscript;

    private int playerJumps;
    public Text jumpsText;

<<<<<<< HEAD
    private float playTime;
    private int newPlayTime;
=======
    private int playTime;
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
    public Text timeText;


    void Start() 
    {
        bgscript = GameObject.FindGameObjectWithTag("Background").GetComponent<BackgroundScroller>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<BlockScript>();
    }

    public void addJump() {
        playerJumps += 1;
        jumpsText.text = playerJumps.ToString() + "  Jumps";
    }

    public void addTime() {
<<<<<<< HEAD
        playTime += Time.deltaTime;
        newPlayTime = Mathf.RoundToInt(playTime);
=======
        //playTime += Time;
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
        timeText.text = playTime.ToString() + "  Seconds";
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
        BG_Music.Stop();
        bgscript.ScrollSpeed = 0f;
<<<<<<< HEAD
        player.IsAlive = false;
=======
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
    }

    void Update() 
    {
<<<<<<< HEAD

        if (Input.GetKeyUp(KeyCode.Escape) && !IsFreezed && player.IsAlive) {
            IsFreezed = true;
            pauseMenu.SetActive(true);
            BG_Music.Pause();
            bgscript.ScrollSpeed = 0f;
        } else if (Input.GetKeyUp(KeyCode.Escape) && IsFreezed && player.IsAlive) {
=======
        if (Input.GetKeyDown(KeyCode.Escape) && !IsFreezed && player.IsAlive) {
            IsFreezed = true;
            pauseMenu.SetActive(true);
            BG_Music.Stop();
            bgscript.ScrollSpeed = 0f;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && IsFreezed && player.IsAlive) {
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
            pauseMenu.SetActive(false);
            BG_Music.Play();
            bgscript.ScrollSpeed = 1f;
            player.myRigidbody.gravityScale = 2;
            player.myRigidbody.velocity = player.velocity;
            IsFreezed = false;
        }
<<<<<<< HEAD

        if (!IsFreezed && player.IsAlive) {
            addTime();
        }

        
=======
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
    }
}
