using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fire_script : MonoBehaviour
{
    public GameObject player_target;
    public GameObject startPoint;
    private LineRenderer lr;
    AudioSource sound;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    void Update()
    {
        if(animator.GetInteger("state") == 1)
            StartCoroutine(FireAtEnemy());
    }

    IEnumerator FireAtEnemy()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) // The enemy fires if the player is moving and the enemy is moving too
        {
            RaycastHit hit;
            if (Physics.Raycast(player_target.transform.position, player_target.transform.forward, out hit))
            {
                yield return new WaitForSeconds(1f);
                player_target.GetComponent<Player>().TakeDamage(5);
                sound.Play();
                StartCoroutine(FireFlash());
            }
        }
    }

    IEnumerator FireFlash()
    {
        lr.enabled = true;
        lr.SetPosition(0, startPoint.transform.position);
        lr.SetPosition(1, player_target.transform.position);
        yield return new WaitForSeconds(0.05f);
        lr.enabled = false;
    }
}
