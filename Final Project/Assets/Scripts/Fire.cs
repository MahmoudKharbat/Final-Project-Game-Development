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
                sound.Play();
                target.transform.position = hit.point;
                StartCoroutine(FireFlash());
                for (int i = 0; i < normal_people.Length; i++)
                {
                    if(normal_people[i] != null)
                    {
                        print("people" + i + " is now running");
                        Animator animator = normal_people[i].GetComponent<Animator>();
                        animator.SetInteger("state", 1);
                    }   
                }
                
                /*
                if (hit.collider.gameObject == enemy.gameObject)
                {
                    Animator animator = enemy.GetComponent<Animator>();
                    animator.SetInteger("state", 1);
                }*/
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
