using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    //PlayBut
    public void StartGame(){
        SceneManager.LoadScene("MainMap");
    }

    //ExitBut
    public void ExitGame(){
        Debug.Log("Игра закрыта");
        Application.Quit();
    }
}
