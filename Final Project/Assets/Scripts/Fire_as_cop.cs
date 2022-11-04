using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire_as_cop : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject target;
    public GameObject startPoint;
    public GameObject[] normal_people;
    public GameObject[] otherCops;
    public GameObject robber;
    public GameObject game_background_music;
    private Player player;
    private LineRenderer lr;
    AudioSource sound;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        sound = GetComponent<AudioSource>();
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(aCamera.transform.position, aCamera.transform.forward, out hit))
            {
                if (game_background_music != null)
                    game_background_music.SetActive(true);
                sound.Play();
                target.transform.position = hit.point;
                StartCoroutine(FireFlash());
                for (int i = 0; i < normal_people.Length; i++) // Changing the state for the normal people and make them go out the bank
                {
                    if (normal_people[i] != null)
                    {
                        animator = normal_people[i].GetComponent<Animator>();
                        animator.SetInteger("state", 1);
                    }
                }
                // Robber
                animator = robber.GetComponent<Animator>();
                if (animator.GetInteger("state") != 2)
                {
                    if (hit.collider.gameObject == robber.gameObject)
                    {
                        robber.GetComponent<RobberScript>().Health -= 10;
                        player.TakeDamage(10);
                    }
                }


                /* First Cop*/
                animator = otherCops[0].GetComponent<Animator>();
                if (animator.GetInteger("state") != 2)
                {
                    animator.SetInteger("state", 1);
                    if (hit.collider.gameObject == otherCops[0].gameObject)
                        otherCops[0].GetComponent<npc_enemy1>().Health -= 20;
                }


                /* Second Cop*/
                animator = otherCops[1].GetComponent<Animator>();
                if (animator.GetInteger("state") != 2)
                {
                    animator.SetInteger("state", 1);
                    if (hit.collider.gameObject == otherCops[1].gameObject)
                        otherCops[1].GetComponent<npc_enemy2>().Health -= 20;
                }


                /* Third Cop*/
                animator = otherCops[2].GetComponent<Animator>();
                if (animator.GetInteger("state") != 2)
                {
                    animator.SetInteger("state", 1);
                    if (hit.collider.gameObject == otherCops[2].gameObject)
                        otherCops[2].GetComponent<npc_enemy3>().Health -= 20;
                }

                /* Fourth Cop*/
                animator = otherCops[3].GetComponent<Animator>();
                if (animator.GetInteger("state") != 2)
                {
                    animator.SetInteger("state", 1);
                    if (hit.collider.gameObject == otherCops[3].gameObject)
                        otherCops[3].GetComponent<npc_enemy4>().Health -= 20;

                }
            }
        }
    }

    IEnumerator FireFlash()
    {
        lr.enabled = true;
        lr.SetPosition(0, startPoint.transform.position);
        lr.SetPosition(1, target.transform.position);
        yield return new WaitForSeconds(0.05f);
        lr.enabled = false;
    }
}
