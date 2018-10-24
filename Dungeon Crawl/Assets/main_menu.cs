using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour {

    public void PlayGame(){
        SceneManager.LoadScene("test_scene");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
