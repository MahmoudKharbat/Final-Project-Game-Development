using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npc_enemy2 : MonoBehaviour
{
    public GameObject rifle;
    Animator animator;
    private int health = 100;

    public int Health
    {
        get { return health; }   // get method
        set { health = value; }  // set method
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetInteger("state") == 1)
        {
            rifle.SetActive(true);
        }

        if (health == 0)
        {
            print("enemy2 you are dead");
            rifle.SetActive(false);
            animator.SetInteger("state", 2);
        }
    }
}