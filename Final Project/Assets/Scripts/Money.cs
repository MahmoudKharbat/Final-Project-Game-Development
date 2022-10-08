using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    AudioSource sound;
    public GameObject allMoney;

    private void Start()
    {
        sound = allMoney.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null)
        {
            playerInventory.MoneyCollected();
            sound.Play();
            gameObject.SetActive(false);
        }
    }
}