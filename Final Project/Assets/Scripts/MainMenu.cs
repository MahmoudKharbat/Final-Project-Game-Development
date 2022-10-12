using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameLikeThief()
    {
        SceneManager.LoadScene(1); // load the city scene
    }

    public void PlayGameLikeCop()
    {
        //SceneManager.LoadScene(1); // load the city scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}