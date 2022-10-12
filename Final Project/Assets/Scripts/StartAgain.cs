using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAgain : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene(2);// load the menu scene
    }
}
