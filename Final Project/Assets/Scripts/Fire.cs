using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject aCamera;
    public GameObject target;
    public GameObject startPoint;
    public GameObject[] normal_people;
    public GameObject[] enemies;
    public GameObject game_background_music;
    private LineRenderer lr;
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
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
            if(Physics.Raycast(aCamera.transform.position,aCamera.transform.forward,out hit))
            {
                game_background_music.SetActive(true);
                sound.Play();
                target.transform.position = hit.point;
                StartCoroutine(FireFlash());
                for (int i = 0; i < normal_people.Length; i++) // Changing the state for the normal people and make them go out the bank
                {
                    if(normal_people[i] != null)
                    {
                        Animator animator = normal_people[i].GetComponent<Animator>();
                        animator.SetInteger("state", 1);
                    }   
                }

                
                for (int i = 0; i < enemies.Length; i++) 
                {
                    if (enemies[i] != null)
                    {
                        Animator animator = enemies[i].GetComponent<Animator>();
                        animator.SetInteger("state", 1);
                        if (hit.collider.gameObject == enemies[i].gameObject)
                        {
                            enemies[i].GetComponent<npc_enemy>().Health -= 20;
                        }
                    }
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
        //lr.SetPosition(1, startPoint.transform.position);
        lr.enabled = false;
    }
}
