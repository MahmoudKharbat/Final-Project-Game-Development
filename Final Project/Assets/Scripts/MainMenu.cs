using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGameLikeThief()
    {
        if (GlobalManager.Instance != null)
            GlobalManager.Instance.updateHealth(100);
        SceneManager.LoadScene(1); // load the city scene
    }

    public void PlayGameLikeCop()
    {
        if(GlobalManager.Instance != null)
            GlobalManager.Instance.updateHealth(100);
        SceneManager.LoadScene("Scenes/RobbScene"); // load the Robb scene RobbScene
        //Scenes/RobbScene: Scene number 4 
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Scenes/NumOfWins");
        Application.Quit();
    }
}
