using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToCityScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
            SceneManager.LoadScene(1);
        else if (SceneManager.GetActiveScene().buildIndex == 1)
            SceneManager.LoadScene(0);
    }
}
