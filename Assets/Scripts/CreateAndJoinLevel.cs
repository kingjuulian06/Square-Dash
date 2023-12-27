using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAndJoinLevel : MonoBehaviour
{

    public LevelScoller scroller;

    private void Start()
    {
        scroller = GameObject.Find("Level_Scroller").GetComponent<LevelScoller>();
    }
    public void JoinRoom() 
    {
<<<<<<< HEAD
        SceneManager.LoadScene(scroller.i + 2);
=======
        SceneManager.LoadScene(scroller.i + 3);
>>>>>>> 5794762dc91d1f0d42c77a434b28d24af5d5a080
    }

}
