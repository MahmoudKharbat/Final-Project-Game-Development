using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PortalToCityScene : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        GlobalManager.Instance.updateHealth(Player.currentHealth);
        
        if (SceneManager.GetActiveScene().name == "MainScene")
            StartCoroutine(waitBeforeNewScene("Scenes/CityScene"));
        else if (SceneManager.GetActiveScene().name == "CityScene")
            StartCoroutine(waitBeforeNewScene("Scenes/MainScene"));
    }

    IEnumerator waitBeforeNewScene(string sceneName)
    {
        if (GlobalManager.Instance.getHealth() != 0) // Robber (player) is not dead.
        {            
            PlayerInventory playerInventory = player.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                if (playerInventory.NumberOfMoney > 0)
                {
                    GlobalManager.Instance.addWin();
                    SceneManager.LoadScene("Scenes/WinTheGame");
                }
                else
                    SceneManager.LoadScene(sceneName);
            }
        }
        yield return new WaitForSeconds(2f);
    }
}
