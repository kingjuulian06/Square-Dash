using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseGame : MonoBehaviour
{
    public void startMenu() {
        SceneManager.LoadScene("Lobby");
    }

}
