using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameLikeThief()
    {
        GlobalManager.Instance.updateHealth(100);
        SceneManager.LoadScene(1); // load the city scene
    }

    public void PlayGameLikeCop()
    {
        GlobalManager.Instance.updateHealth(100);
        SceneManager.LoadScene("Scenes/RobbScene"); // load the Robb scene RobbScene
        //Scenes/RobbScene: Scene number 4 
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
