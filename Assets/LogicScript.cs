using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    // public TouchPoint1Script Script1;
    // public TouchPoint2Script Script2;
    // public TouchPoint3Script Script3;
    // public TouchPoint4Script Script4;
    // public bool IsTouchingBottom;
    // public bool IsTouchingLeftSide;

    public void addScore(int scoreToAdd){
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver() {
        gameOverScreen.SetActive(true);
    }

    // void Update() {
    //     if (Script1.IsTouching1 && Script2.IsTouching2) {
    //         IsTouchingBottom = false;
    //     }
    //     if (Script1.IsTouching1 && Script4.IsTouching4) {
    //         IsTouchingLeftSide = true;
    //     }
    //     if (Script2.IsTouching2 && Script3.IsTouching3) {
    //         IsTouchingLeftSide = false;
    //     }
    //     if (Script4.IsTouching4 && Script3.IsTouching3) {
    //         IsTouchingBottom = true;
    //     }
    // }
}
